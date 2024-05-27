# base image, has only what is needed to execute SocialNexusService.dll
FROM	mcr.microsoft.com/dotnet/aspnet:8.0	AS	base
WORKDIR	/app

# build image, has what is needed to create SocialNexusService.dll
FROM	mcr.microsoft.com/dotnet/sdk:8.0	AS	build
WORKDIR	/src
COPY	SocialNexusService.csproj	.
RUN	dotnet restore "SocialNexusService.csproj"
COPY	.	.
RUN	dotnet build "SocialNexusService.csproj" -c Release -o /app/build

# piggy back off of build image, publish SocialNexusService
FROM build as publish
RUN dotnet publish "SocialNexusService.csproj" -c Release -o /app/publish

# take the complete SocialNexusService and dependencies only as final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# tell docker what command to run when started, dotnet SocialNexusService.dll
ENTRYPOINT	["dotnet","SocialNexusService.dll"]
