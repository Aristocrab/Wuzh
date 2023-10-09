using FluentAssertions;

namespace Wuzh.Tests;

public class WuzhExamplesTests
{
    [Fact]
    public void Input_HelloWorld_ShouldNotThrow()
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
    public void Input_Factorial_ShouldNotThrow()
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
    public void Input_Brainfuck_ShouldNotThrow()
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
    public void Input_AllConstructions_ShouldNotThrow()
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
    public void Input_Morse_ShouldNotThrow()
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
    public void Input_Morse2_ShouldNotThrow()
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
    public void Input_StandardLibraryCall_ShouldNotThrow() 
    {
        // Arrange
        const string input = """
        # Create an array of size 5 with default value "Hello"
        arr := Arr(5, "Hello");

        # Append a new value to the array
        Append(arr, "World");

        # Set the value at index 2 to 42
        SetValue(arr, 2, 42);

        # Remove the element at index 1
        Remove(arr, 1);

        # Clear the array
        Clear(arr);

        # Get the length of the array and print it
        length := Length(arr);
        PrintLine("Array length: " + length);

        # Print a line with values
        PrintLine("Hello", "World!");

        # Print an empty line
        PrintLine();

        # Print without a new line
        Print("This is", "Wuzh.");

        # Create a dictionary
        dict := {
            "Name": "John",
            "Age": 30,
            "City": "New York"
        };

        # Check if the dictionary contains a key
        containsKey := Contains(dict, "Age");
        if (containsKey)
        {
            PrintLine("The dictionary contains the key 'Age'.");
        }
        else
        {
            PrintLine("The dictionary does not contain the key 'Age'.");
        }

        # Get the keys from the dictionary
        keys := GetKeys(dict);
        PrintLine("Keys: " + keys);

        # Get the values from the dictionary
        values := GetValues(dict);
        PrintLine("Values: " + values);

        t := TypeOf(dict);
        Sleep(0);

        zz := Pow(2, 3);

        stlLen := Length("Hello");

        # Convert between types using TypeConvertFunctions

        # Convert an integer to a string
        intVal := 42;
        strVal := IntToString(intVal);
        PrintLine("Integer to String: " + strVal);

        # Convert a string to an integer
        strNum := "123";
        intNum := StringToInt(strNum);
        PrintLine("String to Integer: " + intNum);

        # Convert a character to its ASCII code
        charVal := "A";
        asciiCode := AsciiCode(charVal);
        PrintLine("Character to ASCII Code: " + asciiCode);

        # Convert an integer to a double
        intDouble := 42;
        doubleVal := IntToDouble(intDouble);
        PrintLine("Integer to Double: " + doubleVal);

        # Convert a double to an integer
        doubleInt := 3.14;
        intFromDouble := DoubleToInt(doubleInt);
        PrintLine("Double to Integer: " + intFromDouble);

        # Convert an object to a string
        obj := intVal;
        strObj := ToString(obj);
        PrintLine("Object to String: " + strObj);

        PrintLine("Concatted array: "+ ([1] + [2]));
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().NotThrow();
    }
}