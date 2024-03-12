# Wuzh language [(download)](https://github.com/Aristocrab/Wuzh/releases)

![Release version badge](https://img.shields.io/github/v/release/Aristocrab/Wuzh
) 

```go
func HelloWorld() {
    PrintLine("Hello, world!");
}

HelloWorld();
```

## Contents

- [Files](#files)
- [Examples](#examples)
- [Syntax](#syntax)
    - [Declaration](#declaration)
    - [Assignment](#assignment)
    - [Basic types](#basic-types)
    - [Type hinting](#type-hinting)
    - [Indexing](#indexing)
    - [If statement](#if-statement)
    - [While loop](#while-loop)
    - [For foop](#for-loop)
    - [Function declaration](#function-declaration)
    - [Function call](#function-call)
    - [Comparison operators](#comparison-operators)
    - [Operations](#operations)
- [Basic types](#basic-types)
- [Standard library](#standard-library)

## Files

`wuzh.exe` - interpreter ([link](https://github.com/Aristocrab/Wuzh/releases))

`*.wuzh` - file extensions

## Examples

- [Examples/](https://github.com/Aristocrab/wuzh/tree/main/Examples)
    - [helloworld.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/helloworld.wuzh)
    - [factorial.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/factorial.wuzh)
    - [brainfuck.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/brainfuck.wuzh)
    - [morse.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/morse.wuzh)
    - [stdlib.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/stdlib.wuzh)
    - [typeHinting.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/typeHinting.wuzh)

## Syntax

### Declaration

```go
x := 4;
const PI := 3.14;
```

### Assignment

```go
x = 21 * 2;
```

### Basic types

```go
# Unit
u := unit;

# Integer
x := 42;                
l := 1_000_000;         

# Double
y := 3.14;              

# String
z := "Hello";           

# Boolean
a := true;              

# Array
b := [1, "two", 3.14];  
range := [1..10];       

# Dictionary
d := {                  
    "name": "Vlad", 
    "age": 19
};
```

### Type hinting

```go
String str := "string";
Any str2 := "string2"; # str2 type is String

func Function(Int a, Int b) -> Int {
    return a * b;
}

func Function2(Any a, Any b) -> Any {
    return a + b;
}

func Function3(a, b) {
    return a / b;
}
```

### Indexing

```go
arr := [1, 2, 3];
x := arr[0];        # x = 1

str := "Hello";
c := str[0];        # c = "H"

dict := {                  
    "name": "Vlad", 
    "age": 19
};
d := dict["name"];   # d = "Vlad"

# Index assignment
arr[0] = 3;
str[0] = "B";
dict["name"] = "Bob";
dict["height"] = "180cm";
```

### If statement

```go
if (x > 30) {
    PrintLine("x is greater than 30");
} else {
    PrintLine("x is less than or equal to 30");
}
```

### While loop

```go
while (x > 0) {
    PrintLine(x);
    x = x - 1;
}
```

### For loop

```go
for (i := 0, i < 5, i = i + 1) {
    PrintLine(i);
}
```

#### For(each) loop

```go
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

### Function declaration

```go
func add(a, b) {
    return a + b;
}

func mult(Int a, Int b) -> Int {
    return a * b;
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

# Return type is Unit
func printName(name) {
    PrintLine(name);
}
```

### Function call

```go
result := add(3, 4);
```

### Comparison operators

```go
# > < >= <= == !=

if (x > y) {
    PrintLine("x is greater than y");
}

if (a == b) {
    PrintLine("a is equal to b");
}
```

### Operations

```go
# Operations on numbers: + - * / // %
number := (1 + 2 * 3) / 2;              # number = 3.5

# Operations on arrays: +
arrConcat := [1, 2] + [3, 4];           # arrConcat = [1, 2, 3, 4]

# String operations: + *

strConcat := "Hello" + " " + "world!";  # strConcat = "Hello world!"
strRepeat := "Hello" * 3;               # strRepeat = "HelloHelloHello"
```

## Basic types

The Wuzh language supports the following types:

- `Unit`: Empty type, void analog
- `Integer`
- `Double`
- `String`
- `Boolean`
- `Array`
- `Dictionary`
- `Any`: Auto-detects type in variables, means any type in function parameters and return type

## Standard library

List of functions in the standard library: [StdLib/](https://github.com/Aristocrab/Wuzh/blob/main/Wuzh/StandardLibrary/)
