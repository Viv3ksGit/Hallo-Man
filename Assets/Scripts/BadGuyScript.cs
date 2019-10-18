using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    public bool died = false;
    public int count = 0;
    public int wait = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RocketSprite");
    }

    // Update is called once per frame
    void Update()
    {
        float temp = Player.transform.position.x - this.transform.position.x;
        if (died == false) { 
        if (temp < 0)
        {
            temp = temp * -1f;

        }
       
        if (temp < 5)
        {
            animator.SetBool("Player_Near",true);
        }
        if (temp > 5)
        {
            animator.SetBool("Player_Near", false);
        }
        }
        if (died)
        {
            animator.SetBool("Died", died);
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

            count++;
            died |= count > 4;
            Destroy(collision.gameObject);
        }
    }
}
