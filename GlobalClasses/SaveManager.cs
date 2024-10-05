using Godot;

public partial class SaveManager : Node {
	public void SaveGame(string saveFilePath){
		GD.Print("Game saved in " + saveFilePath + "!");
	}
	public void LoadGame(string saveFilePath){
		GD.Print("Game loaded from " + saveFilePath + "!");
	}
}
