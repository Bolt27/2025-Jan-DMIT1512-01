using UnityEngine;

public class PlungerStop : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("alsdjfalskdjfalskdjfalskdjf");
        if(collision.collider.gameObject.name == "Plunger")
        {
            collision.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
