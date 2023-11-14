using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public void TeleportScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
