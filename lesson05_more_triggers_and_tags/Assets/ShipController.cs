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
        
        if(collider2D.CompareTag("WallLeft"))
        {
            _maxLeftReached = true;
        }
        if(collider2D.CompareTag("WallRight")) 
        {
            _maxRightReached = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("WallLeft"))
        {
            _maxLeftReached = false;
        }
        if(collider2D.CompareTag("WallRight")) 
        {
            _maxRightReached = false;
        }
    }
    // void OnTriggerStay2D(Collider2D collider2D)
    // {
    //     Debug.Log("#################OnTriggerStay2D#################");
    // }
}
