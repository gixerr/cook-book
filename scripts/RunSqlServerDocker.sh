#!/bin/bash

docker run -d -p 1433:1433 -e sa_password=SecretPassword666! -e ACCEPT_EULA=Y microsoft/mssql-server-windows-developer