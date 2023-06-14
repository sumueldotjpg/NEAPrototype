using Godot;
using System;

public partial class UpgradeButtonHandler : Button
{
	public override void _Ready()
	{
		Connect("pressed", new Callable(this, nameof(OnButtonPressed)));
	}

	public void OnButtonPressed()
	{
		SwitchToScene("res://Scenes/UpgradesScene.tscn");
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
