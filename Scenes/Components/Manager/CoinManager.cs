using Godot;
using System;

public partial class CoinManager : Node
{
	public static int TotalCoins { get; private set; }
	private static Label coinLabel;
	
	public override void _Ready()
	{
		GD.PrintErr("CQCqS");
		coinLabel = GetNode<Label>("../World/Player/Camera2D/CoinLabel");
		// Vérifie si le label existe
		if (coinLabel != null)
		{
			// Modifie le texte du label
			coinLabel.Text = TotalCoins.ToString(); // Afficher le nombre de pièces collectées
		}
		else
		{
			GD.PrintErr("Label not found!");
		}
	}

	// Méthode statique
	public static void CoinCollected()
	{
		TotalCoins++;
		GD.Print("Total coins: " + TotalCoins);
		
		if (coinLabel != null)
		{
			// Modifie le texte du label
			coinLabel.Text = TotalCoins.ToString();
		}
		else
		{
			GD.PrintErr("Label not found!");
		}
	}
}
