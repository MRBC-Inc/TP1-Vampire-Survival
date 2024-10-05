using Godot;

public partial class LevelManager : Node {
	public Node LoadLevel(string scenePath){
		GD.Print("ON LOAD LE LEVEL " + scenePath);
		return ResourceLoader.Load<PackedScene>(scenePath).Instantiate();
	}
}
