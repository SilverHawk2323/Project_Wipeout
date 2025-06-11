using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    private int i = 1;

    private void Start()
    {
        MovePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if(points.Length > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
        

    }

    public void MovePlatform()
    {
        i = i == 0 ? 1 : 0;
    }
}
