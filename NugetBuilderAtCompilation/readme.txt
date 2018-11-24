

The .csproj was edited by hand to add this extra target to build the nuget,
the version is extracted from the target binary (AssemblyInfo.cs) :

<Target Name="PostBuildMacros">
	<GetAssemblyIdentity AssemblyFiles="$(TargetPath)">
		<Output TaskParameter="Assemblies" ItemName="Targets" />
	</GetAssemblyIdentity>
	<ItemGroup>
		<VersionNumber Include="@(Targets->'%(Version)')" />
	</ItemGroup>
</Target>
<PropertyGroup>
	<PostBuildEventDependsOn>
		$(PostBuildEventDependsOn);
		PostBuildMacros;
	</PostBuildEventDependsOn>
	<PostBuildEvent>rem Buil the nuget package
"$(SolutionDir)packages\NuGet.CommandLine.4.7.1\tools\NuGet.exe" pack -version @(VersionNumber) MyNuget.Sample.nuspec
	</PostBuildEvent>
</PropertyGroup>
