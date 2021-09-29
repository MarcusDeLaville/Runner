using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGameScene : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
