using Moist;

string input;

if(args.Length == 0)
{
    input = 
    """
    arr := [1, 2, 3, 4, 5];
    for (item in arr) {
        PrintLine(item);
    }

    str := "Hello, world!";
    for (c in str) {
        PrintLine(c);
    }
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
        filename := "{file}"
        PrintLine("Error: file '" + filename + "' was not found.");
        """;
    }
}

var interpreter = new MoistInterpreter(input);
interpreter.Run(false);