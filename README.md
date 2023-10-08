# Wuzh language

[![Generic badge](https://img.shields.io/badge/release-0.3-blue.svg)](https://shields.io/)

```wuzh
func HelloWorld() {
    PrintLine("Hello, world!");
}

HelloWorld();
```

## Contents

- [Files](#files)
- [Examples](#examples)
- [Syntax](#syntax)
    - [Variables and constants](#variables-and-constants)
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

`wuzh.exe` - interpreter

`*.wuzh` - file extensions

## Examples

- [Examples/](https://github.com/Aristocrab/wuzh/tree/main/Examples)
    - [helloworld.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/helloworld.wuzh)
    - [factorial.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/factorial.wuzh)
    - [brainfuck.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/brainfuck.wuzh)
    - [morse.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/morse.wuzh)
    - [syntaxExample.wuzh](https://github.com/Aristocrab/wuzh/blob/main/Examples/syntaxExample.wuzh)

## Syntax

### Variables and constants

```wuzh
const x := 42;
y := 3.14;
```

### Assignment

```wuzh
x = 21 * 2;
```

### Basic types

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

### Type hinting

```wuzh
String str := "string";

func Function(Int a, b) -> Int {
    return a * b;
}
```

### Indexing

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

# Index assignment
arr[0] = 3;
str[0] = "B";
dict["name"] = "Bob";
dict["height"] = "180cm";
```

### If statement

```wuzh
if (x > 30) {
    PrintLine("x is greater than 30");
} else {
    PrintLine("x is less than or equal to 30");
}
```

### While loop

```wuzh
while (x > 0) {
    PrintLine(x);
    x = x - 1;
}
```

### For loop

```wuzh
for (i := 0, i < 5, i = i + 1) {
    PrintLine(i);
}
```

#### For(each) loop

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

### Function declaration

```wuzh
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

```wuzh
result := add(3, 4);
```

### Comparison operators

```wuzh
# > < >= <= == !=

if (x > y) {
    PrintLine("x is greater than y");
}

if (a == b) {
    PrintLine("a is equal to b");
}
```

### Operations

```wuzh
# Operations on numbers
+ - * / // %

# String operations
+ *

strConcat := "Hello" + " " + "world!"; # strConcat = "Hello world!"
strRepeat := "Hello" * 3;              # strRepeat = "HelloHelloHello"
```

## Basic types

The Wuzh language supports the following types:

- `Unit`: Empty type
- `Integer`: Integer
- `Double`: Double
- `String`: String
- `Boolean`: Boolean
- `Array`: Array
- `Dictionary`: Dictionary
- `Any`: Auto-detects type in variables, any in functions

## Standard library

List of functions in the standard library: [StdLib/](https://github.com/Aristocrab/Wuzh/blob/main/Wuzh/StandardLibrary/);
