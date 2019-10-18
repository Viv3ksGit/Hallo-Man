using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    float randx;
    Vector2 wheretoSpawn;
    public float spawnRate = 0.5f;
    float nextSpawn = 0.0f;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RocketSprite");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randx = Random.Range(player.transform.position.x + 10, player.transform.position.x + 30);
            wheretoSpawn = new Vector2(randx, transform.position.y);
            Instantiate(enemy, wheretoSpawn, Quaternion.identity);
        }

    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}