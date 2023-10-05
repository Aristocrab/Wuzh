using System.Globalization;
using Antlr4.Runtime;
using Moist.Exceptions;

namespace Moist;

public class MoistInterpreter
{
    private readonly bool _debug;
    private readonly MoistVisitor _visitor = null!;
    private readonly MoistParser.ProgramContext _programContext = null!;
    private readonly bool _error;

    public MoistInterpreter(string input, bool debug = false)
    {
        _debug = debug;
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

            if (_debug) throw;
        }
    }
    
    public void Run()
    {
        if (_error) return;
        
        try
        {
            _visitor.VisitProgram(_programContext);
        }
        catch (InterpreterException e)
        {
            Console.WriteLine(e.Message);

            if (_debug) throw;
        }
    }
}