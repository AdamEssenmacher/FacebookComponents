#addin nuget:?package=Cake.FileHelpers&version=3.2.1

var FB_VERSION = "17.0.2";
var NUGET_VERSION = "17.0.2.0";

var TARGET = Argument ("t", Argument ("target", "ci"));

var ARTIFACTS = new List<ArtifactInfo> {
	//new ArtifactInfo("facebook-android-sdk", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("facebook-bolts", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("facebook-core", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("facebook-common", FB_VERSION, NUGET_VERSION),
	//new ArtifactInfo("facebook-login", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("facebook-share", FB_VERSION, NUGET_VERSION),
	//new ArtifactInfo("facebook-applinks", FB_VERSION, NUGET_VERSION),
	//new ArtifactInfo("facebook-messenger", FB_VERSION, NUGET_VERSION),
	//new ArtifactInfo("facebook-gamingservices", FB_VERSION, NUGET_VERSION),
	//new ArtifactInfo("audience-network-sdk", "6.6.0", "6.6.0")
};

class ArtifactInfo
{
	public ArtifactInfo(string id, string version, string nugetVersion = null)
	{
		ArtifactId = id;
		Version = version;
		NugetVersion = nugetVersion ?? version;
	}

	public string ArtifactId { get;set; }
	public string Version { get;set; }
	public string NugetVersion { get;set; }
}

Task ("externals")
	.Does (() => 
{
	EnsureDirectoryExists("./output");
	EnsureDirectoryExists ("./externals/");

	foreach (var artifact in ARTIFACTS) {
		var url = $"http://search.maven.org/remotecontent?filepath=com/facebook/android/{artifact.ArtifactId}/{artifact.Version}/{artifact.ArtifactId}-{artifact.Version}.aar";
		var pomUrl = $"http://search.maven.org/remotecontent?filepath=com/facebook/android/{artifact.ArtifactId}/{artifact.Version}/{artifact.ArtifactId}-{artifact.Version}.pom";
		var docUrl = $"http://search.maven.org/remotecontent?filepath=com/facebook/android/{artifact.ArtifactId}/{artifact.Version}/{artifact.ArtifactId}-{artifact.Version}-javadoc.jar";

		var aar = $"./externals/{artifact.ArtifactId}.aar";
		if (!FileExists (aar))
			DownloadFile(url, aar);

		var pom = $"./externals/{artifact.ArtifactId}.pom";
		if (!FileExists (pom))
			DownloadFile(pomUrl, pom);

		try {
			var localDocsFile = $"./externals/{artifact.ArtifactId}-javadoc.jar";
			if (!FileExists (localDocsFile))
				DownloadFile(docUrl, localDocsFile);

			EnsureDirectoryExists ($"./externals/{artifact.ArtifactId}-docs/");
			Unzip (localDocsFile, $"./externals/{artifact.ArtifactId}-docs/");
		} catch {}
	}
});

Task ("libs")
	.IsDependentOn("externals")
	.Does(() =>
{
    var buildSettings = new DotNetBuildSettings { Configuration = "Release" };
    DotNetBuild("./source/Xamarin.Facebook.AdamE.slnf", buildSettings);
});

Task ("samples")
	.IsDependentOn("libs")
	.Does(() =>
{
// 	var samples = new string[] { 
// 		"./samples/HelloFacebookSample.sln",
// 		"./samples/MessengerSendSample.sln",
// 	};
// 
// 	foreach (var sampleSln in samples) {
// 		MSBuild(sampleSln, c => 
// 	 		c.SetConfiguration("Release")
//  			.WithTarget("Restore"));
// 
// 		MSBuild(sampleSln, c => 
// 			c.SetConfiguration("Release")
// 			.WithTarget("Build")
// 			.WithProperty("DesignTimeBuild", "false"));
// 	}
});

Task ("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	EnsureDirectoryExists("./output");

	foreach (var art in ARTIFACTS) {
		var csproj = "./source/" + art.ArtifactId + "/" + art.ArtifactId + ".csproj";
		
		var buildSettings = new DotNetPackSettings
		{
            Configuration = "Release",
            OutputDirectory = MakeAbsolute((DirectoryPath)"./output/").FullPath
		};

		DotNetPack(csproj, buildSettings);	
	}
});

Task ("clean")
	.Does (() => 
{
	MSBuild("./source/Xamarin.Facebook.AdamE.slnf", c => 
		c.SetConfiguration("Release")
 		.WithTarget("Clean"));

	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", new DeleteDirectorySettings {
															Recursive = true,
															Force = true
														});
});

Task ("ci")
	.IsDependentOn("externals")
	.IsDependentOn("libs")
	.IsDependentOn("nuget")
	.IsDependentOn("samples");

RunTarget (TARGET);
