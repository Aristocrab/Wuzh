using FluentAssertions;
using Wuzh.Exceptions;

namespace Wuzh.Tests;

public class WuzhTests
{
    [Fact]
    public void Input_Variables_ShouldNotThrow() 
    {
        // Arrange
        const string input = """
        a := 2;
        b := 3;
        PrintLine(a + b);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Input_IntDigitSeparators_ShouldNotThrow() 
    {
        // Arrange
        const string input = """
        a := 1_000_000;
        b := 1000000;
        PrintLine(a == b);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Input_HintedTypes_ShouldNotThrow() 
    {
        // Arrange
        const string input = """
        Int a := 5;
        Double b := 5.0;
        Bool c := true;
        String d := "Hello";
        Array e := [1, 2];
        Dict f := {"a": 1};
        Dictionary g := {"a": 1};
        
        Any anyA := a;
        Any anyB := b;
        Any anyC := c;
        Any anyD := d;
        Any anyE := e;
        Any anyF := f;
        Any anyG := g;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Input_UnrecognizedToken_ShouldThrow()
    {
        // Arrange
        const string input = """
        a ::= 5;
        PrintLine(a);
        """;
        
        // Act
        var action = () => new WuzhInterpreter(input, "", debug: true);
        
        // Assert
        action.Should().Throw<ParserException>();
    }
    
    [Fact]
    public void Input_ExpectedTokenNotFound_ShouldThrow()
    {
        // Arrange
        const string input = """
        a := 5
        PrintLine(a);
        """;
        
        // Act
        var action = () => new WuzhInterpreter(input, "", debug: true);
        
        // Assert
        action.Should().Throw<ParserException>();
    }
    
    [Fact]
    public void Input_ConstChange_ShouldThrow()
    {
        // Arrange
        const string input = """
        const a := 5;
        a = 1;
        """;
        var interpreter =  new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_UndefinedVariable_ShouldThrow()
    {
        // Arrange
        const string input = """
        b = 10;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }

    [Fact]
    public void Input_DivideByZero_ShouldThrow()
    {
        // Arrange
        const string input = """
        const a := 5;
        const b := 0;
        c := a / b;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(100)]
    public void Input_IndexOutOfRange_ShouldThrow(int index)
    {
        // Arrange
        var input = $"""
        const str := "Hello";
        PrintLine(str[{index}]);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_UndefinedFunctionCall_ShouldThrow()
    {
        // Arrange
        const string input = """
        const x := 5;
        const result := UndefinedFunction(x);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_FunctionWithWrongArgumentsCountCall_ShouldThrow()
    {
        // Arrange
        const string input = """
        func f(a, b) {
            return a + b;
        }
        const result := f(1);
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_VariableRedeclaring_ShouldThrow()
    {
        // Arrange
        const string input = """
        a := 5;
        a := 10;
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_FunctionRedeclaring_ShouldThrow()
    {
        // Arrange
        const string input = """
        func f(a, b) {
            return a + b;
        }
        
        func f(d, e) {
            return d - e;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_FunctioWithSameArgumentsRedeclaring_ShouldThrow()
    {
        // Arrange
        const string input = """
        func f(a, b) {
            return a + b;
        }
        
        func f(a, b) {
            return a - b;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_MinusOperatorWithStrings_ShouldThrow() 
    {
        // Arrange
        const string input = """
        a := -"Hello";
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_FunctionParameterTypesCanNotOverlap_ShouldThrow() 
    {
        // Arrange
        const string input = """
        func f(a, Int b) {
            return a + b;
        }
        
        func f(Int a, b) {
            return a - b;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
    
    [Fact]
    public void Input_FunctionParameterTypesOverlapWithDifferentTypes_ShouldThrow() 
    {
        // Arrange
        const string input = """
        func f(a, Int b) {
            return a + b;
        }
        
        func f(Double a, b) {
            return a - b;
        }
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);

        // Act
        var action = () => interpreter.Run();

        // Assert
        action.Should().Throw<InterpreterException>();
    }
}