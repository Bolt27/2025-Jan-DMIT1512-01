using Unity.VisualScripting;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speedX, speedY;
    public float directionX, directionY;

    public float rotationSpeedZ, rotationDirectionZ;

    public Vector3 scaleChangeDirection;
    public Vector3 scaleChangeSpeed;
    public Vector3 scaleChangeMax;
    public Vector3 scaleChangeMin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementAmount = 
            new Vector2(speedX * directionX, speedY * directionY)  * Time.deltaTime;
        
        //"transform" automatically refers to the transform of the game object
        //that this script is attached to
        transform.Translate(movementAmount, Space.World);
        //the above is short for 
        //this.gameObject.transform.Translate(movementAmount);

        //we pass it 3 "Euler" values (0-360)
        transform.Rotate(0, 0, rotationSpeedZ * rotationDirectionZ * Time.deltaTime);

        // Find the screen bounds in world space
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        float left = bottomLeft.x;
        float right = topRight.x;
        //EXERCISE (2025-01-16): fix the below so that it accurately bounces off the edges of the screen
        //(2025-01-21 - Solution is below)
        float width = GetComponent<Renderer>().bounds.size.x;
        if(transform.position.x + (width / 2) >= right || transform.position.x - (width / 2) <= left)
        {
            directionX *= -1;
        }

        //EXERCISE: (2025-01-21) do the same for Y (2025-01-21: SOLUTION below)
        float top = topRight.y;
        float bottom = bottomLeft.y;
        float height = GetComponent<Renderer>().bounds.size.y;
        if(transform.position.y + (height / 2) >= top || transform.position.y - (height / 2) <= bottom)
        {
            directionY *= -1;
        }

        Vector3 scaleChange = scaleChangeDirection + scaleChangeSpeed;
        scaleChange *= Time.deltaTime;
        transform.localScale += scaleChange;
        if(transform.localScale.x > scaleChangeMax.x || transform.localScale.x < scaleChangeMin.x)
        {
            scaleChangeDirection.x *= -1;
        }
        if(transform.localScale.y > scaleChangeMax.y || transform.localScale.y < scaleChangeMin.y)
        {
            scaleChangeDirection.y *= -1;
        }

    }
}
