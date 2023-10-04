using Moist;

string input;

if(args.Length == 0)
{
    input = 
    """
    a := "Usage: moist.exe <file>"
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

var interpreter = new MoistInterpreter(input);
interpreter.Run(false);