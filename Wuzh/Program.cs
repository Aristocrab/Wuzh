using Wuzh;

string input;

const string version = "0.3";
var file = "test.wuzh";

if(args.Length == 0)
{
    input = 
    """
    a := "Usage: wuzh.exe <file>";
    Print(a);
    """;
}
else if(args[0] == "-v" || args[0] == "--version")
{
    input = 
    $"""
    a := "Wuzh {version}";
    Print(a);
    """;
}
else
{
    file = args[0];

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

var interpreter = new WuzhInterpreter(input, file);
interpreter.Run();