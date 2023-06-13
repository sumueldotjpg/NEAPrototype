using Godot;
using System;

public partial class ConsoleInputHandler : LineEdit
{
	private RichTextLabel consoleRichTextLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		consoleRichTextLabel = GetNode<RichTextLabel>("ConsoleRichTextLabel");
		consoleRichTextLabel.PushColor(new Color(0, 255, 0, 1));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent)
		{
			if (keyEvent.Pressed && keyEvent.Keycode == Key.Enter)
			{
				InputResponse(this.Text);
			}
		}
	}
	private void InputResponse(string input)
	{
		switch(input)
		{
			case "":
				break;
			case "hello":
				OutputToConsole("Hello World");
				break;
			default:
				OutputToConsole("That isnt a command.");
				break;
		}
	}
	private void OutputToConsole(string text)
	{
		consoleRichTextLabel.AddText("\n" + text);
	}
}
