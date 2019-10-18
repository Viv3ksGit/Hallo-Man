using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float velocityx;
    public float velocityy = 0F;
    Rigidbody2D rb;    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(velocityx, velocityy);
        Destroy(gameObject, 3f);
    }
}