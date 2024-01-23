using Godot;
using System;
using System.Collections.Specialized;
using Variables;
using Main;
using System.Diagnostics;

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
		MainCreation.Load();

		ButtonProfile1.Text = AllObjects.allProfiles[0].Title;
		ButtonProfile2.Text = AllObjects.allProfiles[1].Title;
		ButtonProfile3.Text = AllObjects.allProfiles[2].Title;
		ButtonProfile4.Text = AllObjects.allProfiles[3].Title;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_profile_1_pressed()
	{
		AllObjects.SetCurrentProfile(AllObjects.allProfiles[0]);
		GetTree().ChangeSceneToFile("res://Scenes/GlobeScene.tscn");
	}
	private void _on_button_profile_2_pressed()
	{
		AllObjects.SetCurrentProfile(AllObjects.allProfiles[1]);
		GetTree().ChangeSceneToFile("res://Scenes/GlobeScene.tscn");
	}
	private void _on_button_profile_3_pressed()
	{
		AllObjects.SetCurrentProfile(AllObjects.allProfiles[2]);
		GetTree().ChangeSceneToFile("res://Scenes/GlobeScene.tscn");
	}
	private void _on_button_profile_4_pressed()
	{
		AllObjects.SetCurrentProfile(AllObjects.allProfiles[3]);
		GetTree().ChangeSceneToFile("res://Scenes/GlobeScene.tscn");
	}
	private void _on_button_delete_profile_1_pressed()
	{
		AllObjects.DeleteProfile(AllObjects.allProfiles[0]);
		GD.Print(AllObjects.allProfiles[0].Title);
	}
	private void _on_button_delete_profile_2_pressed()
	{
		AllObjects.DeleteProfile(AllObjects.allProfiles[1]);
	}
	private void _on_button_delete_profile_3_pressed()
	{
		AllObjects.DeleteProfile(AllObjects.allProfiles[2]);
	}
	private void _on_button_delete_profile_4_pressed()
	{
		AllObjects.DeleteProfile(AllObjects.allProfiles[3]);
	}
}
