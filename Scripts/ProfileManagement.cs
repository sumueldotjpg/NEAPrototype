using Godot;
using System;
using System.Collections.Specialized;
using Variables;

public partial class ProfileManagement : Control
{
	public Button ButtonProfile1;
	Button ButtonProfile2;
	Button ButtonProfile3;
	Button ButtonProfile4;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ButtonProfile1 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile1");
		GD.Print("First" + ButtonProfile1);
		ButtonProfile2 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile2");
		ButtonProfile3 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile3");
		ButtonProfile4 = GetNode<Button>("MarginContainer/PanelContainer/VBoxContainer/HBoxContainer/ButtonProfile4");
	}

	public void DisplayProfiles()
	{
		PackedScene MainMenuScene = (PackedScene)GD.Load("res://Scenes/MainMenuScene.tscn");
		MainMenuScene.Instantiate();
		Script ProfileManagementScript = (Script)ResourceLoader.Load("res://Scripts/ProfileManagement.cs");
		//need to SetScript(ProfileManagmentScript) on the Profiles Control Node somehow

		GD.Print(ButtonProfile1);
		GD.Print(AllObjects.allProfiles[0].Title);
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
