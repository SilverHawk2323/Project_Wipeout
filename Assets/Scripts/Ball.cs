using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
