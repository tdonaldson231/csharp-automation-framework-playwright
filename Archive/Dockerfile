FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN apt-get update && \
    apt-get install -y curl gnupg wget fonts-liberation libasound2 libatk-bridge2.0-0 \
        libatk1.0-0 libcups2 libdbus-1-3 libgdk-pixbuf2.0-0 libnspr4 libnss3 libx11-xcb1 \
        libxcomposite1 libxdamage1 libxrandr2 xdg-utils ca-certificates apt-transport-https \
        software-properties-common libxkbcommon0 && \
    wget -q https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y powershell && \
    rm packages-microsoft-prod.deb && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY . .

# Restore and build
RUN dotnet restore AutomationFrameworkRepo_v03.sln
RUN dotnet build AutomationFrameworkRepo_v03.sln --no-restore

# Install Playwright browsers and system deps
RUN pwsh bin/Debug/net8.0/playwright.ps1 install-deps
RUN pwsh bin/Debug/net8.0/playwright.ps1 install

# Set default test category as env variable
ENV TEST_CATEGORY=smoke
ENV TEST_ENV=dev

# Add entrypoint script
COPY dotnet-test.sh /app/dotnet-test.sh
RUN chmod +x /app/dotnet-test.sh

ENTRYPOINT ["/app/dotnet-test.sh"]