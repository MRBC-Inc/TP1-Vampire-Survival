using Godot;
using System;
using static Manager;

public partial class World2 : Node2D {
	public void _on_area_2d_body_entered(Node body) {
		GD.Print("World2 : Detect body");
		PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel("res://Scenes/Screens/World/World.tscn");
		GetTree().ChangeSceneToPacked(nextLevel);
	}
}
