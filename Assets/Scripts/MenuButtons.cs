using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuButtons : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.gm.SetCursor(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
