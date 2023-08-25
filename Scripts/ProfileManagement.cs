using Godot;
using System;
using Variables;

public partial class ProfileManagement : Control
{
	Button ButtonProfile1 = null;
	Button ButtonProfile2 = null;
	Button ButtonProfile3 = null;
	Button ButtonProfile4 = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ButtonProfile1 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile1");
		ButtonProfile2 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile2");
		ButtonProfile3 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile3");
		ButtonProfile4 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile4");

		ButtonProfile1.Text =  $"{AllObjects.allProfiles[0]}";
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
