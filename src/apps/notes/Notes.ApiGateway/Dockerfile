FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /build

COPY ./Notes.ApiGateway.csproj ./
RUN dotnet restore

COPY ./ ./
RUN dotnet publish --configuration Release --output dist

# ---------------------------------------

FROM microsoft/dotnet:2.1-aspnetcore-runtime

WORKDIR /svc
COPY --from=build-env /build/dist ./
ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh ./
RUN chmod +x wait-for-it.sh

EXPOSE 4000

ENTRYPOINT ["dotnet", "Notes.ApiGateway.dll"]
