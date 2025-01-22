using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float movementSpeed, rotationSpeed, scaleSpeed;
    private InputAction _moveAction, _spinAction, _scaleAction;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _spinAction = InputSystem.actions.FindAction("Spin");
        _scaleAction = InputSystem.actions.FindAction("Scale");
    }

    void Update()
    {
        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue *= Time.deltaTime * movementSpeed;
        transform.Translate(translationValue);

        float spinDirection = _spinAction.ReadValue<float>() * Time.deltaTime;
        //Debug.Log(spinDirection);
        transform.Rotate(0, 0, spinDirection * rotationSpeed);

        float scaleAmount = _scaleAction.ReadValue<float>() * Time.deltaTime * scaleSpeed;
        Vector3 scaleChange = new Vector3(scaleAmount, scaleAmount, scaleAmount);
        transform.localScale += scaleChange;
    }
}
