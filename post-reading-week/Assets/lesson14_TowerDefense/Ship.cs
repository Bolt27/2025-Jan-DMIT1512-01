using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform target;
    public float speed;
    void Update()
    {
        // move
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 moveDirection = transform.position - target.position;
        if(moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //it's working exactly as I want, except it needs to be flipped by 180 degrees on the z axis.
            transform.RotateAround(transform.position, transform.forward, 180f);
        }
    }
}
