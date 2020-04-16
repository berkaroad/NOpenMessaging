all: pack

pack: rebuild
	rm -rf `pwd`/nuget/.DS_Store
	rm -rf `pwd`/nuget/*/.DS_Store
	rm -rf `pwd`/nuget/*/*/.DS_Store
	rm -rf `pwd`/nuget/*/lib/*/*.pdb
	rm -rf `pwd`/nuget/*/lib/*/*.json
	nuget pack -OutputDirectory `pwd`/packages/ `pwd`/nuget/NOpenMessaging/NOpenMessaging.nuspec

rebuild: clean build

clean:
	rm -rf `pwd`/nuget/.DS_Store
	rm -rf `pwd`/nuget/*/.DS_Store
	rm -rf `pwd`/nuget/*/*/.DS_Store
	rm -rf `pwd`/nuget/*/lib/*

build: build-2_0 build-netFramework

build-2_0:
	dotnet build -c Release -f 'netstandard2.0' -o `pwd`/nuget/NOpenMessaging/lib/netstandard2.0/ `pwd`/src/NOpenMessaging/

build-netFramework:
	msbuild `pwd`/src/NOpenMessaging/NOpenMessaging.csproj -r -noConLog -t:Rebuild -p:Configuration=Release -p:TargetFramework=net462 -p:OutputPath=`pwd`/nuget/NOpenMessaging/lib/net462/
