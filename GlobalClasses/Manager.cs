using Godot;
using static LevelManager;
using static SaveManager;

[GlobalClass]
public partial class Manager : SceneTree
{
	private LevelManager levelManager;
	private SaveManager saveManager;

	private static Manager managerInstance;

	public Manager(){
		managerInstance = this;
		levelManager = new LevelManager();
		saveManager = new SaveManager();
		GD.Print("NOTRE MANAGER is ready!");
	}

	public static Manager Get(){
		if (managerInstance == null){
			managerInstance = new Manager();
		}
		return managerInstance;
	}

	public LevelManager GetLevelManager(){
		return levelManager;
	}
	public SaveManager GetSaveManager(){
		return saveManager;
	}
}
