using UnityEngine;
using System.Collections;
public class CheckPoint : MonoBehaviour
{
    public Sprite item1;
    public Sprite item2;
    public Sprite item3;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;
    // Use this for initialization
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = item2;
            checkpointReached = true;
        }
    }
}