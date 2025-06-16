using UnityEngine;

public class Points : MonoBehaviour
{
    private Collider _platform;
    private void OnTriggerEnter(Collider other)
    {
        /*if (other == _platform) return;
        if (other.TryGetComponent<MovingPlatform>(out MovingPlatform platform))
        {
            _platform = platform.GetComponent<Collider>();
            platform.MovePlatform();
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<MovingPlatform>(out MovingPlatform platform))
        {
            platform.MovePlatform();
        }
    }
}
