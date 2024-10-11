using Godot;
using System;
using static Manager;

public partial class MainMenu : Node2D
{
	public void _on_play_pressed() {
		PackedScene nextLevel = Manager.Get().GetLevelManager().LoadLevel("World");
		GetTree().ChangeSceneToPacked(nextLevel);
	}
	
	public void _on_reset_pressed() {
		Manager.Get().GetSaveManager().ResetGame("game");
	}
	
	public void _on_quit_pressed() {
		GetTree().Quit();
	}
}
