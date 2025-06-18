using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    private int i = 1;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //MovePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if(points.Length > 0)
        {
            //rb.MovePosition(points[i].position);
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
        

    }


    public void MovePlatform()
    {
        points[i].gameObject.SetActive(false);
        i = i == 0 ? 1 : 0;
        points[i].gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.transform.parent = null;
    }
}
