using UnityEngine;
using System.Collections;
using System;
using UnityEditor.VersionControl;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public GameObject dead;
    public bool died = false;
    public bool AfterDead = true;
    public Vector3 respawnPoint;
    public bool Rpressed = false;
    public LevelManager gameLevelManager;
    public BulletScript bullet;
    public GameObject bulletPrefab;
    bool facingright = true;
    bool facingright1 = true;
    public GameObject bulletToRight, bulletToLeft;
    Vector2 BulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0F;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        if (died)
        {
            if (Rpressed)
            {
                // playerAnimation.SetBool("AfterDeath", true);
            }
        }
        if (died == false)
        {
            movement = Input.GetAxis("Horizontal");
            if (movement > 0f)
            {
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
                transform.localScale = new Vector2(1.324974f, -1.324974f);
            }
            else if (movement < 0f)
            {
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
                transform.localScale = new Vector2(-1.324974f, -1.324974f);
            }
            else
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }
            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fire();
            }
            playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
            playerAnimation.SetBool("OnGround", isTouchingGround);

        }
        if (died == true)
        {


            playerAnimation.SetBool("Die", died);

            if (AfterDead == true && Input.GetKey(KeyCode.R))
            {
                Rpressed = true;

                playerAnimation.SetBool("AfterDeath", true);
                died = false;
            }



            //playerAnimation.SetBool("AfterDeath", AfterDead);
            //playerAnimation.SetBool("Die", died);


        }

        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            facingright = true;
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(1.324974f, -1.324974f);
        }
        else if (movement < 0f)
        {
            facingright = false;
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-1.324974f, -1.324974f);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);



    }
    async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            died = true;
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            died = false;
            gameLevelManager.Respawn();

        }



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;

        }

    }

    public void shootBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = gameObject.transform.position;
    }

    void fire()
    {
        BulletPos = transform.position;
        if (facingright)
        {
            BulletPos += new Vector2(3F, 0.43F);
            Instantiate(bulletToRight, BulletPos, Quaternion.identity);
        }
        else
        {
            BulletPos += new Vector2(-3F, 0.43F);
            Instantiate(bulletToLeft, BulletPos, Quaternion.identity);

        }


    }
}
