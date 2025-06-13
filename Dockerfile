# Base with Playwright and browsers
FROM mcr.microsoft.com/playwright:v1.52.0 AS base

# Install .NET SDK 8
RUN apt-get update && \
    apt-get install -y wget apt-transport-https && \
    wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y dotnet-sdk-8.0 aspnetcore-runtime-8.0 dotnet-runtime-8.0 && \
    rm -rf /var/lib/apt/lists/* && \
    rm packages-microsoft-prod.deb

WORKDIR /app

# Copy solution and restore dependencies
COPY . .
RUN mkdir -p /root/.nuget/NuGet
RUN dotnet restore AutomationFrameworkRepo_v03.sln --packages /root/.nuget/NuGet

# Build everything
RUN dotnet clean AutomationFrameworkRepo_v03.sln
RUN dotnet build AutomationFrameworkRepo_v03.sln --no-restore

# Set environment variables (can be overridden at runtime)
ENV TEST_ENV=dev
ENV TEST_CATEGORY=smoke

COPY ./entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh
CMD ["/app/entrypoint.sh"]
