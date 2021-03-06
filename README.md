# GeekBrainsCSharpLevel1.

Курс GeekBrains "C# Уровень 1"

## Методичка 1. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 1.

Задания:

1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.

2. * Заменить кружочки картинками, используя метод DrawImage.

## Методичка 2. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 2.

Задания:

1. Построить  три  класса  (базовый  и  2  потомка),  описывающих  работников  с  почасовой  оплатой  (один  из  потомков)  и  фиксированной оплатой (второй потомок):
a. Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы. Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; для  работников  с  фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
b. Создать на базе абстрактного класса массив сотрудников и заполнить его;
c. * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort();
d. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
3. Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
5. * Создать собственное исключение GameObjectException, которое появляется при попытке  создать объект с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или неверная позиция).

## Методичка 3. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 3.

Задания:

1. Добавить космический корабль, как описано в уроке.
2. Доработать игру «Астероиды»:
a. Добавить ведение журнала в консоль с помощью делегатов;
b. * добавить это и в файл.
3. Разработать аптечки, которые добавляют энергию.
4. Добавить подсчет очков за сбитые астероиды.
5. * Добавить в пример Lesson3 обобщенный делегат.

## Методичка 4. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 4.

Задания:

1. Добавить в программу коллекцию астероидов. Как только она заканчивается (все астероиды сбиты), формируется новая коллекция, в которой на один астероид больше.
2. Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
a. для целых чисел;
b. * для обобщенной коллекции;
c. ** используя Linq.
3. * Дан фрагмент программы:
```csharp
  Dictionary<string, int> dict = new Dictionary<string, int>()
  {
    {"four",4 },
    {"two",2 },
    { "one",1 },
    {"three",3 },
  };
  var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
  foreach (var pair in d)
  {
    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
  }
```
а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
b. * Развернуть обращение к OrderBy с использованием делегата.

## Методичка 5. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 3.

Задания:

Создать WPF-приложение для ведения списка сотрудников компании.
1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно сделать, например, с использованием ComboBox или ListView.
3. Предусмотреть редактирование сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника. Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.
4. Предусмотреть возможность создания новых сотрудников и департаментов. Реализовать это либо на форме редактирования, либо сделать новую форму.

## Методичка 6. Продвинутый курс C#. Связывание данных. Триггеры.

Задания:

Изменить WPF-приложение для ведения списка сотрудников компании (из урока 5), используя связывание данных, ListView, ObservableCollection и INotifyPropertyChanged.
1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно сделать, например, с использованием ComboBox или ListView.
3. Предусмотреть редактирование сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника. Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.
4. Предусмотреть возможность создания новых сотрудников и департаментов. Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.

## Методичка 7. Продвинутый курс C#. Взаимодействие с базой данных.

Задания:

Изменить WPF-приложение для ведения списка сотрудников компании (из урока 5), используя связывание данных, DataGrid и ADO.NET.
1. Создать таблицы Employee и Department в БД MSSQL Server и заполнить списки сущностей начальными данными.
2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно сделать, например, с использованием ComboBox или ListView.
3. Предусмотреть редактирование сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника. Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.
4. Предусмотреть возможность создания новых сотрудников и департаментов. Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.

## Методичка 8. Продвинутый курс C#. Обзор сервис-ориентированной архитектуры приложений (SOA).

Задания:

Изменить WPF-приложение для ведения списка сотрудников компании (из урока 7), используя веб-сервисы. Разделите приложение на две части. Первая часть – клиентское приложение, отображающее данные. Вторая часть – веб-сервис и код, связанный с извлечением данных из БД. Приложение реализует только просмотр данных. При разработке приложения допустимо использовать любой из рассмотренных типов веб-сервисов.
1. Создать таблицы Employee и Department в БД MSSQL Server и заполнить списки сущностей начальными данными;
2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение);
3. Разработать формы для отображения отдельных элементов списков сотрудников и департаментов.


