FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /build

COPY ./Notes.sln ./
COPY ./Notes.Model/Notes.Model.csproj ./Notes.Model/
COPY ./Notes.Persistence/Notes.Persistence.csproj ./Notes.Persistence/
COPY ./Notes.WebApi/Notes.WebApi.csproj ./Notes.WebApi/
RUN dotnet restore

COPY ./ ./
RUN dotnet publish --configuration Release --output dist

# ---------------------------------------

FROM microsoft/dotnet:2.1-aspnetcore-runtime

WORKDIR /svc
COPY --from=build-env /build/Notes.WebApi/dist ./
ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh ./
RUN chmod +x wait-for-it.sh

EXPOSE 5000

ENTRYPOINT ["dotnet", "Notes.WebApi.dll"]
