FROM microsoft/aspnetcore-build:2.0 AS build-env

WORKDIR /build
COPY ./ ./

RUN dotnet publish -c Release -o dist

# ---------------------------------------

FROM microsoft/aspnetcore:2.0

WORKDIR /svc
COPY --from=build-env /build/MessageBroadcast.WebApi/dist ./
ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh ./
RUN chmod +x wait-for-it.sh

EXPOSE 5001

ENTRYPOINT ["dotnet", "MessageBroadcast.WebApi.dll"]
