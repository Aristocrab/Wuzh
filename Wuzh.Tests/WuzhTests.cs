using FluentAssertions;
using Wuzh.Exceptions;

namespace Wuzh.Tests;

public class WuzhTests
{
    [Fact]
    public void Test_HelloWorld()
    {
        // Arrange
        const string input = """
        PrintLine("Hello, world!");
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_Recursion()
    {
        // Arrange
        const string input = """
        # Recursive factorial function
        func factorial(n) {
            if (n <= 1) {
                return 1;
            } else {
                return n * factorial(n - 1);
            }
        }

        # Calculate and print the factorial of 5
        result := factorial(5);
        PrintLine("Factorial of 5 is: " + result);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_Brainfuck()
    {
        // Arrange
        const string input = """
        func runBrainfuck(code) {
            memory := Arr(3000, 0);
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
                    Print(IntAsAscii(memory[pointer]));
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
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_AllConstructions()
    {
        // Arrange
        const string input = """
        PrintLine("Hello, world!");

        a := "Hello";
        PrintLine(a + "!");

        if(false) {
            PrintLine(1);
        }
        else {
            PrintLine(2);
        }

        b := 5;
        while(b > 0) {
            PrintLine(b);
            b = b - 1;
        }

        for(c := 0, c <= 10, c = c + 1) {
            PrintLine(c * c);
        }

        for(z in [1, 2, 3]) {
            PrintLine(z);
        }

        func PrintName(name) {
            PrintLine(name);
        }

        PrintName("Bob");

        PrintLine(TypeOf(a));
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_Morse()
    {
        // Arrange
        const string input = """
        func Split(input, delimiter) {
        parts := [];
        currentPart := "";

        i := 0;
        char := " ";
        while (i < Length(input)) {
          char = input[i];
          if (char == delimiter) {
              if (Length(currentPart) > 0) {
                  Append(parts, currentPart);
              }
              currentPart = "";
          } else {
              currentPart = currentPart + char;
          }
          i = i + 1;
        }

        if (Length(currentPart) > 0) {
          Append(parts, currentPart);
        }

        return parts;
        }

        # Function to decode Morse code
        func decodeMorseCode(morseCode) {
         words := Split(morseCode, "   ");
         word := " ";
         decodedMessage := "";

         char := " ";

         for (word in words) {
             chars := Split(word, " ");  # Split word into characters
             decodedWord := "";

             for (char in chars) {
                 if (char == ".-") {
                     decodedWord = decodedWord + "A";
                 }
                  if (char == "-...") {
                     decodedWord = decodedWord + "B";
                 }
                  if (char == "-.-.") {
                     decodedWord = decodedWord + "C";
                 }
                  if (char == "-..") {
                     decodedWord = decodedWord + "D";
                 }
                  if (char == ".") {
                     decodedWord = decodedWord + "E";
                 }
                  if (char == "..-.") {
                     decodedWord = decodedWord + "F";
                 }
                  if (char == "--.") {
                     decodedWord = decodedWord + "G";
                 }
                  if (char == "....") {
                     decodedWord = decodedWord + "H";
                 }
                  if (char == "..") {
                     decodedWord = decodedWord + "I";
                 }
                  if (char == ".---") {
                     decodedWord = decodedWord + "J";
                 }
                  if (char == "-.-") {
                     decodedWord = decodedWord + "K";
                 }
                  if (char == ".-..") {
                     decodedWord = decodedWord + "L";
                 }
                  if (char == "--") {
                     decodedWord = decodedWord + "M";
                 }
                  if (char == "-.") {
                     decodedWord = decodedWord + "N";
                 }
                  if (char == "---") {
                     decodedWord = decodedWord + "O";
                 }
                  if (char == ".--.") {
                     decodedWord = decodedWord + "P";
                 }
                  if (char == "--.-") {
                     decodedWord = decodedWord + "Q";
                 }
                  if (char == ".-.") {
                     decodedWord = decodedWord + "R";
                 }
                  if (char == "...") {
                     decodedWord = decodedWord + "S";
                 }
                  if (char == "-") {
                     decodedWord = decodedWord + "T";
                 }
                  if (char == "..-") {
                     decodedWord = decodedWord + "U";
                 }
                  if (char == "...-") {
                     decodedWord = decodedWord + "V";
                 }
                  if (char == ".--") {
                     decodedWord = decodedWord + "W";
                 }
                  if (char == "-..-") {
                     decodedWord = decodedWord + "X";
                 }
                  if (char == "-.--") {
                     decodedWord = decodedWord + "Y";
                 }
                  if (char == "--..") {
                     decodedWord = decodedWord + "Z";
                 }
                  if (char == "-----") {
                     decodedWord = decodedWord + "0";
                 }
                  if (char == ".----") {
                     decodedWord = decodedWord + "1";
                 }
                  if (char == "..---") {
                     decodedWord = decodedWord + "2";
                 }
                  if (char == "...--") {
                     decodedWord = decodedWord + "3";
                 }
                  if (char == "....-") {
                     decodedWord = decodedWord + "4";
                 }
                  if (char == ".....") {
                     decodedWord = decodedWord + "5";
                 }
                  if (char == "-....") {
                     decodedWord = decodedWord + "6";
                 }
                  if (char == "--...") {
                     decodedWord = decodedWord + "7";
                 }
                  if (char == "---..") {
                     decodedWord = decodedWord + "8";
                 }
                  if (char == "----.") {
                     decodedWord = decodedWord + "9";
                 }
                 else {
                     decodedWord = decodedWord + " ";
                 }
             }

             decodedMessage = decodedMessage + decodedWord + " ";
         }

         return decodedMessage;
        }

        morseMessage := "... --- ...";
        decodedMessage := decodeMorseCode(morseMessage);

        PrintLine("Initial message: " + morseMessage);
        PrintLine("Decoded message: " + decodedMessage);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_Morse2()
    {
        // Arrange
        const string input = """
        # Define a dictionary to map Morse code to letters and numbers
        morseToChar := {
            ".-" : "A",
            "-..." : "B",
            "-.-." : "C",
            "-.." : "D",
            "." : "E",
            "..-." : "F",
            "--." : "G",
            "...." : "H",
            ".." : "I",
            ".---" : "J",
            "-.-" : "K",
            ".-.." : "L",
            "--" : "M",
            "-." : "N",
            "---" : "O",
            ".--." : "P",
            "--.-" : "Q",
            ".-." : "R",
            "..." : "S",
            "-" : "T",
            "..-" : "U",
            "...-" : "V",
            ".--" : "W",
            "-..-" : "X",
            "-.--" : "Y",
            "--.." : "Z",
            "-----" : "0",
            ".----" : "1",
            "..---" : "2",
            "...--" : "3",
            "....-" : "4",
            "....." : "5",
            "-...." : "6",
            "--..." : "7",
            "---.." : "8",
            "----." : "9"
        };

        # Function to split a string based on a delimiter
        func Split(input, delimiter) {
            parts := [];
            currentPart := "";

            for (char in input) {
                if (char == delimiter) {
                    if (Length(currentPart) > 0) {
                        Append(parts, currentPart);
                    }
                    currentPart = "";
                } else {
                    currentPart = currentPart + char;
                }
            }

            if (Length(currentPart) > 0) {
                Append(parts, currentPart);
            }

            return parts;
        }

        # Function to decode Morse code
        func decodeMorseCode(morseCode) {
            words := Split(morseCode, "   ");
            decodedMessage := "";

            for (word in words) {
                chars := Split(word, " ");  # Split word into characters
                decodedWord := "";

                for (char in chars) {
                    if (Contains(morseToChar, char)) {
                        decodedWord = decodedWord + morseToChar[char];
                    } else {
                        decodedWord = decodedWord + " ";
                    }
                }

                decodedMessage = decodedMessage + decodedWord + " ";
            }

            return decodedMessage;
        }

        morseMessage := "... --- ...";
        decodedMessage := decodeMorseCode(morseMessage);

        PrintLine("Initial message: " + morseMessage);
        PrintLine("Decoded message: " + decodedMessage);

        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_UnrecognizedToken()
    {
        // Arrange
        const string input = """
        a ::= 5;
        PrintLine(a);
        """;
        
        // Act
        var action = () => new WuzhInterpreter(input, "", debug: true);
        
        // Assert
        action.Should().Throw<ParserException>();
    }
    
    [Fact]
    public void Test_ExpectedTokenNotFound()
    {
        // Arrange
        const string input = """
        a := 5
        PrintLine(a);
        """;
        
        // Act
        var action = () => new WuzhInterpreter(input, "", debug: true);
        
        // Assert
        action.Should().Throw<ParserException>();
    }
    
    [Fact]
    public void Test_CantChangeConst()
    {
        // Arrange
        const string input = """
        const a := 5;
        a = 1;
        """;
        var interpreter =  new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_UndefinedVariable()
    {
        // Arrange
        const string input = """
        b = 10;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }

    [Fact]
    public void Test_DivideByZero()
    {
        // Arrange
        const string input = """
        const a := 5;
        const b := 0;
        c := a / b;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(100)]
    public void Test_IndexOutOfRange(int index)
    {
        // Arrange
        var input = $"""
        const str := "Hello";
        PrintLine(str[{index}]);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_ErrorCallingUndefinedFunction()
    {
        // Arrange
        const string input = """
        const x := 5;
        const result := UndefinedFunction(x);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_ErrorCallingFunctionWithWrongArgumentsCount()
    {
        // Arrange
        const string input = """
        func f(a, b) {
            return a + b;
        }
        const result := f(1);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_CantRedeclareVariable()
    {
        // Arrange
        const string input = """
        a := 5;
        a := 10;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_CantRedeclareFunctionWithSameArgumentsCount()
    {
        // Arrange
        const string input = """
        func f(a, b) {
            return a + b;
        }
        
        func f(d, e) {
            return d - e;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_CantRedeclareFunctionWithSameArgumentsNameAndCount()
    {
        // Arrange
        const string input = """
        func f(a, b) {
            return a + b;
        }
        
        func f(a, b) {
            return a - b;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_CantUseMinusOperatorWithStrings() 
    {
        // Arrange
        const string input = """
        a := -"Hello";
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_HintedTypes() 
    {
        // Arrange
        const string input = """
        Int a := 5;
        Double b := 5.0;
        Bool c := true;
        String d := "Hello";
        Array e := [1, 2];
        Dict f := {"a": 1};
        Dictionary g := {"a": 1};
        
        Any anyA := a;
        Any anyB := b;
        Any anyC := c;
        Any anyD := d;
        Any anyE := e;
        Any anyF := f;
        Any anyG := g;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Test_FunctionParameterTypesCanNotOverlap() 
    {
        // Arrange
        const string input = """
        func f(a, Int b) {
            return a + b;
        }
        
        func f(Int a, b) {
            return a - b;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Test_FunctionParameterTypesCanNotOverlapWithDifferentTypes() 
    {
        // Arrange
        const string input = """
        func f(a, Int b) {
            return a + b;
        }
        
        func f(Double a, b) {
            return a - b;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
}