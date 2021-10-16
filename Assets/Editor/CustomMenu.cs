using UnityEditor;
using UnityEditor.SceneManagement;

namespace Editor
{
    public class CustomMenu : UnityEditor.Editor
    {
        [MenuItem("Scenes/HomeScene")]
        public static void HomeMainScene()
        {
            // 保存しているかチェック
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/HomeScene.unity"; /* ここに遷移したいシーンをフルパスで書く */
                EditorSceneManager.OpenScene(scene_path);
            }
        }
        [MenuItem("Scenes/HomeSecondScene")]
        public static void HomeSecondScene()
        {
            // 保存しているかチェック
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/HomeSecondScene.unity"; /* ここに遷移したいシーンをフルパスで書く */
                EditorSceneManager.OpenScene(scene_path);
            }
        }

        [MenuItem("Scenes/World")]
        public static void WorldScene()
        {
            // 保存しているかチェック
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/WorldScene.unity"; /* ここに遷移したいシーンをフルパスで書く */
                EditorSceneManager.OpenScene(scene_path);
            }
        }

        [MenuItem("Scenes/TitleScene")]
        public static void TitleScene()
        {
            // 保存しているかチェック
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/TitleScene.unity";
                EditorSceneManager.OpenScene(scene_path);
            }
        }

        [MenuItem("Scenes/FirstInputScene")]
        public static void FirstInputScene()
        {
            // 保存しているかチェック
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/FirstInputScene.unity";
                EditorSceneManager.OpenScene(scene_path);
            }
        }

        [MenuItem("Scenes/OpeningScene")]
        public static void OpeningScene()
        {
            // 保存しているかチェック
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/OpeningScene.unity";
                EditorSceneManager.OpenScene(scene_path);
            }
        }

        [MenuItem("Scenes/LabScene")]
        public static void LabScene()
        {
            // 保存しているかチェック
            // if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) 
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // シーンに遷移
                string scene_path = "Assets/Scenes/LabScene.unity";
                // EditorApplication.OpenScene (scene_path);
                EditorSceneManager.OpenScene(scene_path);
            }
        }
    }
}