using UnityEngine;

public class SetCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController.playerRef.SetCheckpoint(gameObject);
        }
    }
}
