using Godot;

public partial class SaveManager : Node {
	private ComputeFilePath(string fileName) {
		return "res://Data/" + fileName + ".json";
	}
	
	public void SaveGame(string saveFileName) : string {
		GD.Print("Game saved in " + ComputeFilePath(saveFileName) + "!");
		using var saveFile = FileAccess.Open(ComputeFilePath(saveFileName), FileAccess.ModeFlags.Write);
		var jsonString = Json.Stringify(nodeData);
		saveFile.StoreLine(jsonString);
	}
	
	
	public void LoadGame(string ComputeFilePath(saveFileName)){
		GD.Print("Game loaded from " + ComputeFilePath(saveFileName) + "!");
		if (!FileAccess.FileExists(ComputeFilePath(saveFileName))) {
			return; // Error! We don't have a save to load.
		}
		
		using var saveFile = FileAccess.Open(ComputeFilePath(saveFileName), FileAccess.ModeFlags.Read);
		var jsonString = saveFile.GetLine();

		var json = new Json();
		var parseResult = json.Parse(jsonString);
		if (parseResult != Error.Ok)
		{
			GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
			continue;
		}
	}
}
