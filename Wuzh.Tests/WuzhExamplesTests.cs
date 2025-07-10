using Shouldly;

namespace Wuzh.Tests;

public class WuzhExamplesTests
{
    [Fact]
    public void Input_Examples_ShouldNotThrow()
    {
        // Arrange
        var examplesFolder = Path.Combine("../../../../", "Examples");
        var files = Directory.GetFiles(examplesFolder, "*.wuzh");
        
        // Act
        var action = () =>
        {
            foreach (var file in files)
            {
                var input = File.ReadAllText(file);
                var interpreter = new WuzhInterpreter(input, file, debug: true);
                interpreter.Run();
            }
        };
        
        // Assert
        action.ShouldNotThrow();
    }
    
    [Fact]
    public void Input_HelloWorld_ShouldNotThrow()
    {
        // Arrange
        const string input = """
        PrintLine("Hello, world!");
        """;
        var interpreter = new WuzhInterpreter(input, "", debug: true);
        
        // Act
        var action = () => interpreter.Run();
        
        // Assert
        action.ShouldNotThrow();
    }
}