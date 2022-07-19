2022-07-15     
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

2022-07-19 
     타이머 동작