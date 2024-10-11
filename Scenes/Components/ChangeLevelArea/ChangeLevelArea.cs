using Godot;
using System;
using static Manager;

public partial class ChangeLevelArea : Area2D {	
	public void _on_body_entered(Node body) {
		if (body.IsInGroup("Player")){
			PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel((string)GetMeta("NextLevelName"));
			GetTree().ChangeSceneToPacked(nextLevel);
		}
	}
}
