using Godot;

public partial class LevelManager : Node {
	public void LoadLevel(string scenePath, Node target){
		GD.Print("ON LOAD LE LEVEL " + scenePath);
		ResourceLoader.Load<PackedScene>("res://Scenes/Screens/World/World.tscn").Instantiate();
	}
}
