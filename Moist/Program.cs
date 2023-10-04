﻿using Moist;

string input;

// if(args.Length == 0)
// {
//     input = 
//     """
//     a := "Usage: moist.exe <file>"
//     Print(a);
//     """;
// }
// else
// {
//     var file = args[0];
//     input = File.ReadAllText(file);
// }

input = """
func compileBrainfuck(code) {
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

compileBrainfuck(">+++++++++[<++++++++>-]<.>+++++++[<++++>-]<+.+++++++..+++.>>>++++++++[<++++>-]<.>>>++++++++++[<+++++++++>-]<---.<<<<.+++.------.--------.>>+.>++++++++++.");
""";

var interpreter = new MoistInterpreter(input);
interpreter.Run(false);