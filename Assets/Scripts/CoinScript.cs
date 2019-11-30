using UnityEngine;
using System.Collections;
public class CoinScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int candyValue;
    // Use this for initialization
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameLevelManager.AddCoins(candyValue);
            Destroy(gameObject);
        }
        if(other.tag == "CheckPoint")
        {
            
                 gameLevelManager.AddCoins(candyValue);

        }
        
    }
}