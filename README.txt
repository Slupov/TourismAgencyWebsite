﻿Контролна работа 2
Работил: F82264 Стоян Лупов

Информация:
Приложението представлява информационен сайт за туристическа агенция.
То работи на версия ASP.NET CORE 2.1. Допълнителни библиотеки: 1)Entity Framework Core 2.1.
Изисква инсталиран SQL Server с инсталирана инстанция LocalDB. Connection string-a към базата се намира в appsettings.json
в MatinloAdventures.Web проекта.

За да се вържат всички dependent libraries моля извикайте командата dotnet restore в Package management console-ата.
След това Ctrl + Shift + B за да се билдне проектa (bin и obj папките не са качени в заданието).

Съдържа управление на потребителски профили и роли. При първоначално стартиране на проекта базата се запълва с начални стойности (data seed).
Вграден е админски профил по подразбиране с username: admin, password: 123.
  !!!Важно!!!: Той може да модифицира коментарите към цените на пакетите в "Навигация>Цени".
  Може и да добавя, модифицира и премахва цени и пакети. Поддържа същата функционалност за често задавани въпроси. Нормалните потребители нямат достъп до
  такива функционалности.

AJAX имплементация се намира в таб "Времето" където се прави заявка към външен
API който взима информация за астрономическото време в момента. В "Контакти" се намира Google Maps имплементация на местоположението на агенцията.

В "Навигация>Галерия" се намира страница от няколко responsive design наредени изображения.
Страница съдържаща динамични коментари в Таб "Навигация>Цени". Коментарите там се добавят чрез jQuery и се съхраняват в базата.

Беше започната имплементация на блог, но за нея не стигна времето.