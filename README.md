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

![alt text](https://s271vlx.storage.yandex.net/rdisk/024f2d299a5ea37ad77cbe75c36753db9d47dc37d2b0c66243a9b8be0f3c390d/63cd8dd9/hntZ55Q4-qFu2_wYkKmALwXJolQxowxtE9kmexzmQ7oW0je3H_DAzWAs9AjDsyxtUcwSK90miGHfLQOy_IHstA==?uid=309542642&filename=api%20structure.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=16944&hid=9b33ed419c94d3771398d8a28867170a&media_type=image&tknv=v2&etag=87d70bbc29666d06166f565f777966c6&rtoken=v9aXsTi0dEoY&force_default=yes&ycrid=na-ed1cdffaf6d332fb82fb9b9e896fd56a-downloader24h&ts=5f2df41ac6840&s=3faaf4fcc6350b9de4915ad2d280b8449dd083d658e3efee10121ad93c6478c8&pb=U2FsdGVkX19Ets8Dm0PeNdZ_gKqD5m40uCHp1Nn963aTAlsgDt62_HpyRgdSDgG7-QYNIgaNO0V2Ak_2dOL_xohyh9xry-Njq4FwYQCbZ1Q)

## Тесты в Api:

![alt text](https://s521sas.storage.yandex.net/rdisk/2c942665d3e2823bfbe9cc6b58d482c75a2720d61ac11a99d78b76651cc1c0e4/63cd8de9/hntZ55Q4-qFu2_wYkKmAL8kfDVaET8xrktlS01m9wo7kRh2CSdIr0iA7WJzricYn3YPE8h3vtyj0K3LBI6SW3A==?uid=309542642&filename=api%20tests.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=30060&hid=7035789f04f6f99b9b73adcdcc7535aa&media_type=image&tknv=v2&etag=ad5d4584ae31b442c58b2a5df227df97&rtoken=B5BPUX0yvkA5&force_default=yes&ycrid=na-d1aaa389497d2907f432455df44a6d3a-downloader24h&ts=5f2df42a08c40&s=923a540e8650591c0e780e1addd85994596b0635ea22a175913e6230261849ed&pb=U2FsdGVkX18txESuHgeXxL1deXvblXJKoDyXqn-e3ud9KHgyYYTDfCJbpHgO-WdltVtSWAoYogCYPHhnZWe4wiimt5BjGoYT0FC45aYEod4)

## Сценарий использования Api:

![alt text](https://s01myt.storage.yandex.net/rdisk/d6b9e84ac7f4d4111c90a918c30330f559427a0a4e554d499cc145da29858a1e/63cd8953/hntZ55Q4-qFu2_wYkKmAL8VEJu3k1G1zc3Hlpk1JEvBAutgz_nHazXCNGJHBR45cZT-df58dyNtnj4WW0u2j5w==?uid=309542642&filename=api.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=22250&hid=478c15e3607fcdbc58d06e637773c3f9&media_type=image&tknv=v2&etag=5bde731c6bc71b86031198d5bec57c84&rtoken=Df5ZWs9phi7O&force_default=yes&ycrid=na-ff10b53b58c2ea02fe08bdcd82f3cd63-downloader19f&ts=5f2defca6bac0&s=d33bef6ae1443b4fb8c9820a822d96cfa26061403a214a3455e192a8ad5a2235&pb=U2FsdGVkX1__V4z60Jh0DSm91IoOPuA35EyEfiyMfggxiAc6vYYsgYmCu5IcIgGAn_uUPOfF6p5EZnBLDhGebZR_ulldoLWingi1qNkrX98)

![alt text](https://s263iva.storage.yandex.net/rdisk/c2b964fee3d3c5d7dda1c28d75e62af44465acf3f9a6857d7a1ae44f2128e0e8/63cd89d3/hntZ55Q4-qFu2_wYkKmAL9tGf8QD9AwBR5XEjmowXRVCDP-dT-4RwBIpxIdVn8U8pmX2Zd_FE16vdHPhIV9i9Q==?uid=309542642&filename=auth%20request.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=18673&hid=4a2b521a63dcda06891dbd4512aea3c6&media_type=image&tknv=v2&etag=929df1d7139e3573e794cd71180847b2&rtoken=8jqmwPzhDCJ7&force_default=yes&ycrid=na-6794ab65e541c43fbe7e6ed435fd70a9-downloader19f&ts=5f2df0447dac0&s=30c77031d2c5893ea93e3fc32353275fe700f07bf5b44cac5d5ee705f67cc128&pb=U2FsdGVkX197CbaTfmXP1ObNj_w4gZ-ZLLQjQxjQyLjxeSmbRMJSdRRMB6gfBoeZdEM28YdTNHAjYF2nqBij1Da7RFZ0HmAVoTNjdXeYF-w)

![alt text](https://s317sas.storage.yandex.net/rdisk/f63a9ff2cf4f7c8b9cd17f81ca8ad746a1aa3a2c931345e59df04993d81169c9/63cd8a4c/hntZ55Q4-qFu2_wYkKmAL43kMgg-6qszDx2lIIv6IYXIdtwmHsXXWfPjhc2mTVNHsAkseqlSSfgt_ywGW0-obQ==?uid=309542642&filename=auth%20response.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=36856&hid=98632a5861f601aa4335b1796bc03535&media_type=image&tknv=v2&etag=c68e33d9d70e3c920d33e4a746ab821d&rtoken=tAEanrS54b7t&force_default=yes&ycrid=na-8c2cba355010ef4e667bdbb3fc50e165-downloader19f&ts=5f2df0b7e2b00&s=0c159f38d08f8967130b368268ff841d75743265793676829a5edf1d94e4669c&pb=U2FsdGVkX19nl-CdX0D9FbiQSvSTfCWcA14XF9VJ4c-fVpg7utWXSLzPDREqEod7mzzBDr4ELknqn24O9NzICdXJxdnm3d15C8Wdv999au8)

![alt text](https://s323vla.storage.yandex.net/rdisk/48da7590a423abdf8a6011679af377f0d5ba238429984c600a961b198d0ac8fb/63cd8aae/hntZ55Q4-qFu2_wYkKmAL26gxJ1Trv0dHoRkbZw_Aj4Sb2_GijYv87H1lXs7g7OuVA8b9pi4uVg04cC-Mcvazg==?uid=309542642&filename=Bearer%20auth.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=33005&hid=335247679dcd8cb4fb8bc536742864ff&media_type=image&tknv=v2&etag=e66ffba30e2ddecf0d53e49f0a6dd155&rtoken=2URPfrAdho3V&force_default=yes&ycrid=na-3b49b0d6cc36e5832b2b0817302a115a-downloader19f&ts=5f2df11558780&s=7e8a707c794b360703514329f56b3e19cd20c36b437865d8995413120ba6bc23&pb=U2FsdGVkX187V8Unc0bj5xEmfap-fYbyjf-1nehv7M_BlzLcwbkRxyFTgz3Mh-pJj-MqSR-5rcw89lQvrdoUOg7G3axfOlKYe8lplG-ad2U)

![alt text](https://s378vla.storage.yandex.net/rdisk/3cd6ea3bcbf1b601c72153fe7a5d3760989de566190b438638405b820a505d9c/63cd8c60/hntZ55Q4-qFu2_wYkKmAL-ZgSTCf1FkvD7zanup7P5eWXxkaP-s-Wba7vvCCNd0qmAdSuFPZqr6qm1RM2ZIjew==?uid=309542642&filename=user%20data.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=37264&hid=05ec3008c3a5590025e212d05ad059ea&media_type=image&tknv=v2&etag=891ce0d50809bcf16c4045d76270593b&rtoken=0tAKfBN7lRib&force_default=yes&ycrid=na-95332c8a7b9227a830159135bda297b8-downloader16h&ts=5f2df2b33d800&s=f76a051ac7f50091891f551c5f3cba678eb17ba2e74fb0df793074462a4098cb&pb=U2FsdGVkX18l_hqQYgoXkvMd8cyD1Z_NDWkGVCeE1TYIj0SWRCbiNUFiHZgl0uBhmntdDHntDOZho7tZ1X7RXRg_WcLAn8_fTzydVpx-1Ic)

![alt text](https://s431sas.storage.yandex.net/rdisk/b4d341442b0700b66a46cf233b0beb0b3c6cb0a6e758d63d9fa8d4c132a1a524/63cd8bfb/hntZ55Q4-qFu2_wYkKmALxgvNuICrFZDuPd6OZARzGjxc4eAzojFwK9H-s86ez6vCVa4reSp3QHC78LhTUz_Zg==?uid=309542642&filename=urfu%20marks.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&owner_uid=309542642&fsize=59850&hid=8e96134648c3e2a70099f8f2a2906413&media_type=image&tknv=v2&etag=44497d5099852f4e3ae25bae4e1b703f&rtoken=R6SjibniRfnQ&force_default=yes&ycrid=na-acdde6e1f8b99fa321494a7b41d8433b-downloader16h&ts=5f2df252eb4c0&s=0c39542b22115011dd1d5f5d86f03a0528f062978cc30d232ba7ea3410118d62&pb=U2FsdGVkX19VzN1yDOSpNeV8mNWd6EYcZPEUdno0i34msDh2IJ1msSCIoQmUmzJ_wbfKbJupa27_gYJqsIQnHIvl8cRtKQVYZt9NwOCjxhU)

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
