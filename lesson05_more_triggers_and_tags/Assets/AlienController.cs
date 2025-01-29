using UnityEngine;

public class AlienController : MonoBehaviour
{
    public float speed;
    private Vector2 _direction = new Vector2(-1, 0);

    void Update()
    {
        transform.Translate(speed * _direction * Time.deltaTime);
    }
}
