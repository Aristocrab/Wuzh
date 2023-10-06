using System.Globalization;
using Antlr4.Runtime;
using Wuzh.ErrorListeners;
using Wuzh.Exceptions;

namespace Wuzh;

public class WuzhInterpreter
{
    private readonly bool _debug;
    private readonly WuzhVisitor _visitor = null!;
    private readonly WuzhParser.ProgramContext _programContext = null!;
    private readonly bool _error;

    public WuzhInterpreter(string input, string filename, bool debug = false)
    {
        _debug = debug;
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        
        try
        {
            var inputStream = new AntlrInputStream(input);
            var exceptionsFactory = new ExceptionsFactory(input, filename);

            var lexer = new WuzhLexer(inputStream);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new LexerErrorListener(input, exceptionsFactory));

            var commonTokenStream = new CommonTokenStream(lexer);
            
            var parser = new WuzhParser(commonTokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ParserErrorListener(input, exceptionsFactory));
            
            _programContext = parser.program();
            _visitor = new WuzhVisitor(input, filename);
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            if (_debug) throw;
        }
    }
}