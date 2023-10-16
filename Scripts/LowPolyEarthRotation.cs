using Godot;
using Variables;

public partial class LowPolyEarthRotation : MeshInstance3D
{

	private float rotationSpeed = 0.002f;
	private bool mouseHeldDown = false;
	RichTextLabel infoLabel;
	RichTextLabel playerLabel;

	public override void _Ready()
	{
		infoLabel = GetNode<RichTextLabel>("/root/MainScreen/RichTextLabelInfo");
		playerLabel = GetNode<RichTextLabel>("/root/MainScreen/RichTextLabelPlayer");
	}
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
	private void _on_area_3d_mouse_entered()
	{
		foreach(POI poi in AllObjects.allPOIs)
		{
			GD.Print("Looking");
			if (poi.Name == "Google")
			{
				playerLabel.Text = $"Name: {poi.Name} \nDescription: {poi.Description} \nStrength: {poi.Strength}";
			}
		}
	}
}
