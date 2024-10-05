using Godot;

public partial class LevelManager : Node {
	public PackedScene LoadLevel(string scenePath){
		GD.Print("ON LOAD LE LEVEL " + scenePath);
		return ResourceLoader.Load<PackedScene>(scenePath);
	}
}
