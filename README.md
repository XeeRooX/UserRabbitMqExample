# UserRabbitMqExample
Этот проект демонстрирует взаимодействие брокера сообщений RabbitMQ вместе с приложениями на платформе .NET. В качестве издателя (Producer) здесь выступает Web-API, который отправляет сообщение при успешном выполнении определенных эндпоинтов. А именно при создании и удалении пользователя. Подписчик (Subscriber) представлен в виде CLI, который при получении собщений выводит их на консоль.
### Использованные технологии и библиотеки
.NET 8.0, ASP.NET Core 8.0, EFCore 8.0, SQLite, FluentValidation 11.9.0, AutoMapper 12.0.1, Docker, Docker Compose
## Запуск
1. Клонировать текущий репозиторий
2. Перейти в папку с проектом
3. Выполнить команду ниже:
```
    docker compose up
```
Чтобы зайти в Swagger UI можно перейти по адресу:
```
http://localhost:5000/swagger
```

![image](https://github.com/XeeRooX/UserRabbitMqExample/assets/91987012/7aa475da-4a3a-4dda-89dc-46e36db4b7f6)

Для большей наглядности можно в отдельном окне терминала выполнить команду ниже, которая будет выводить консольный вывод только CLI подписчика:
```
docker logs -f -n 20  userrabbitmqexample-subscriber-1
```

![image](https://github.com/XeeRooX/UserRabbitMqExample/assets/91987012/0653ccdf-1346-42ec-8e6d-128e8a09f3e4)

Также можно перейти в стандартную панель управления RabbitMQ. Для этого нужно перейти по адресу ниже. Логин: guest, пароль: guest.
``` 
http://localhost:15672/
```

![image](https://github.com/XeeRooX/UserRabbitMqExample/assets/91987012/16098d62-3de2-43f4-94d1-2b519b5df73c)

## Конфигурация
Вся основная конфигурация хранится в переменных окружения, которые можно назначить в файле docker-compose.yml в блоках environment. Все переменные, описанные в этом блоке, стандартные кроме нескольких:
- ConnectionStrings__DefaultConnection - хранит в себе значение строки подключения к базе данных
- ProducerHost - хранит в себе хост RabbitMQ для издателя
- SubscriberHost - хранит в себе хост RabbitMQ для подписчика
