using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Menu, Tutorial, Loading,
    Level_1, Level_2, Level_3, Level_4, Level_5, Level_6,
}

public static class LoadSceneManager 
{
    public static readonly Scene MENU = Scene.Menu;
    public static readonly Scene LOADING = Scene.Loading;
    public static readonly Scene LEVEL_1 = Scene.Level_1;
    public static readonly Scene LEVEL_2 = Scene.Level_2;
    public static readonly Scene LEVEL_3 = Scene.Level_3;
    public static readonly Scene LEVEL_4 = Scene.Level_4;
    public static readonly Scene LEVEL_5 = Scene.Level_5;
    public static readonly Scene LEVEL_6 = Scene.Level_6;

    public static void LoadScene(Scene scene)
    {
        string sceneName = scene.ToString();
        SceneManager.LoadScene(sceneName);
    }

    public static AsyncOperation LoadSeneAsync(Scene scene)
    {
        string sceneName = scene.ToString();
        return SceneManager.LoadSceneAsync(sceneName);
    }

    public static void LoadScene(string sceneName) =>
        SceneManager.LoadScene(sceneName);

    public static AsyncOperation LoadSeneAsync(string sceneName) =>
        SceneManager.LoadSceneAsync(sceneName);
}
