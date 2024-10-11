using Godot;

public partial class SaveManager : Node {
	private string ComputeFilePath(string fileName) {
		return "res://Data/" + fileName + ".json";
	}
	
	public void SaveGame( string savePath) {
		using var saveFile = FileAccess.Open(ComputeFilePath(savePath), FileAccess.ModeFlags.Write);

		var player = Manager.Get().GetPlayer();
		var data = new Godot.Collections.Dictionary<string, Variant>() {
			{"coins", player.Call("get_coins")}
		};
		saveFile.StoreLine(Json.Stringify(data));
	}
	
	public Variant LoadGame(string filePath) {
		if (!FileAccess.FileExists(ComputeFilePath(filePath))) {
			return 0;
		}

		using var saveFile = FileAccess.Open(ComputeFilePath(filePath), FileAccess.ModeFlags.Read);

		var jsonString = saveFile.GetLine();
		var json = new Json();
		var parseResult = json.Parse(jsonString);
		if (parseResult != Error.Ok) {
			GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
			return 0;
		}
		
		var data = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);
		return data["coins"];
	}
	
	public void ResetGame(string filePath){
		using var saveFile = FileAccess.Open(ComputeFilePath(filePath), FileAccess.ModeFlags.Write);

		var resetedData = new Godot.Collections.Dictionary<string, Variant>() {
			{"coins", 0}
		};
		saveFile.StoreLine(Json.Stringify(resetedData));
	}
}
