using Godot;
using System.Collections.Generic;

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
				List<string> input = new List<string>((this.Text).Split(" "));
				InputResponse(input);
				this.Clear();
			}
		}
	}
	private void InputResponse(List<string> input)
	{
		switch (input[0].ToLower())
		{
			case "":
				break;
			case "hello":
				OutputToConsole(string.Join(" ", input), "Hello World");
				break;
			case "hack":
				if (input.Count == 2)
				{
					switch (input[1].ToLower())
					{
						case "google":
							OutputToConsole(string.Join(" ", input), "Hack RN");
							break;
						default:
							OutputToConsole(string.Join(" ", input),"That doesnt exist.");
							break;
					}
				}
				else
				{
					OutputToConsole(string.Join(" ", input), "What would you like to hack?");
				}
				break;
			default:
				OutputToConsole(string.Join(" ", input), "That isnt a command.");
				break;
		}
	}
	private void OutputToConsole(string input, string text)
	{
		consoleRichTextLabel.AddText("\n> " + input);
		consoleRichTextLabel.AddText("\n" + text);
	}
}
