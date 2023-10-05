# Moist

## Зміст

## Файли

`moist.exe` - інтерпретатор мови Moist

`*.moist` - файли мовою Moist

## Приклади

[Examples/](https://github.com/Aristocrab/Moist/tree/main/Examples)

## Основні правила

### Змінні та константи

```moist
const x := 42;
y := 10;
```

### Присвоєння

```moist
x = 20;
```

### Базові типи

```moist
x := 42;                # Integer
y := 3.14;              # Double
z := "Hello";           # String
a := true;              # Boolean
b := [1, "two", 3.14];  # Array
u := unit;              # Unit
```

### Індексація

```moist
arr := [1, 2, 3];
x := arr[0];        # x = 1

str := "Hello";
c := str[0];        # c = 'H'
```

### Умовний оператор "if"

```moist
if (x > 30) {
    PrintLine("x більше 30");
} else {
    PrintLine("x менше або рівне 30");
}
```

### Цикл "while"

```moist
while (x > 0) {
    PrintLine(x);
    x = x - 1;
}
```

### Цикл "for"

```moist
for (i := 0; i < 5; i = i + 1) {
    PrintLine(i);
}
```

### Цикл "for" для колекцій та строк

```moist
arr := [1, 2, 3, 4, 5];
for (item in arr) {
    PrintLine(item);
}

str := "Hello, world!";
for (c in str) {
    PrintLine(c);
}
```

### Оголошення функцій

```moist
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

```moist
result := add(3, 4);
```

### Оператори порівняння

```moist
# > < >= <= == !=

if (x > y) {
    PrintLine("x більше y");
}

if (a == b) {
    PrintLine("a дорівнює b");
}
```

### Оператори

```moist
# Оператори над числами
+ - * / %

# Оператори над строками
+
``````

## Базові типи

Мова Moist підтримує наступні типи:

- `Unit`: Пустий тип
- `Integer`: Ціле число
- `Double`: Дійсне число
- `String`: Рядок
- `Boolean`: Логічний тип
- `Array`: Масив



## Інтерпретатор Brainfuck

```moist
func runBrainfuck(code) {
    memory := Array(3000, 0);
    pointer := 0;
    
    stack := [];
    
    char := "";
    for (i := 0, i < Length(code), i = i + 1) {
        char = code[i];
        if (char == "+") {
            SetValue(memory, pointer, memory[pointer] + 1);
        } 
        if (char == "-") {
            SetValue(memory, pointer, memory[pointer] - 1);
        }
        if (char == ".") {
            Print(Char(memory[pointer]));
        }
        if (char == ",") {
            SetValue(memory, pointer, AsciiCode(ReadLine()));
        }
        if (char == "<") {
            pointer = pointer - 1;
        }
        if (char == ">") {
            pointer = pointer + 1;
        }
        if (char == "[") {
            if (memory[pointer] == 0) {
                level := 1;
                while (level > 0) {
                    i := i + 1;
                    if (code[i] == "[") {
                        level = level + 1;
                    }
                    if (code[i] == "]") {
                        level = level - 1;
                    }
                }
            } else {
                Append(stack, i);
            }
        }
        if (char == "]") {
            if (memory[pointer] != 0) {
                i = stack[Length(stack) - 1];
            } else {
                Remove(stack, Length(stack) - 1);
            }
        }
    }
}

runBrainfuck(">+++++++++[<++++++++>-]<.>+++++++[<++++>-]<+.+++++++..+++.>>>++++++++[<++++>-]<.>>>++++++++++[<+++++++++>-]<---.<<<<.+++.------.--------.>>+.>++++++++++.");
```

### Result

`> Hello World!`


## Стандартна бібліотека

### Функція `PrintLine`

```moist
func PrintLine(value)
```

Ця функція виводить значення `value` в консоль, додаючи символ нового рядка після виводу.

### Функція `Print`

```moist
func Print(value)
```

Ця функція виводить значення `value` в консоль без символу нового рядка.

### Функція `ReadLine`

```moist
func ReadLine()
```

Ця функція зчитує рядок із консолі та повертає його як рядкове значення.

### Функція `Sleep`

```moist
func Sleep(milliseconds)
```

Ця функція призупиняє виконання програми на вказану кількість мілісекунд.

### Функція `String`

```moist
func String(obj)
```

Ця функція конвертує об'єкт `obj` в рядкове представлення та повертає його.

### Функція `TypeOf`

```moist
func TypeOf(obj)
```

Ця функція повертає рядок, який представляє тип об'єкта `obj`.

### Функція `Pow`

```moist
func Pow(x, y)
```

Ця функція обчислює `x` у ступені `y` та повертає результат.

### Функція `Append`

```moist
func Append(list, value)
```

Ця функція додає значення `value` до списку `list`.

### Функція `Remove`

```moist
func Remove(list, index)
```

Ця функція видаляє елемент за індексом `index` зі списку `list`.

### Функція `Clear`

```moist
func Clear(list)
```

Ця функція очищує список `list`, видаляючи всі його елементи.

### Функція `Length`

```moist
func Length(list)

func Length(str)
```

Ця функція повертає кількість елементів у списку `list` або довжину рядка `str`.

### Функція `Array`

```moist
func Array(size)

func Array(size, value)
```

Ця функція створює масив заданого розміру `size` та заповнює його значенням `value`.

### Функція `AsciiCode`

```moist
func AsciiCode(c)
```

Ця функція повертає код ASCII символу `c`.

### Функція `Char`

```moist
func Char(asciiCode)
```

Ця функція повертає символ з кодом ASCII `asciiCode`.