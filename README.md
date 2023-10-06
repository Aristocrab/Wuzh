# Wuzh language

```wuzh
func HelloWorld() {
    PrintLine("Hello, world!");
}

HelloWorld();
```

## Зміст

- [Файли](#файли)
- [Приклади](#приклади)
- [Синтаксис](#синтаксис)
    -  [Змінні та константи](#змінні-та-константи)
    -  [Присвоєння](#присвоєння)
    -  [Базові типи](#базові-типи)
    -  [Індексація](#індексація)
    -  [Умовний оператор "if"](#умовний-оператор-if)
    -  [Цикл "while"](#цикл-while)
    -  [Цикл "for"](#цикл-for)
    -  [Цикл "foreach"](#цикл-for-для-колекцій-та-строк)
    -  [Оголошення функцій](#оголошення-функцій)
    -  [Виклик функцій](#виклик-функцій)
    -  [Оператори порівняння](#оператори-порівняння)
    -  [Операції](#операції)
- [Базові типи](#базові-типи)
- [Стандартна бібліоткеа](#стандартна-бібліотека)

## Файли

`wuzh.exe` - інтерпретатор

`*.wuzh` - розширення файлів

## Приклади

- [Examples/](https://github.com/Aristocrab/wuzh/tree/main/Examples)
    -  [helloworld.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/helloworld.wuzh)
    -  [factorial.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/factorial.wuzh)
    -  [brainfuck.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/brainfuck.wuzh)
    -  [morse.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/morse.wuzh)
    -  [syntaxExample.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/syntaxExample.wuzh)


## Синтаксис

### Змінні та константи

```wuzh
const x := 42;
y := 3.14;
```

### Присвоєння

```wuzh
x = 21 * 2;
```

### Базові типи

```wuzh
u := unit;              # Unit
x := 42;                # Integer
y := 3.14;              # Double
z := "Hello";           # String
a := true;              # Boolean
b := [1, "two", 3.14];  # Array
range := [1..10];       # Array from 1 to 10
d := {                  # Dictionary
    "name": "Vlad", 
    "age": 19
};
```

### Індексація

```wuzh
arr := [1, 2, 3];
x := arr[0];        # x = 1

str := "Hello";
c := str[0];        # c = "H"

dict := {                  
    "name": "Vlad", 
    "age": 19
};
d := dict["name"];   # d = "Vlad"

arr[0] = 3;
str[0] = "B";
dict["name"] = "Bob";
dict["height"] = "180cm";
```

### Умовний оператор "if"

```wuzh
if (x > 30) {
    PrintLine("x більше 30");
} else {
    PrintLine("x менше або рівне 30");
}
```

### Цикл "while"

```wuzh
while (x > 0) {
    PrintLine(x);
    x = x - 1;
}
```

### Цикл "for"

```wuzh
for (i := 0, i < 5, i = i + 1) {
    PrintLine(i);
}
```

### Цикл "for" для колекцій та строк

```wuzh
arr := [1, 2, 3, 4, 5];
for (item in arr) {
    PrintLine(item);
}

# Range from 1 to 10
for (i in [1..10]) {
    PrintLine(i);
}

str := "Hello, world!";
for (c in str) {
    PrintLine(c);
}
```

### Оголошення функцій

```wuzh
func add(a, b) {
    return a + b;
}

func factorial(n)
{
    if(n == 0)
    {
        return 1;
    }
    else
    {
        return n * factorial(n - 1);
    }
}

# return type is Unit
func printName(name) {
    PrintLine(name);
}
```

### Виклик функцій

```wuzh
result := add(3, 4);
```

### Оператори порівняння

```wuzh
# > < >= <= == !=

if (x > y) {
    PrintLine("x більше y");
}

if (a == b) {
    PrintLine("a дорівнює b");
}
```

### Операції

```wuzh
# Операції над числами
+ - * / // %

# Операції над строками
+ *

strConcat := "Hello" + " " + "world!"; # strConcat = "Hello world!"
strRepeat := "Hello" * 3;              # strRepeat = "HelloHelloHello"
``````

## Базові типи

Мова wuzh підтримує наступні типи:

- `Unit`: Пустий тип
- `Integer`: Ціле число
- `Double`: Дійсне число
- `String`: Рядок
- `Boolean`: Логічний тип
- `Array`: Масив
- `Dictionary`: Словник

## Стандартна бібліотека

Список функцій стандартної бібліотеки: [StdLib/](https://github.com/Aristocrab/Wuzh/blob/main/Wuzh/StandardLibrary/Functions.cs);

### Функція `PrintLine`

```wuzh
func PrintLine(value)
```

Ця функція виводить значення `value` в консоль, додаючи символ нового рядка після виводу.

### Функція `Print`

```wuzh
func Print(value)
```

Ця функція виводить значення `value` в консоль без символу нового рядка.

### Функція `ReadLine`

```wuzh
func ReadLine()
```

Ця функція зчитує рядок із консолі та повертає його як рядкове значення.

### Функція `Sleep`

```wuzh
func Sleep(milliseconds)
```

Ця функція призупиняє виконання програми на вказану кількість мілісекунд.

### Функція `String`

```wuzh
func String(obj)
```

Ця функція конвертує об'єкт `obj` в рядкове представлення та повертає його.

### Функція `TypeOf`

```wuzh
func TypeOf(obj)
```

Ця функція повертає рядок, який представляє тип об'єкта `obj`.

### Функція `Pow`

```wuzh
func Pow(x, y)
```

Ця функція обчислює `x` у ступені `y` та повертає результат.

### Функція `Append`

```wuzh
func Append(list, value)
```

Ця функція додає значення `value` до списку `list`.

### Функція `Remove`

```wuzh
func Remove(list, index)
```

Ця функція видаляє елемент за індексом `index` зі списку `list`.

### Функція `Clear`

```wuzh
func Clear(list)
```

Ця функція очищує список `list`, видаляючи всі його елементи.

### Функція `Length`

```wuzh
func Length(list)

func Length(str)
```

Ця функція повертає кількість елементів у списку `list` або довжину рядка `str`.

### Функція `Array`

```wuzh
func Array(size)

func Array(size, value)
```

Ця функція створює масив заданого розміру `size` та заповнює його значенням `value`.

### Функція `AsciiCode`

```wuzh
func AsciiCode(c)
```

Ця функція повертає код ASCII символу `c`.

### Функція `Char`

```wuzh
func Char(asciiCode)
```

Ця функція повертає символ з кодом ASCII `asciiCode`.

### Функція `Int`

```wuzh
\func Int(str)
```

Ця функція конвертує рядок `str` в ціле число.

### Функція `Contains`

```wuzh
func Contains(dict, key)
```

Ця функція повертає `true`, якщо словник `dict` містить ключ `key`, інакше повертає `false`.

### Функція `GetKeys`

```wuzh
func GetKeys(dict)
```

Ця функція повертає список ключів словника `dict`.

### Функція `GetValues`

```wuzh
func GetValues(dict)
```

Ця функція повертає список значень словника `dict`.
