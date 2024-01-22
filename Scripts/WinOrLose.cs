using Godot;
using System;
using Variables;

public partial class WinOrLose : Control
{
	[Export]
	Label WinText;

	public void GameWin()
	{
		WinText.Text = 
		$"YOU WIN!!! \n\n\n\n" +
		"Money: {AllObjects.CurrentProfile.MoneyBalance} \n\n" +
		"Time Spent: ";
		//
	}
}
