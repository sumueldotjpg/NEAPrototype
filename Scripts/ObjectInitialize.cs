using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Variables;

namespace Main
{
	public class MainCreation
	{
		public static void Main()
		{
			//POI Creation
			AllObjects.allPOIs.Add(new POI("Google","Multi-Billion Dollar Corporation created to brainwash the population",1));

			//PuzzleCreation
			AllObjects.allPuzzles.Add(new Puzzle(1,"What is this? \nTravel\n----------\nCCCCC","travel over seas"));
		}
	}
}
