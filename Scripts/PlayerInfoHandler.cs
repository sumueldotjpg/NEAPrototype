using Godot;
using System;
using Variables;

public partial class PlayerInfoHandler : RichTextLabel
{
	[Export]
	RichTextLabel playerLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		playerLabel.Text=
		$"Stats:\n" +
		$"Balance: {AllObjects.CurrentProfile.MoneyBalance}\n" +
		$"Next POI's to unlock:";
	}
}
