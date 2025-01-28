using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float movementSpeed;
    private InputAction _moveAction;
    private bool _maxLeftReached, _maxRightReached;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue.y = 0;
        translationValue *= Time.deltaTime * movementSpeed;
        //if we're trying to move right
        if(translationValue.x > 0 && !_maxRightReached)
        {
            transform.Translate(translationValue);
        }
        if(translationValue.x < 0 && !_maxLeftReached)//we're moving left
        {
            transform.Translate(translationValue);
        }
    }

    /*
        There are three methods that deal with trigger collission:
        OnTriggerEnter2D - called when the objects first come into contact
        OnTriggerStay2D - called every frame during which they are in contact
        OnTriggerExit2D - called when they stop being in contact
    */
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        // GameObject whatIBumpedInto;
        // whatIBumpedInto = collider2D.gameObject;
        // Destroy(whatIBumpedInto);
        
        //is the thing that I collided with on my left?
        if(collider2D.transform.position.x < transform.position.x)
        {
            _maxLeftReached = true;
        }
        else //it's on my right
        {
            _maxRightReached = true;
            Debug.Log("hit right side");
        }

    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        _maxLeftReached = false;
        _maxRightReached = false;
    }
    // void OnTriggerStay2D(Collider2D collider2D)
    // {
    //     Debug.Log("#################OnTriggerStay2D#################");
    // }
}
