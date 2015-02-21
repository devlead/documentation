# Cake documentation

This is the home of the Cake documentation source code.

### Building from the command line

1. Run `build.ps1` from PowerShell.
   This will compile the tools and build the documentation.     

2. Launch a web server such as [Mongoose](http://cesanta.com/mongoose.shtml) at the `./build/docs` folder.   

### Building documentation from Visual Studio

1. Open the solution `./src/Documentation.sln`

2. Change the command line arguments for `Docs.Compiler` to the following:
   
   ```
   -configuration="C:\AbsolutePathToGitRepository\data\config.json"
   ```
   
3. Run the `Docs.Compiler` project.