Проект разработан в рамках хакатона **"Код Согласия"** и занял **2-е место** в хакатоне.

# README template

После установки NET и Docker Desktop
Из директории проекта все команды:
1) подымет докер и в нем будет крутится postgres
```shell
docker compose -f ./docker/docker-compose.yml up -d
```
2) далее надо проверить наличие nuget командой

dotnet nuget list source

если в ответ "Источники не найдены." то вводим команду

dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org

иначе переходим к пункту - 3.

3) вводим команду

dotnet tool install --global dotnet-ef

4) вводим команды

```shell
dotnet ef database update -s InsuranceCompany.Web -p InsuranceCompany.Storage --context InsuranceCompanyDbContext
dotnet ef database update -s InsuranceCompany.Web -p InsuranceCompany.Web --context ApplicationDbContext
```
5) если все успешно переходим в директорию проекта InsuranceCompany.Web

cd InsuranceCompany.Web

6) Запускаем дев сервер и смотрим сайт в браузере (откроется автоматически)

dotnet watch run


-----------------------------------------------------------------------------------
видео к презентации команда лидеры
https://disk.yandex.ru/d/GdbefLTKU59vIQ

ОНЛАЙН-ХАКАТОН КОД СОГЛАСИЯ
https://codenrock.com/contests/soglasiecodehackathon#/tasks/2058/5989