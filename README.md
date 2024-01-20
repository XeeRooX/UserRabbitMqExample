# UserRabbitMqExample
��� ������ ������������� �������������� ������� ��������� RabbitMQ ������ � ������������ �� ��������� .NET. � �������� �������� (Producer) ����� Web-API, ������� ���������� ��������� ��� �������� ���������� ������������ ����������. � ������ ��� �������� � ������� ������������. ��������� (Subscriber) ����������� � ���� CLI � ��� ��������� �������� ������� �� �� �������.
### �������������� ���������� � ����������
.NET 8.0, ASP.NET Core 8.0, EFCore 8.0, SQLite, FluentValidation 11.9.0, AutoMapper 12.0.1, Docker, Docker Compose
## ������
1. ����������� ������� �����������
2. ������� � ����� � ��������
3. ��������� ������� ����:
```
    docker compose up
```
����� ����� � Swagger UI ����� ������� �� ������:
```
http://localhost:5000/swagger
```
��� ������� ����������� ����� � ��������� ���� ��������� ��������� ������� ����, ������� ����� �������� ���������� ����� ������ CLI ����������:
```
docker logs -f -n 20  userrabbitmqexample-subscriber-1
```
����� ����� ������� � ����������� ������ ���������� RabbitMQ. ��� ����� ����� ������� �� ������ ����. �����: guest, ������: guest.
``` 
http://localhost:15672/
```
## ������������
��� �������� ������������ �������� � ���������� ���������, ������� ����� ��������� � ����� docker-compose.yml � ����� environment. ��� ����������, ��������� � ���� �����, ����������� ����� ����������:
- ConnectionStrings__DefaultConnection - ������ � ���� �������� ������ ����������� � ���� ������
- ProducerHost - ������ � ���� ���� RabbitMQ ��� ��������
- SubscriberHost - ������ � ���� ���� RabbitMQ ��� ����������