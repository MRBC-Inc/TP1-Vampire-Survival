using Godot;
using System;
using static Manager;

public partial class World3 : Node2D {
	public World3 (){
		Manager.Get().GetSaveManager().SaveGame("user://savegame.save");
	}
	
	public void _on_area_2d_back_body_entered(Node body) {
		if (body.IsInGroup("Player")){
			PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel("res://Scenes/Screens/World2/World2.tscn");
			GetTree().ChangeSceneToPacked(nextLevel);
		}
	}
}
