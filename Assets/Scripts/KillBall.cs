using UnityEngine;

public class KillBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            Destroy(ball.gameObject);
            Spawner.Instance.spawnedBall.Clear();

        }
    }
}
