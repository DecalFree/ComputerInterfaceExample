using ComputerInterface;

namespace ComputerInterfaceExample;

public class ExampleCommandManager {
    private CommandHandler _commandHandler;
    
    public void Initialize() {
        // Request the CommandHandler.
        _commandHandler = ComputerInterface.Plugin.CommandHandler;

        RegisterCommands();
    }

    private void RegisterCommands() {
        // Register your commands.
        
        // You can set 'argumentTypes' to null if you aren't going to have any.
        _commandHandler.AddCommand(new Command(name: "monke", argumentTypes: null, arguments => {
            // Arguments are an array of strings passed when entering the command.
            // The CommandHandler already checks if the correct amount of arguments is passed.
            
            // The string you return is going to be shown in the terminal as a return message.
            // You can break up the message into multiple lines by using '\n'
            return "MONKE";
        }));
        
        // A somewhat more advanced command.
        _commandHandler.AddCommand(new Command(name: "color", argumentTypes: [typeof(float), typeof(float), typeof(float)], arguments => {
            var r = (float)arguments[0];
            var g = (float)arguments[1];
            var b = (float)arguments[2];

            if (r > 0)
                r /= 255;
            if (g > 0)
                g /= 255;
            if (b > 0)
                b /= 255;
            
            return $"Color:\n\nR: {r} ({arguments[0]})\nG: {g} ({arguments[1]})\nB: {b} ({arguments[2]})";
        }));
    }
}