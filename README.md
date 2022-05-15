# Решение

### C#

#### Когда вызываются статические конструкторы классов в C#?

При инициализации первого объекта класса

#### Для чего нужно использовать конструкцию using(…){…}?

Для безопасного использования классов унаследованных от IDisposable. 
Безопасно, так как подобные классы не чистятся GCом и требуют мануального уничтожения, а конструкция using 
вызывает Dispose у созданных внутри usingа классов.
Грубо говоря

```
using(IDisposable class = new SomeDisposable()){
 //logic
}
```
эквивалентно 
```
IDisposable class = new SomeDisposable()

//logic

class.Dispose
```

#### Написать пример класса для использования его в цикле foreach(var i in MyClass).

Решение в папке проекта EnumerableCollection


### SQL

#### Условие:

Есть две таблицы: 

*Сотрудники (Ид int NOT NULL PK, Имя nvarchar(50) NOT NULL, Должность int NULL FK)
Должности (Ид int NOT NULL PK, Имя nvarchar(50) NOT NULL)*

```
create table Employee
(
    Id int not null primary key,
    Name  nvarchar(50) not null,
    JobId int foreign key references Jobs (Id)
)

create table Jobs
(
    Id int not null primary key,
    Name nvarchar(50) not null
)

```
![](https://i.imgur.com/NY318yZ.png)
![](https://i.imgur.com/A1L5IpI.png)


#### Составить запрос списка сотрудников должности «менеджер», отсортированный по имени сотрудников.

```
SELECT Employee.Name,Jobs.Name
FROM Employee INNER JOIN Jobs on Jobs.Id = Employee.JobId
WHERE Jobs.Id = 1
ORDER BY Employee.Name;
```
![](https://i.imgur.com/277GAGu.png)

#### Составить запрос списка должностей с количеством сотрудников, занимающих эти должности, отсортированный по убыванию количества сотрудников.

```
Select Jobs.Id, Jobs.Name, COUNT(*) AS CountField
From Employee inner join Jobs on Jobs.Id = Employee.JobId
group by Jobs.Id,Jobs.Name
order by CountField desc
````
![](https://i.imgur.com/0ZnsMxA.png)


### ASP.NET

#### Сделать сайт, состоящий из двух веб страниц (с точки зрения пользователя)...

Решение в папке проекта SendPicWebApp

### Скрипты, AJAX, HTML

#### Сделать веб страницу (одну) которая содержит поля для ввода регистрационных данных...
Решение в папке проекта AsyncFormUploader

#### Можно ли сделать такой сайт. Сайт содержит два файла index.html, style.css. На странице выведен список..
Использовать вставку изображения посредством Base64String кода изображения.
Если нужны именно смайлы, можно использовать dec или hex коды смайлов в используемой кодировке &#x1F981;

