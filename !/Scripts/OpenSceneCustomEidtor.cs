using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class OpenSceneCustomEidtor : MonoBehaviour
{
    [MenuItem("Open Scene/Menu &1")]
    public static void OpenSceneOne() => OpenScene("Level_1");

    [MenuItem("Open Scene/Loading &2")]
    public static void OpenSceneTwo() => OpenScene("Level_2");

    [MenuItem("Open Scene/Loading &3")]
    public static void OpenSceneThree() => OpenScene("Level_3");

    [MenuItem("Open Scene/Loading &4")]
    public static void OpenSceneFour() => OpenScene("Level_4");

    [MenuItem("Open Scene/Loading &5")]
    public static void OpenSceneFive() => OpenScene("Level_5");

    [MenuItem("Open Scene/Loading &6")]
    public static void OpenSceneSix() => OpenScene("Level_6");

    [MenuItem("Open Scene/Game &m")]
    public static void OpenMenuScene() => OpenScene("Menu");

    [MenuItem("Open Scene/Game &l")]
    public static void OpenLoadingScene() => OpenScene("Loading");

    public static void OpenScene(string nameScene)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene("Assets/!/Scenes/" + nameScene + ".unity");
    }
}
