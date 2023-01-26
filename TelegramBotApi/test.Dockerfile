FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY . .
RUN apk add ca-certificates
FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine AS base-runtime
# OpenSSL 3.0 disables UnsafeLegacyRenegotiation by default, must re-enable it for some endpoints (see https://github.com/dotnet/runtime/issues/80641)
RUN sed -i 's/providers = provider_sect/providers = provider_sect\n\
ssl_conf = ssl_sect\n\
\n\
[ssl_sect]\n\
system_default = system_default_sect\n\
\n\
[system_default_sect]\n\
Options = UnsafeLegacyRenegotiation/' /etc/ssl/openssl.cnf
RUN dotnet test
