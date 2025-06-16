using UnityEngine;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.gm.WinScreen();
        }
    }
}
