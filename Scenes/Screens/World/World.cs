using Godot;
using System;
using static Manager;

public partial class World : Node2D {	
	public void _on_area_2d_body_entered(Node body) {
		if (body.IsInGroup("Player")){
			GD.Print("World1 : detect body");
			PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel("res://Scenes/Screens/World2/World2.tscn");
			GetTree().ChangeSceneToPacked(nextLevel);
		}
	}
}
