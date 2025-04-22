using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyShip"))
        {
            // collider is the Collider2D that we hit
            collision.collider.gameObject.SetActive(false);
            // Give projectile back to the prefab pool
            // otherCollider is *our* Collider2D
            collision.otherCollider.gameObject.SetActive(false);
        }
    
    }
}
