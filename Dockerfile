FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY . .

RUN dotnet restore AutomationFrameworkRepo_v03.sln && \
    dotnet build AutomationFrameworkRepo_v03.sln --no-restore

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/bin/Debug/net8.0 /app/bin/Debug/net8.0

RUN apt-get update && apt-get install -y powershell && \
    pwsh /app/bin/Debug/net8.0/playwright.ps1 install-deps && \
    pwsh /app/bin/Debug/net8.0/playwright.ps1 install

COPY tests.sh /app/tests.sh
RUN chmod +x /app/tests.sh

ENTRYPOINT ["/app/tests.sh"]
