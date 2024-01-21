using Godot;
using System;

public partial class PauseButton : Button
{
	private bool paused = false;
	private StartupScript script = new StartupScript{};
	public void _on_pressed()
	{
		if(paused)
		{
			GetTree().Paused = false;
			paused = false;
		}
		else
		{
			GetTree().Paused = true;
			paused = true;
		}
	}
}
