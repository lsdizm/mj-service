2022-07-15

     sudo dotnet add package Oracle.ManagedDataAccess.Core
     ORACLE 안쓰고 MariaDB 설치함

     sudo dotnet add package Dapper
     sudo dotnet add package Mysql.Data


     sudo dotnet publish -c Release

     serverice 만들어서 실행

     sudo cp mj-service.service /etc/systemd/system/mj-service.service
     
     sudo systemctl daemon-reload
     sudo systemctl enable mj-service.service
     sudo systemctl start mj-service.service
     sudo systemctl stop mj-service.service
     sudo systemctl status mj-service.service


(description= (retry_count=20)(retry_delay=3)
(address=(protocol=tcps)(port=1522)(host=adb.ap-seoul-1.oraclecloud.com))
(connect_data=(service_name=g4b9432fe3b1aeb_mj_high.adb.oraclecloud.com))
(security=(ssl_server_cert_dn="CN=adb.ap-seoul-1.oraclecloud.com, OU=Oracle ADB SEOUL, O=Oracle Corporation, L=Redwood City, ST=California, C=US")))