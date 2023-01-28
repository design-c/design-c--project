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

![alt text](Images/ApiStructure.png)

## Тесты в Api:

![alt text](Images/ApiTests.png)

## Сценарий использования Api:

![alt text](Images/Api.png)

![alt text](Images/AuthRequest.png)

![alt text](Images/AuthResponse.png)

![alt text](Images/BearerAuth.png)

![alt text](Images/UserData.png)

![alt text](Images/UrfuMarks.png)

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

![alt text](Images/TelegramBotStructure.png)

## Реализация паттернов telegram bot:
+ #### Паттерн "Команда"

Интерфейс ICommand

![alt text](Images/TelegramBotICommand.png)

Реализация интерфейса
![alt text](Images/TelegramBotCommandRealisation.png)

Все реализации

![alt text](Images/TelegramBotCommandFiles.png)

Списки команд
![alt text](Images/TelegramBotCommandLists.png)

Получение команды из текста
![alt text](Images/TelegramBotCommandParser.png)

Использование команды
![alt text](Images/TelegramBotCommandUsage.png)

+ #### Паттерн "Машина состояний"
Машина состояний
![alt text](Images/TelegramBotStateMachine.png)

Абстрактный класс состояния бота
![alt text](Images/TelegramBotStateClass.png)

Каждое состояние разное
![alt text](Images/TelegramBotStateMain.png)

![alt text](Images/TelegramBotStateLogin.png)

![alt text](Images/TelegramBotStateStart1.png)

![alt text](Images/TelegramBotStateStart2.png)

Словарь машин состояний для каждого пользователя
![alt text](Images/TelegramBotStateMachines.png)

Реализация машины состояний
![alt text](Images/TelegramBotStateRealisation1.png)
![alt text](Images/TelegramBotStateRealisation2.png)

## Точки расширение telegram bot:

+ #### Добавление новых команд бота
+ #### Добавление новых состояний бота со своими клавиатурами и списком команд
+ #### Добавление новых клавиатур и других методов ввода команд
+ #### Изменение формата вывода комманд


## CI\CD:
### CI - Continuous Integration
При создании мр на ветку main срабатывает триггер github action, после чего проект собирается на виртаульной машине и прогоняются все тесты.
(* файл конфигурации ".github/workflows/dotnet.yml")


## Что хотели бы добавить в telegram bot:

+ #### Соеденить api с ботом
+ #### Добавить logger
+ #### Добавить Redis
+ #### Добавить тесты

