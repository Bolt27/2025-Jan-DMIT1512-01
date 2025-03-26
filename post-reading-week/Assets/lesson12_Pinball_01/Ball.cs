using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private GameStateFinal _gameState;
    void Start()
    {
         _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateFinal>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //todo: to have different game objects be worth different amounts,
        //give them tags and check the tag here
        _gameState.CurrentScore++;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //suggestion: change a UI label on the scene to "game over",
        //then wait 5 seconds (with a coroutine), then run the code below
        //SceneManager.LoadScene("StartScene");
    }

}
