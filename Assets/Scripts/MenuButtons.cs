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

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        GameManager.gm.SetCursor(false);
        GameManager.gm.SetPauseScreen(false);
    }
}
