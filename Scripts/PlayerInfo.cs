using Godot;
using System;

public partial class PlayerInfo : Control
{
	[Export]
	RichTextLabel playerLabel;
	
	public override void _Ready()
	{
		Timings();
	}

	public void Timings()
	{
		playerLabel.Text = "";
	}
}
