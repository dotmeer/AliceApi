# AliceApi
Взаимодействие Алисы и MQTT

## Настройки
В коллекцию `UserService:AllowedUsers` необходимо поместить имейлы пользователей yandex, которым позволено использовать сервис.

## Deploy
`docker build -t cr.yandex/crpjcqf10jvhlvo8c0p3/aliceapi:latest . -f dotmeer.AliceApi.Api/Dockerfile`   
`docker push cr.yandex/crpjcqf10jvhlvo8c0p3/aliceapi:latest`