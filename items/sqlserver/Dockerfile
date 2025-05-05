FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

# Instalacja narzędzi sqlcmd bez FTS (mssql-server-fts niedostępne w repozytorium)
RUN apt-get update && \
    apt-get install -y gnupg curl apt-transport-https unixodbc-dev && \
    curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /etc/apt/trusted.gpg.d/microsoft.gpg && \
    curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list \
      -o /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools && \
    ln -sfn /opt/mssql-tools/bin/sqlcmd /usr/bin/sqlcmd && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

ENV ACCEPT_EULA=Y

COPY sqlserver/db-init.sql /db-init.sql

ENTRYPOINT [ "/opt/mssql/bin/sqlservr" ]
