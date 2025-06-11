using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer;
    public TMP_Text timerText;

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(timer * 100) / 100;
    }
}
