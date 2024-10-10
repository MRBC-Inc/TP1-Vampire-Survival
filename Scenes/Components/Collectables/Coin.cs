using Godot;
using System;
using static CoinManager;

public partial class Coin : StaticBody2D
{
	public void _on_area_2d_body_entered(Node body){ 
		if (body.IsInGroup("Player")){
			if (this.Visible) {
				CoinManager.CoinCollected();
			}
			this.Visible = false;
		}
	}
	
}
