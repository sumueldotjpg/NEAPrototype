using Godot;
using System;
using Variables;

public partial class WinOrLose : Control
{
	[Export]
	Label WinText, LoseText;

	public void GameWin()
	{
		WinText.Text = 
		$"YOU WIN!!! \n\n\n\n" +
		"Money: {AllObjects.CurrentProfile.MoneyBalance} \n\n" +
		"Time Spent: ";
		//
	}
	public void GameLose()
	{
		LoseText.Text = 
		$"you lose \n\n\n\n" +
		"Money: {AllObjects.CurrentProfile.MoneyBalance} \n\n" +
		"Time Spent: ";
		//
	}
}
