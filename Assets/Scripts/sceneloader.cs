using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

}
