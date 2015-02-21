---
title: AppVeyor Integration
sortorder: 100
content-type: markdown
---

This section will describe how to use Cake with your AppVeyor CI builds.

### 1. Add prerequisites ###

Start by copying `NuGet.exe` to your tools folder. Cake uses the `tools` path as a convention for finding stuff it needs such as unit test runners and other tools.

* MyProject
  * tools
     * nuget.exe


### 2. Add build script ###

Add a build script called `build.cake` to the project root. In this tutorial, we'll just create a really simple build script for demonstration.

	// Get the target.
	var target = Argument&lt;string&gt;("target", "Default");

	Task("Default")
	  .Does(() =&gt;
	{
	    Information("Hello from Cake!");
	});

	RunTarget(target);


### 3. Add bootstrapper script ###

Create a old fashioned batch file called `build.cmd` that will download Cake and execute the build script.

	@echo off

	:Build
	cls

	if not exist tools\Cake\Cake.exe ( 
	    echo Installing Cake...
	    tools\NuGet.exe install Cake -OutputDirectory tools -ExcludeVersion -NonInteractive -Prerelease
	)

	echo Starting Cake...
	tools\Cake\Cake.exe build.cake -target=Default -verbosity=diagnostic


### 4. Configure AppVeyor ###

Now we need to tell AppVeyor how to start the Cake build. Do this by setting the build script for your AppVeyor project to `build.cmd`. Save your settings and you should be done.

![Settings](/images/cake-appveyor-build-settings.png)


### 5. Try it out ###

The next triggered build will now execute the Cake build script as expected.

![Result](/images/cake-appveyor-result.png)
