using Godot;
using System;
using static Manager;

public partial class World2 : Node2D {
	public void _on_area_2d_next_body_entered(Node body) {
		if (body.IsInGroup("Player")){
			PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel("res://Scenes/Screens/World3/World3.tscn");
			GetTree().ChangeSceneToPacked(nextLevel);
		}
	}
	
	public void _on_area_2d_back_body_entered(Node body) {
		if (body.IsInGroup("Player")){
			PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel("res://Scenes/Screens/World/World.tscn");
			GetTree().ChangeSceneToPacked(nextLevel);
		}
	}
}
