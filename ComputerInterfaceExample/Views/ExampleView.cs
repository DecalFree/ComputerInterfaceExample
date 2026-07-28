using System;
using System.Text;
using ComputerInterface.Enumerations;
using ComputerInterface.Extensions;
using ComputerInterface.Interfaces;
using ComputerInterface.Models;

namespace ComputerInterfaceExample.Views;

// A selectable entry on the MainMenuView.
// Entries are automatically detected by ComputerInterface.
public class ExampleViewEntry : IComputerViewEntry {
    // The name of the entry that will be shown.
    public string EntryName => "Example";

    // The first view that the user is going to see when selecting your entry.
    public Type EntryComputerView => typeof(ExampleView);
}

public class ExampleView : ComputerView {
    // This function is completely optional now due to text for a ComputerView now automatically being updated when switching views.
    // An example this can be used for is setting a UITextInputHandler's text to 'string.Empty' when the view is shown.
    public override void OnViewShown(object[] arguments) {
    }

    // This method is NEEDED as it handles the text that will be on the computer's screen.
    protected override string GetViewText() {
        // A StringBuilder is usually made for easy text making.
        StringBuilder stringBuilder = new StringBuilder();

        // Uses the top of the screen to showoff what tab you are currently on.
        stringBuilder.BeginCenter().Repeat("=", ScreenWidth).AppendLine();
        stringBuilder.Append("Example Tab").AppendLine();
        stringBuilder.Repeat("=", ScreenWidth).EndAlign().AppendLines(2);

        // Makes text below the "titlebar".
        stringBuilder.AppendLine("Computer Interface Example!");

        return stringBuilder.ToString();
    }

    // When a button on the keyboard is pressed, the button pressed is sent back as a parameter to be used.
    public override void OnButtonPressed(EKeyboardButton pressedButton) {
        switch (pressedButton) {
            case EKeyboardButton.Back:
                // 'ReturnToMainMenu()' is used to return to the MainMenuView.
                ReturnToMainMenu();
                break;
            case EKeyboardButton.Option1:
                // 'ShowView<TargetView>()' can be used to switch to another view.
                ShowView<ExampleHelpView>();
                break;
        }
    }
}