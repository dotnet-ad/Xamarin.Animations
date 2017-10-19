var TARGET = Argument ("target", Argument ("t", "Default"));
var VERSION = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", "0.0.9999");
var CONFIG = Argument("configuration", EnvironmentVariable ("CONFIGURATION") ?? "Release");
var SLN = "../Sources/Xam.Animations.sln";
var NUSPEC = "../Xam.Package.nuspec";
var NUPKGFOLDER = "./nuget";

Task("Build").Does(()=>
{
	NuGetRestore (SLN);
	MSBuild (SLN, c => {
		c.Configuration = CONFIG;
		c.MSBuildPlatform = Cake.Common.Tools.MSBuild.MSBuildPlatform.x86;
	});
});

Task ("Pack")
	.IsDependentOn ("Build")
	.Does (() =>
{
    if(!DirectoryExists(NUPKGFOLDER))
        CreateDirectory(NUPKGFOLDER);
        
	NuGetPack (NUSPEC, new NuGetPackSettings { 
		Version = VERSION,
		OutputDirectory = NUPKGFOLDER,
		BasePath = "./"
	});
});

Task ("Clean").Does(() => 
{
	CleanDirectory ("./Sources/component/tools/");
	CleanDirectories (NUPKGFOLDER);
	CleanDirectories ("./**/bin");
	CleanDirectories ("./**/obj");
});

Task ("Default").IsDependentOn("Pack");

RunTarget (TARGET);