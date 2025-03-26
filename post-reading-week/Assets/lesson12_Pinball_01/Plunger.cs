using UnityEngine;
using UnityEngine.InputSystem;


public class Plunger : MonoBehaviour
{
    public float force;
    private InputAction spacebarAction;
    public Transform plungerLowestPoint, plungerStop;
    void Start()
    {
        spacebarAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        if(transform.position.y >= plungerLowestPoint.position.y && spacebarAction.ReadValue<float>() != 0)
        {
            transform.Translate(0, spacebarAction.ReadValue<float>() * Time.deltaTime * -3, 0, Space.Self);
        }
        if(spacebarAction.WasReleasedThisFrame())
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(0, force * (plungerStop.position.y - transform.position.y)), ForceMode2D.Impulse);
        }
    }
}
