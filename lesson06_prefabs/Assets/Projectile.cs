using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed;
    public Vector2 direction;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
    //once we've set up the projectile as a Kinematic Rigidbody Trigger Collider
    //and whatever we're going to hit at least has a collider,
    //the below code should run when the two game objects touch
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("PlayerShip"))
        {
            Destroy(collider2D.gameObject);
        }
    }
}
