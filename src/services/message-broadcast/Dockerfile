FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /build
COPY ./ ./

RUN dotnet publish -c Release -o dist

# ---------------------------------------

FROM microsoft/dotnet:2.1-aspnetcore-runtime

WORKDIR /svc
COPY --from=build-env /build/MessageBroadcast.WebApi/dist ./
ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh ./
RUN chmod +x wait-for-it.sh

EXPOSE 5001

ENTRYPOINT ["dotnet", "MessageBroadcast.WebApi.dll"]
