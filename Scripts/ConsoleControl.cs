using Godot;
using System;

public partial class ConsoleControl : Control
{
	private RichTextLabel consoleOutput;
	private LineEdit inputLine;

	public override void _Ready()
	{
		consoleOutput = GetNode<RichTextLabel>("ConsoleRichTextLabel");
		inputLine = GetNode<LineEdit>("ConsoleLineEdit");
		inputLine.GrabFocus();
	}

	private void ClearConsole()
	{
		consoleOutput.Clear();
	}

	private void PrintToConsole(string message)
	{
		consoleOutput.Text += message + "\n";
		consoleOutput.ScrollToLine(consoleOutput.GetLineCount());
	}

	private void ProcessConsoleInput(string command)
	{
		PrintToConsole("> " + command);
		// Process the command and execute desired functionality
		// You can add your own logic here to handle different commands
		// For example, if the command is "help", you can print a list of available commands
	}

	private void OnInputLineTextEntered(string text)
	{
		ProcessConsoleInput(text);
		inputLine.Clear();
	}
}
