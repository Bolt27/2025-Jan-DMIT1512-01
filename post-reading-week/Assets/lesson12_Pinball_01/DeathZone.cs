using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    void Start()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = ballSpawnPoint.position;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        StartCoroutine(WaitThenSpawnBall());
    }
    IEnumerator WaitThenSpawnBall()
    {
        yield return new WaitForSeconds(5); //go away, then come back in 1 second
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = ballSpawnPoint.position;
    }

}
