using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    public float rotationSpeed;
    private InputAction _rotate, _shoot;
    private PrefabPool _prefabPool; 
    void Awake()
    {
        _rotate = InputSystem.actions.FindAction("Move");
        _shoot = InputSystem.actions.FindAction("Jump");
        _prefabPool = GameObject.Find("PrefabPool").GetComponent<PrefabPool>();
    }
    void Update()
    {
        Transform turretBase = transform.parent;
        float rotationDirection = _rotate.ReadValue<Vector2>().x;

        //times -1 to make it rotate in an intuitive direction
        turretBase.Rotate(new Vector3(0, 0, -1 * rotationDirection * rotationSpeed * Time.deltaTime));
        
        if(_shoot.WasPressedThisFrame())
        {
            Shoot();
        }
    }
    protected void Shoot()
    {
        //get a donut, fling it
        Transform donut = _prefabPool.Projectile;
        Transform childTransform = transform.GetChild(0);
        donut.position = childTransform.position;
        donut.GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
        donut.GetComponent<Rigidbody2D>().AddTorque(500);
    }
}
