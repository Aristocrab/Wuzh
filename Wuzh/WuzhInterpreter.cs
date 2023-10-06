using System.Globalization;
using Antlr4.Runtime;
<<<<<<< Updated upstream:Moist/MoistInterpreter.cs
using Moist.Exceptions;
=======
using Wuzh.ErrorListeners;
using Wuzh.Exceptions;
>>>>>>> Stashed changes:Wuzh/WuzhInterpreter.cs

namespace Wuzh;

public class WuzhInterpreter
{
    private readonly bool _debug;
    private readonly WuzhVisitor _visitor = null!;
    private readonly WuzhParser.ProgramContext _programContext = null!;
    private readonly bool _error;

<<<<<<< Updated upstream:Moist/MoistInterpreter.cs
    public MoistInterpreter(string input, bool debug = false)
=======
    public WuzhInterpreter(string input, string filename, bool debug = false)
>>>>>>> Stashed changes:Wuzh/WuzhInterpreter.cs
    {
        _debug = debug;
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        
        try
        {
            var inputStream = new AntlrInputStream(input);

            var lexer = new WuzhLexer(inputStream);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new LexerErrorListener(input));

            var commonTokenStream = new CommonTokenStream(lexer);
<<<<<<< Updated upstream:Moist/MoistInterpreter.cs

            var parser = new MoistParser(commonTokenStream);
=======
            
            var parser = new WuzhParser(commonTokenStream);
>>>>>>> Stashed changes:Wuzh/WuzhInterpreter.cs
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ParserErrorListener(input));

            _programContext = parser.program();
<<<<<<< Updated upstream:Moist/MoistInterpreter.cs
            _visitor = new MoistVisitor(input);
=======
            _visitor = new WuzhVisitor(input, filename);
>>>>>>> Stashed changes:Wuzh/WuzhInterpreter.cs
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