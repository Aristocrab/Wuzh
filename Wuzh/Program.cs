using Wuzh;

string input;

if(args.Length == 0)
{
    input = 
    """
    a := "Usage: wuzh.exe <file>";
    Print(a);
    """;
}
else
{
    var file = args[0];

    if (File.Exists(file))
    {
        input = File.ReadAllText(file);
    }
    else
    {
        input =
        $"""
        filename := "{file}";
        PrintLine("Error: file '" + filename + "' was not found.");
        """;
    }
}

<<<<<<< Updated upstream:Moist/Program.cs
var interpreter = new MoistInterpreter(input);
=======
#if DEBUG

input = """

dict := {
    "a": 1,
    "b": 2,
    "c": 3,
    "d": 4,
};

dict["a"] = 5;
dict["e"] = 6;

PrintLine(dict);

""";

#endif

var interpreter = new WuzhInterpreter(input, file);
>>>>>>> Stashed changes:Wuzh/Program.cs
interpreter.Run();