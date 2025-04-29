using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    public float initialForwardAngle = 90, maxRotationSpeed = 60, threshold = 4;
    public float averageNumShotsPerSecond = 0.01f, projectileForce = 1000;
    public int rotationSpeed;
    private InputAction _rotate, _shoot;
    private PrefabPool _prefabPool;
    private Transform _target;

    void Awake()
    {
        // _rotate = InputSystem.actions.FindAction("Move");
        // _shoot = InputSystem.actions.FindAction("Jump");
        _prefabPool = GameObject.Find("PrefabPool").GetComponent<PrefabPool>();

    }
    void Update()
    {
        if(_target == null || !_target.gameObject.activeInHierarchy)
        {
            GameObject[] enemyShips = GameObject.FindGameObjectsWithTag("EnemyShip");
            int randomShip = Random.Range(0, enemyShips.Length);
            _target = enemyShips[randomShip].transform;
        }
        
        RotateGradually2D();
        Shoot();
    }
    #region RotateGradually2D();
    //cnobert: adapted this code from 
    //https://answers.unity.com/questions/624856/rotate-2d-turret-toward-target-heading-lerpangle.html
    private float currentAngle = 0; // Current angle
    protected void RotateGradually2D()
    {
        float angleToTarget; // Destination angle
        float signToTarget;
        angleToTarget = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg;
        signToTarget = Mathf.Sign(angleToTarget - currentAngle);
        if (Mathf.Abs(angleToTarget - currentAngle) > threshold)
        {
            currentAngle += signToTarget * maxRotationSpeed * Time.deltaTime;
        }
        else
        {
            currentAngle = angleToTarget;
        }
        //cnobert 2022/04/11 added "+ 90" because it was off by 90 degrees
        transform.parent.transform.eulerAngles = new Vector3(0, 0, currentAngle - initialForwardAngle + 90);
    }
    #endregion

    protected void Shoot()
    {

        int highEndOfRange = (int)(1 / averageNumShotsPerSecond) * 60;
        int random = Random.Range(1, highEndOfRange);
        if(random == 1)
        {
            // Get a donut, fling it!
            Transform donut = _prefabPool.Projectile;

            Transform childTransform = transform.GetChild(0);
            
            donut.position = childTransform.position;
            
            donut.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileForce);
            
            donut.GetComponent<Rigidbody2D>().AddTorque(500);
        }

        
    }
}
