# drcloud-backend
A `.Net 5.0` project. 

This project contains OAuth service, API services and jobs for Dr.Cloud platform.

# How to run
1. Environment
    - [.Net 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
2. Configuation
    - App config: /DrCloud.Commons/appconfig.[environment].json
    - Sensitive configuration folder: /usr/local/drcloud/config
3. Go to the */Services/Main/DrCloud.Main.API* folder and run ``dotnet run``, or, in visual studio set the api project as startup and run as self host (not IIS).
4. Visit http://localhost:6001/swagger to access the application's swagger.

# How to deploy

## Environment
- Linux (Ubuntu/Debian)
- Nginx
- [.Net 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- Node 14
- Yarn
- PM2
- GitLab Runner

## Databases: MySQL v8
1. drcloud_main
2. drcloud_oauth

## Configuaration
1. Environment variables
    - ```export ASPNETCORE_ENVIRONMENT=Staging```
    - ```export DRCLOUD_LOG_FOLDER=/var/log/drcloud```
2. Sensitive config: Copy these files to */usr/drcloud/config*
    - cert.pfx
    - firebase-service-account-file.json
    - sensitiveConfig.Staging.json
    - Update database connection strings in sensitiveConfig.Staging.json
3. Nginx
    - staging-accounts.drcloud.vn -> http://localhost:6000
    - staging-api.drcloud.vn -> http://localhost:6001
4. PM2 *ecosystem.config.js*
```
module.exports = {
  apps: [
    {
      name: 'drcloud-oauth',
      cwd: '/var/app/drcloud-oauth',
      script: 'dotnet DrCloud.OAuth.dll',
      args: '',
      args: '',
      env: {
        "ASPNETCORE_ENVIRONMENT": "Staging",
        "DRCLOUD_LOG_FOLDER": "/var/log/drcloud"
      },
      error_file: 'NULL',
      out_file: 'NULL',
    },
    {
      name: 'drcloud-main-api',
      cwd: '/var/app/drcloud-main-api',
      script: 'dotnet DrCloud.Main.API.dll',
      args: '',
      args: '',
      env: {
        "ASPNETCORE_ENVIRONMENT": "Staging",
        "DRCLOUD_LOG_FOLDER": "/var/log/drcloud"
      },
      error_file: 'NULL',
      out_file: 'NULL',
    },
    {
      name: 'drcloud-send-notifications',
      cwd: '/var/app/drcloud-send-notifications',
      script: 'dotnet DrCloud.Jobs.SendNotifications.dll',
      args: '',
      args: '',
      env: {
        "ASPNETCORE_ENVIRONMENT": "Staging",
        "DRCLOUD_LOG_FOLDER": "/var/log/drcloud"
      },
      cron_restart: "*/3 * * * *",
      autorestart: false,
      error_file: 'NULL',
      out_file: 'NULL',
    },
  ],
};
```
4. Gitlab Runner
    - Register a new runner for this project.

## Process
If you want to run process without PM2:

1. Service:  ```dotnet ./build/drcloud-oauth/DrCloud.OAuth.dll```
2. Service: ```dotnet .build/drcloud-main-api/DrCloud.Main.API.dll```
3. Cron job every 1 minute: ```dotnet .build/drcloud-send-notifications/DrCloud.Jobs.SendNotifications.dll```
4. Cron job every 1 minute: ```dotnet .build/drcloud-clean-appointments/DrCloud.Jobs.CleanAppointments.dll```

## Publish to folder
1. Push code to branch "master" or "staging"
2. Let GitLab CI/CD do the rest.

# Migrations
1. At very first time, we need to run database migration for drcloud_oauth:
```
dotnet DrCloud.OAuth.dll /seed

curl --location --request POST 'http://localhost:6000/apiresource' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name": "drcloud_main",
    "displayName": "Dr.Cloud Main API",
    "secret": "xxxxxxxxxxxxxxxxxxxxxxxxxxx",
    "description": "Full access to Dr.Cloud Main API",
    "scopes": ["main.read_write"]
}'

curl --location --request POST 'http://localhost:6000/client/create' \
--header 'Content-Type: application/json' \
--data-raw '{
    "clientId": "drcloud_default",
    "clientName": "Dr.Cloud Default Client",
    "clientSecret": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
    "scopes": [ "openid", "profile", "offline_access", "main.read_write"]
}'
```
2. For any update in drcloud_main:
    - Write migration scripts in folder */SqlScripts/[sprint-number]/*
    - Run migration scripts on the staging database.
    - Sync database to EntityFramework: ``dotnet ef dbcontext scaffold "server=localhost;port=3306;database=drcloud_main;uid=drcloud_readwrite;password=***;TreatTinyasBoolean=true" Pomelo.EntityFrameworkCore.MySql -c DrCloudContext -f``
    - Release to production: run migration scripts on the production database.

# This project contains:
- SwaggerUI
- EntityFramework
- MediatR
- Serilog with request logging and easily configurable sinks: Console, File, NewRelic File
- .Net Dependency Injection
- Scaffold

# Project Structure


# About
© 2021 Perfin Technology JSC