using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    private HingeJoint2D joint2D;
    private InputAction _flipRight;
    private InputAction _flipLeft;
    public enum FlipperType
    {
        Right, Left
    }
    public FlipperType _type;
    void Start()
    {
        joint2D = GetComponent<HingeJoint2D>();
        _flipRight = InputSystem.actions.FindAction("FlipperRight");
        _flipLeft = InputSystem.actions.FindAction("FlipperLeft");
    }
    void Update()
    {
        switch(_type)
        {
            case(FlipperType.Right):
                joint2D.useMotor = _flipRight.IsPressed();
                break;
            case(FlipperType.Left):
                joint2D.useMotor = _flipLeft.IsPressed();
                break;
        }
        
    }
}
