using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerController : MonoBehaviour
{
    public float maxSpeed;  //5
    public float jumpForce; //100
    public float moveForce; //365
    public Transform groundCheck;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private InputAction _jump;
    private InputAction _move;
    private float _oldPosition;
    private bool _grounded;
    private bool _initiateJump;
    private bool _isMovingLeft;

    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
        _initiateJump = false;
        _isMovingLeft = false;
        _oldPosition = transform.position.x;
    }
    // todo: Update() vs FixedUpdate();
    void Update()
    {
        _oldPosition = transform.position.x;
        // remember to make all platforms belong to the ground layer
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(_jump.WasPressedThisFrame() && _grounded)
        {
            _initiateJump = true;
        }
        if (transform.position.x < _oldPosition)
        {
            _isMovingLeft = true;
            transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = _move.ReadValue<Vector2>().x;

        // have we reached _maxSpeed? If not, add force.
        // It works going left because horizontalMovement and _myRigidBody.Velocity.x
        // will both be negative at the same time.
        if (horizontalMovement * _myRigidBody.linearVelocityX < maxSpeed)
        {
            _myRigidBody.AddForce(Vector2.right * horizontalMovement * moveForce);
        }
        // Have we exceeded maxSpeed? Set to maxSpeed
        if(Mathf.Abs(_myRigidBody.linearVelocityX) > maxSpeed)
        {
            _myRigidBody.linearVelocity = new Vector2(Mathf.Sign(_myRigidBody.linearVelocityX) * maxSpeed, _myRigidBody.linearVelocityY);
        }
        if(_initiateJump)
        {
            _myRigidBody.AddForce(new Vector2(0f, jumpForce));
            _myAnimator.SetTrigger("Jump");
            _initiateJump = false;
        }
    }
}
