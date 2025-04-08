using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerController : MonoBehaviour
{
    public float maxSpeed; //5
    public float jumpForce;//100
    public float moveForce;//365
    public Transform groundCheck;
    private Rigidbody2D _myRigidBody;
    private InputAction _jump;
    private InputAction _move;
    private bool _grounded;
    private bool _jumping;

    void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
        _jumping = false;
    }

    //todo: Update() vs. FixedUpdate()
    void Update()
    {
        //remember to make all platforms belong to the "Ground" layer
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(_jump.WasPressedThisFrame() && _grounded)
        {
            _jumping = true;
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
            _myRigidBody.linearVelocity = 
                new Vector2(Mathf.Sign( _myRigidBody.linearVelocityX) * maxSpeed, 
                                        _myRigidBody.linearVelocityY);
        }
        if(_jumping)
        {
            _myRigidBody.AddForce(new Vector2(0f, jumpForce));
            _jumping = false;
        }
    }
}
