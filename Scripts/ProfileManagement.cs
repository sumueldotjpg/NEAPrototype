using Godot;
using System;
using System.Collections.Specialized;
using Variables;
using Main;

public partial class ProfileManagement : Control
{
	[Export]
	public Button ButtonProfile1;
	[Export]
	public Button ButtonProfile2;
	[Export]
	public Button ButtonProfile3;
	[Export]
	public Button ButtonProfile4;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SaveManager.LoadProfiles();

		ButtonProfile1.Text = AllObjects.allProfiles[0].Title;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_profile_1_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/GlobeScene.tscn");
	}
}
