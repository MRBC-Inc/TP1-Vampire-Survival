using Godot;

public partial class LevelManager : Node {
	private string ComputeLevelPath(string levelName) {
		return "res://Scenes/Screens/" + levelName + "/" + levelName + ".tscn";
	}
	
	public PackedScene LoadLevel(string sceneName){
		GD.Print("ON LOAD LE LEVEL " + sceneName);
		return ResourceLoader.Load<PackedScene>(ComputeLevelPath(sceneName));
	}
}
