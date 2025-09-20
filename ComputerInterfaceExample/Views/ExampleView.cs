using System;
using System.Text;
using ComputerInterface;
using ComputerInterface.Extensions;
using ComputerInterface.Interfaces;
using ComputerInterface.ViewLib;

namespace ComputerInterfaceExample.Views;

// A selectable entry on the MainMenuView.
// Entries are automatically detected by ComputerInterface.
public class ExampleViewEntry : IComputerModEntry {
    // The name of the entry that will be shown.
    public string EntryName => "Example";
    
    // The first view that the user is going to see when selecting your entry.
    public Type EntryViewType => typeof(ExampleView);
}

public class ExampleView : ComputerView {
    // Called when the view is opened by the user.
    public override void OnShow(object[] args) {
        base.OnShow(args);
        
        // A 'Redraw' method is usually made for easier reading.
        Redraw();
    }
    
    // The method that usually handles the text on the screen.
    private void Redraw() {
        // A StringBuilder is usually made for easy text making.
        var stringBuilder = new StringBuilder();
        
        // Uses the top of the screen to showoff what tab you are currently on.
        stringBuilder.BeginCenter().Repeat("=", SCREEN_WIDTH).AppendLine();
        stringBuilder.Append("Example Tab").AppendLine();
        stringBuilder.Repeat("=", SCREEN_WIDTH).EndAlign().AppendLines(2);
        
        // Makes text below the "titlebar".
        stringBuilder.AppendLine("Computer Interface Example!");
        
        Text = stringBuilder.ToString();
    }

    // When a key on the keyboard is pressed, the key pressed is sent back as a parameter to be used.
    public override void OnKeyPressed(EKeyboardKey key) {
        switch (key) {
            case EKeyboardKey.Back:
                // 'ReturnToMainMenu();' is used to return to the MainMenuView.
                // 'ShowView<ViewToShow>();' can be used to switch to another view.
                ReturnToMainMenu();
                break;
        }
    }
}