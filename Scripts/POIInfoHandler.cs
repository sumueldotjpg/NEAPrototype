using Godot;
using System;
using System.Collections.Generic;
using Variables;

public partial class POIInfoHandler : TabContainer
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	TextEdit genuineSolutionsText, microsoftText, googleText, appleText, amazonText, metaText, samsungText, intelText, ibmText, uberText, adobeText, wwwText, amdText, teslaText, nvidiaText;
	List<TextEdit> textEdits;
	public override void _Ready()
	{
		textEdits = new List<TextEdit>() { genuineSolutionsText, microsoftText, googleText, appleText, amazonText, metaText, samsungText, intelText, ibmText, uberText, adobeText, wwwText, amdText, teslaText, nvidiaText };

		for (int i = 0; i < textEdits.Count; i++)
		{
			textEdits[i].Text =
			$"This is a {AllObjects.allPOIs[i].GetType().Name} \n\n\nThis POI is know for: \n\"{AllObjects.allPOIs[i].Description}\""
			;
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
