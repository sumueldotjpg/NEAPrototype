using Godot;
using System;

public partial class NPCButtonHandler : Button
{
	public override void _Ready()
	{
		Connect("pressed", new Callable(this, nameof(OnButtonPressed)));
	}

	public void OnButtonPressed()
	{
		SwitchToScene("res://Scenes/NPCScene.tscn");
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
