using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public float timer;
    public float resetTime;
    public GameObject ball;

    public List<GameObject> spawnedBall = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timer = resetTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DestroyAllSpawned();
            Spawn();
            timer = resetTime;
        }
    }

    private void Spawn()
    {
        GameObject spawned = Instantiate(ball, transform.position, Quaternion.identity);
        spawnedBall.Add(spawned);
    }

    public void DestroyAllSpawned()
    {
        if (spawnedBall.Count == 0) return;
        foreach (GameObject spawned in spawnedBall)
        {
            Destroy(spawned);
        }
    }
}
