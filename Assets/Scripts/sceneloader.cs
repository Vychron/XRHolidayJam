using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{

    private static int CurrentScene;

   public static void LoadNextScene()
    {
        GameManager.CurrentGameState = GameStates.Adjusting;
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene + 1);
    }

    public static void LoadScene(int buildIndex) {
        GameManager.CurrentGameState = GameStates.Adjusting;
        SceneManager.LoadScene(buildIndex);
    }

}
