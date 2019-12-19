using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{

    private static int CurrentScene;

   public static void LoadNextScene()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene + 1);
    }

    public static void LoadScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }

}
