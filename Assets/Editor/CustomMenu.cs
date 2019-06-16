using UnityEditor;

public class CustomMenu : Editor
{
	[MenuItem("Scenes/HomeScene")]
	public static void HomeMainScene ()
	{
		// 保存しているかチェック
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) 
		{
			// シーンに遷移
			string scene_path = "Assets/Scenes/HomeScene.unity";  /* ここに遷移したいシーンをフルパスで書く */
			EditorApplication.OpenScene (scene_path);
		}
	}
	[MenuItem("Scenes/World")]
	public static void WorldScene ()
	{
		// 保存しているかチェック
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) 
		{
			// シーンに遷移
			string scene_path = "Assets/Scenes/WorldScene.unity";  /* ここに遷移したいシーンをフルパスで書く */
			EditorApplication.OpenScene (scene_path);
		}
	}
	[MenuItem("Scenes/TitleScene")]
	public static void TitleScene ()
	{
		// 保存しているかチェック
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) 
		{
			// シーンに遷移
			string scene_path = "Assets/Scenes/TitleScene.unity";
			EditorApplication.OpenScene (scene_path);
		}
	}
	[MenuItem("Scenes/FirstInputScene")]
	public static void FirstInputScene ()
	{
		// 保存しているかチェック
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) 
		{
			// シーンに遷移
			string scene_path = "Assets/Scenes/FirstInputScene.unity";
			EditorApplication.OpenScene (scene_path);
		}
	}
	[MenuItem("Scenes/OpeningScene")]
	public static void OpeningScene()
	{
		// 保存しているかチェック
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) 
		{
			// シーンに遷移
			string scene_path = "Assets/Scenes/OpeningScene.unity";
			EditorApplication.OpenScene (scene_path);
		}
	}
}