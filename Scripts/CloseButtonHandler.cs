using Godot;
using System;

public partial class CloseButtonHandler : Button
{
	public override void _Ready()
	{
		Connect("pressed", new Callable(this, nameof(OnButtonPressed)));
	}

	public void OnButtonPressed()
	{
		GetTree().Quit();
	}
}
