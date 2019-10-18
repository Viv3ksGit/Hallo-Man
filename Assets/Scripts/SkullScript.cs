using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
    public bool CollisionWithBullet = false;
    public Animator animator;
    public int wait = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionWithBullet)
        {
            animator.SetBool("Skull_Explode", CollisionWithBullet);
            wait = wait + 1;
            if (wait > 24)
            {

                Destroy(this.gameObject);

            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            
            CollisionWithBullet = true;
            Destroy(collision.gameObject);
        }
    }
}
