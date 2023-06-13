using Godot;

public partial class LowPolyEarthRotation : MeshInstance3D
{
	private float rotationSpeed = 0.01f;
	private bool mouseHeldDown = false;
	
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton && mouseButton.ButtonIndex == MouseButton.Left)
		{
			if (mouseButton.Pressed)
			{
				// Mouse button is pressed
				mouseHeldDown = true;
			}
			else
			{
				// Mouse button is released
				mouseHeldDown = false;
			}
		}
		if (@event is InputEventMouseMotion mouseMotion && mouseHeldDown)
		{
			Vector2 motion = mouseMotion.Relative;
			RotateObject(motion);
		}
	}

	private void RotateObject(Vector2 motion)
	{
		RotateX(motion.Y * rotationSpeed);
		RotateY(motion.X * rotationSpeed);
	}
}
