using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float speed;
    private InputAction _moveAction;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue *= Time.deltaTime * speed;
        transform.Translate(translationValue);
    }
}
