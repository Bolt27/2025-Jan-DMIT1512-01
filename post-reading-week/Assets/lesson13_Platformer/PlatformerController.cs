using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerController : MonoBehaviour
{
    public float maxSpeed, jumpForce, moveForce;
    public Transform groundCheck;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private InputAction _jump, _move;
    private bool _grounded, _jumpInitiated;

    void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
        _jumpInitiated = false;
    }

    //todo: Update() vs. FixedUpdate()
    void Update()
    {
        //remember to make all platforms belong to the "Ground" layer
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(_jump.WasPressedThisFrame() && _grounded)
        {
            _jumpInitiated = true;
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = _move.ReadValue<Vector2>().x;

        //Have we reached _maxSpeed? If not, add force.
        //It works going left because horizonatlMovement and _myRigidBody.velocity.x 
        //will both be negative at the same time.
        if(horizontalMovement * _myRigidBody.linearVelocityX < maxSpeed)
        {
            _myRigidBody.AddForce(Vector2.right * horizontalMovement * moveForce);
        }
        //have we exceeded maxSpeed? If yes, set to maxSpeed.
        if(Mathf.Abs(_myRigidBody.linearVelocityX) > maxSpeed)
        {
            _myRigidBody.linearVelocityX = Mathf.Sign(_myRigidBody.linearVelocityX) * maxSpeed;
        }
        if(_jumpInitiated)
        {
            _myRigidBody.AddForce(new Vector2(0f, jumpForce));
            _myAnimator.SetTrigger("Jump");
            _jumpInitiated = false;
        }
    }
}
