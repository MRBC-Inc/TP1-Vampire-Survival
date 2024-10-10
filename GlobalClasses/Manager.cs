using Godot;
using static LevelManager;
using static SaveManager;
[GlobalClass]
public partial class Manager : SceneTree
{
	private LevelManager levelManager;
	private SaveManager saveManager;
	private Node player;

	private static Manager managerInstance;

	public Manager(){
		managerInstance = this;
		levelManager = new LevelManager();
		saveManager = new SaveManager();
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
	
	public void SetPlayer(Node pl) {
		player = pl;
	}
	public Node GetPlayer() {
		return player;
	}
}
