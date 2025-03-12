using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = ballSpawnPoint.position;
    }

}
