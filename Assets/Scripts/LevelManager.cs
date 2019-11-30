using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int candies;
    public Text candiesText;
    // Use this for initialization
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        candiesText.text = "Candies: " + candies;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }
    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
    public void AddCoins(int numberOfCandies)
    {
        candies += numberOfCandies;
        candiesText.text = "Candies: " + candies;
    }
}