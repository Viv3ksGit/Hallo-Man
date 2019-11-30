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
    public float speed;
    private bool movingRight = true;
    public Transform groundDection;
    private Rigidbody2D rigidBody;
    Vector3 pointA;
    private float movement = 0f;
    Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        Vector3 position = this.transform.position;

        pointA = new Vector3(position.x, position.y, 0);
        pointB = new Vector3(position.x + 25, position.y, 0);
        Player = GameObject.Find("RocketSprite");
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //RaycastHit2D groundInfo = Physics2D.Raycast(groundDection.position,Vector2.down,2f);
        //if(groundInfo.collider == false)
        //{
        //    if (movingRight == true)
        //    {
        //        transform.localScale = new Vector2(-1.324974f, -1.324974f);
        //        movingRight = false;
        //    }
        //    else
        //    { 
        //        transform.localScale = new Vector2(-1.324974f, -1.324974f);
        //        movingRight = true;
        //    }
        //}
        float temp = Player.transform.position.x - this.transform.position.x;
        if (died == false) {
            if (temp < 0)
            {
                temp = temp * -1f;

            }

            if (temp < 10)
            {
                animator.SetBool("Player_Near", true);
            }
            if (temp > 10)
            {
                animator.SetBool("Player_Near", false);
                float time = Mathf.PingPong(Time.time * speed, 1);
                this.transform.position = Vector3.Lerp(pointA, pointB, time);


            }
            //if (this.transform.position == pointA)
            //{
            //    movingRight = true;
            //    transform.localScale = new Vector2(-3.324974f, 3.324974f);
            //    //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 0, this.transform.rotation.z);
            //}
            //if (this.transform.position == pointB)
            //{
            //    movingRight = false;
            //    transform.localScale = new Vector2(-3.324974f, -3.324974f);
            //    //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 180, this.transform.rotation.z);
            //}
            //movement = Input.GetAxis("Horizontal");

            if (movement > 0f)
            {
                movingRight = true;
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
                transform.localScale = new Vector2(-3.324974f, 3.324974f);
            }
            else if (movement< 0f)
            {
                movingRight = false;
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
                transform.localScale = new Vector2(-3.324974f, -3.324974f);
            }

            if (died)
            {
                animator.SetBool("Died", died);
                wait = wait + 1;
                if (wait > 100)
                {
                    Destroy(this.gameObject);

                }
            }

        }

        void OnCollisionEnter2D(Collision2D collision)
        {


            if (collision.gameObject.tag.Equals("Bullet"))
            {

                count++;
                died |= count > 4;
                Destroy(collision.gameObject);
            }
        }
    }
}
