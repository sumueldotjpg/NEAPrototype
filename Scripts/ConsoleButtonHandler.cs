using Godot;
using System;

public partial class ConsoleButtonHandler : Button
{
	public override void _Ready()
	{
		Connect("pressed", new Callable(this, nameof(OnButtonPressed)));
	}

	public void OnButtonPressed()
	{
		SwitchToScene("res://Scenes/ConsoleScene.tscn");
	}

	private void SwitchToScene(string scenePath)
	{
		var tree = GetTree();
		if (tree != null)
		{
			tree.ChangeSceneToFile(scenePath);
		}
	}
}
