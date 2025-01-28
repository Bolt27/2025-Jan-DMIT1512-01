using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float movementSpeed;
    private InputAction _moveAction;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue.y = 0;
        translationValue *= Time.deltaTime * movementSpeed;
        transform.Translate(translationValue);
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
        
    }
    // void OnTriggerStay2D(Collider2D collider2D)
    // {
    //     Debug.Log("#################OnTriggerStay2D#################");
    // }
    // void OnTriggerExit2D(Collider2D collider2D)
    // {
    //     Debug.Log("<<<<<<<<>>>>>>>>OnTriggerExit2D<<<<<<<<>>>>>>>>");
    // }
}
