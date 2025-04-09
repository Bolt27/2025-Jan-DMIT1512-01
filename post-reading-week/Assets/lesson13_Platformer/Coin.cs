using UnityEngine;

public class Coin : MonoBehaviour
{
    private SoundHub _soundHub;
    void Awake()
    {
        _soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        _soundHub.PlayCoinSound();
        Destroy(this.gameObject);

        //for the lab, you should keep track of how many coins are picked up in GameState

    }
}
