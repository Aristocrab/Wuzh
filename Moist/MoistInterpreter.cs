using System.Globalization;
using Antlr4.Runtime;
using Moist.Exceptions;

namespace Moist;

public class MoistInterpreter
{
    private readonly MoistVisitor _visitor;
    private readonly MoistParser.ProgramContext _programContext;
    private bool _error = false;

    public MoistInterpreter(string input)
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        
        try
        {
            var inputStream = new AntlrInputStream(input);

            var lexer = new MoistLexer(inputStream);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new LexerErrorListener(input));

            var commonTokenStream = new CommonTokenStream(lexer);

            var parser = new MoistParser(commonTokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ParserErrorListener(input));

            _programContext = parser.program();
            _visitor = new MoistVisitor(input);
        }
        catch (Exception e)
        {
            _error = true;
            Console.WriteLine(e.Message);
        }
    }
    
    public void Run(bool debug = false)
    {
        if (_error) return;
        
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
        catch (InterpreterException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}