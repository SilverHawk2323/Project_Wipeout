using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovingPlatform>(out MovingPlatform platform))
        {
            platform.MovePlatform();
        }
    }
}
