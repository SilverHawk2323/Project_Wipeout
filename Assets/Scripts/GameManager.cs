using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool wonGame;
    public float timer;
    public static GameManager gm;
    public TMP_Text timerText;
    public GameObject winScreen;
    public TMP_Text winText;
    public GameObject GUI;

    private void Awake()
    {
        
        Time.timeScale = 1f;
        GUI.SetActive(true);
        gm = gm == null ? this : gm;
    }

    private void Start()
    {
        SetCursor(false);
    }

    private void Update()
    {
        if (wonGame) return;
        timer += Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(timer * 100) / 100;
    }

    public void WinScreen()
    {
        SetCursor(true);
        wonGame = true;
        GUI.SetActive(false);
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        winText.text = "Happy Birthday!!!\nYou're now the ultimate ninja \nYour time was: \n" + timerText.text + "seconds"; 
    }

    public void SetCursor(bool isOn)
    {
        if (isOn)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
