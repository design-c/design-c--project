# design-c#-project

## Проект для курса проектирование на c#


## Команда:

+ ### Батуев Макар РИ-300019
+ ### Сычков Илья РИ-300003
+ ### Дорохов Сергей РИ-300018

## Что готово в Api:

+ #### Реализована авторизация через УрФУ
+ #### Получение оценок пользователя и информации о нём
+ #### Использован DI контейнер, встроенный в asp.net
+ #### Использовали паттерн Mediatr
+ #### Реализован ddd
+ #### Добавлена база данных PostgreSQL + миграции на EntityFramework
+ #### Api и база данных упакованы в docker
+ #### В Api добавили авторизованную зону(нельзя отправлять запросы без приложенного jwt token-а) + добавили в свагер авторизацию bearer jwt
+ #### Написаны тесты на сервисы, которые мы используем в Domain

## Структура Api:

![](Images/ApiStructure.png)

## Тесты в Api:

![](Images/ApiTests.png)

## Сценарий использования Api:

![](Images/Api.png)

![](Images/AuthRequest.png)

![](Images/AuthResponse.png)

![](Images/BearerAuth.png)

![](Images/UserData.png)

![](Images/UrfuMarks.png)

## Точки расширение Api:

+ #### Добавление других разделов сайта УрФУ
+ #### Добавление ботов других социальных сетей
+ #### Возможность создания публичного api

## Что хотели бы добавить в Api:

+ #### Добавить миграции в докер
+ #### Добавить logger
+ #### Добавить обработчик ошибок
+ #### Long polling

## Что готово в telegram bot:

+ #### Наличие и рабочее состояние бота в телеграме
+ #### Взаимодействие бота с пользователем
+ #### Команды бота
+ #### Состояния бота
+ #### Паттерн "Команда"
+ #### Паттерн "Машина состояний"
+ #### Di-container
+ #### Реализован DDD
+ #### Упакован в докер

## Структура telegram bot:

![](Images/TelegramBotStructure.png)

## Реализация паттернов telegram bot:
+ #### Паттерн "Команда"

Интерфейс ICommand

![](Images/TelegramBotICommand.png)

Реализация интерфейса
![](Images/TelegramBotCommandRealisation.png)

Все реализации

![](Images/TelegramBotCommandFiles.png)

Списки команд
![](Images/TelegramBotCommandLists.png)

Получение команды из текста
![](Images/TelegramBotCommandParser.png)

Использование команды
![](Images/TelegramBotCommandUsage.png)

+ #### Паттерн "Машина состояний"
Машина состояний
![](Images/TelegramBotStateMachine.png)

Абстрактный класс состояния бота
![](Images/TelegramBotStateClass.png)

Каждое состояние разное
![](Images/TelegramBotStateMain.png)

![](Images/TelegramBotStateLogin.png)

![](Images/TelegramBotStateStart1.png)

![](Images/TelegramBotStateStart2.png)

Словарь машин состояний для каждого пользователя
![](Images/TelegramBotStateMachines.png)

Реализация машины состояний
![](Images/TelegramBotStateRealisation1.png)
![](Images/TelegramBotStateRealisation2.png)

## Точки расширение telegram bot:

+ #### Добавление новых команд бота
+ #### Добавление новых состояний бота со своими клавиатурами и списком команд
+ #### Добавление новых клавиатур и других методов ввода команд
+ #### Изменение формата вывода комманд

## Что хотели бы добавить в telegram bot:

+ #### Соеденить api с ботом
+ #### Добавить logger
+ #### Добавить Redis
+ #### Добавить тесты

## CI\CD:
### CI - Continuous Integration
При создании мр на ветку main срабатывает триггер github action, после чего проект собирается на виртаульной машине и прогоняются все тесты.
![](Images/testsOnMR.jpg)
(*файл конфигурации ".github/workflows/dotnet.yml")

### CD - Continuous Delivery\ Continuous Deployment
При пуше изменений в ветку main срабатывает триггер github action, после чего посылается команда на сервер, где происходит выполняются следующие шаги:
+ #### Обновление данных из репозитория
+ #### Получение чувствительных данных для переменных окружения из Github Secrets
+ #### Запуск приложения в docker
+ #### Установка миграций на бд
(* В случае ошибки при сборке будет использован предыдущий билд, а статус операции во вкладке "actions" будет failed)
![](Images/cd.jpg)
(*файл конфигурации ".github/workflows/deploy.yml")