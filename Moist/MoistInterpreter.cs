using System.Globalization;
using Antlr4.Runtime;
using Moist.Exceptions;

namespace Moist;

public class MoistInterpreter
{
    private readonly MoistVisitor _visitor;
    private readonly MoistParser.ProgramContext _programContext;

    public MoistInterpreter(string input)
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        
        var inputStream = new AntlrInputStream(input);
        var moistLexer = new MoistLexer(inputStream);

        var commonTokenStream = new CommonTokenStream(moistLexer);

        var moistParser = new MoistParser(commonTokenStream);
        _programContext = moistParser.program();

        _visitor = new MoistVisitor(input);
    }
    
    public void Run(bool debug = false)
    {
        try
        {
            _visitor.VisitProgram(_programContext);

            if (debug)
            {
                _visitor.DumpVariables();
                Console.WriteLine();
                _visitor.DumpFunctions();
            }
        }
        catch (ParserException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}