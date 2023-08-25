using Godot;
using System;

public partial class TabMovement : VBoxContainer
{
	private PathFollow2D followPath;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		followPath = (PathFollow2D)GetParent();
		followPath.ProgressRatio = 0.0f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//extend
	private void ExtendTabList()
	{
		followPath.ProgressRatio = 1.0f;
	}
		private void _on_mouse_entered()
	{
		ExtendTabList();
	}
	private void _on_button_exit_mouse_entered()
	{
		ExtendTabList();
	}
	private void _on_button_settings_mouse_entered()
	{
		ExtendTabList();
	}
	private void _on_button_np_cs_mouse_entered()
	{
		ExtendTabList();
	}
	private void _on_button_upgrades_mouse_entered()
	{
		ExtendTabList();
	}
	private void _on_button_console_mouse_entered()
	{
		ExtendTabList();
	}
	private void _on_button_globe_mouse_entered()
	{
		ExtendTabList();
	}
	//retract
	private void RetractTabList()
	{
		followPath.ProgressRatio = 0.0f;
	}
	private void _on_mouse_exited()
	{
		RetractTabList();
	}
	private void _on_button_exit_mouse_exited()
	{
		RetractTabList();
	}
	private void _on_button_settings_mouse_exited()
	{
		RetractTabList();
	}
	private void _on_button_np_cs_mouse_exited()
	{
		RetractTabList();
	}
	private void _on_button_upgrades_mouse_exited()
	{
		RetractTabList();
	}
	private void _on_button_console_mouse_exited()
	{
		RetractTabList();
	}
	private void _on_button_globe_mouse_exited()
	{
		RetractTabList();
	}
}
