using Godot;
using System;
using Variables;

public partial class PlayerInfoHandler : RichTextLabel
{
	[Export]
	RichTextLabel playerLabel;

	string GameDescription = "Welcome To Decription Domination!\nThe aim of this game is to take over the world by upgrading your virus to attack larger companies and buying NPCs to do some of the work for you.\nAs you progress through the game the detection bar on the right will slowly increase. But BEWARE if this bar reaches its maximum you will lose as the authorities have found you out.\nSo go forward and try and attack your first Point Of Interest(Genuine Solution)";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		playerLabel.Text=
		$"Balance: {AllObjects.CurrentProfile.MoneyBalance}\n" +
		$"Unlocked POIs: {AllObjects.CurrentProfile.UnlockedPOIs.Count}\n" +
		$"Unlocked NPCs: {AllObjects.CurrentProfile.UnlockedNPCs.Count}\n" +
		$"Unlocked Attacks: {AllObjects.CurrentProfile.UnlockedAttacks.Count}\n\n" +
		GameDescription;
	}
}
