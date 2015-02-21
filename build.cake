using System.Diagnostics;
using System.ComponentModel;

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target          = Argument<string>("target", "Default");
var configuration   = Argument<string>("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////

var buildPath = "./build";
var binPath = buildPath + "/bin";
var testResultsPath = buildPath + "/test-results";
var dataPath = buildPath + "/data";
var docsPath = buildPath + "/docs";

// Get whether or not we should build the tools.
var buildTools = !GetContext().FileSystem.Exist((DirectoryPath)binPath);

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
	CleanDirectory(docsPath);

	// Only clean the bin path if it does not exist.
	// This will prevent us from building the binaries every time.
	if(buildTools)
	{
		CleanDirectory(binPath);
		CleanDirectory(testResultsPath);
	}
});

Task("Restore")
	.WithCriteria(() => buildTools)
    .Does(() =>
{
	NuGetRestore("./src/Documentation.sln");
});

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
	.WithCriteria(() => buildTools)    
    .Does(() =>
{
    MSBuild("./src/Documentation.sln", settings =>
        settings.SetConfiguration(configuration)
            .UseToolVersion(MSBuildToolVersion.NET45));	
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
	.WithCriteria(() => buildTools)    
    .Does(() =>
{
	XUnit2("./src/**/bin/" + configuration + "/*.Tests.dll", new XUnit2Settings {
	        OutputDirectory = testResultsPath,
	        XmlReportV1 = true
	    });
});

Task("Copy-Binary-Files")
	.IsDependentOn("Run-Unit-Tests")
	.WithCriteria(() => buildTools)	
    .Does(() =>
{
	CopyDirectory("./src/Docs.Compiler/bin/" + configuration, binPath);
});

Task("Compile-Documentation")
	.IsDependentOn("Copy-Binary-Files")
    .IsDependentOn("Clean")
    .Does(() =>
{	
	StartProcess("./build/bin/Docs.Compiler.exe", new ProcessSettings { 
		WorkingDirectory = "./build/bin",
		Arguments = "-configuration=../../data/config.json" });
});

Task("Copy-Assets")
    .IsDependentOn("Compile-Documentation")
    .Does(() =>
{
	CopyDirectory("./data/css", docsPath + "/css");
	CopyDirectory("./data/fonts", docsPath + "/fonts");
	CopyDirectory("./data/images", docsPath + "/images");
	CopyDirectory("./data/js", docsPath + "/js");
	CopyFileToDirectory("./data/favicon.ico", docsPath);
});

///////////////////////////////////////////////////////////////////////////////
// TARGETS
///////////////////////////////////////////////////////////////////////////////

Task("Build-Documentation")
	.IsDependentOn("Compile-Documentation")
	.IsDependentOn("Copy-Assets");

Task("Default")
    .IsDependentOn("Build-Documentation");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);
