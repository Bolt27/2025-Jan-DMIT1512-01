using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speedX, speedY;
    public float directionX, directionY;

    public float rotationSpeedZ, rotationDirectionZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementAmount = 
            new Vector2(
                speedX * directionX * Time.deltaTime, 
                speedY * directionY * Time.deltaTime);
        //"transform" automatically refers to the transform of the game object
        //that this script is attached to
        transform.Translate(movementAmount, Space.World);
        //the above is short for 
        //this.gameObject.transform.Translate(movementAmount);

        //we pass it 3 "Euler" values (0-360)
        transform.Rotate(0, 0, rotationSpeedZ * rotationDirectionZ * Time.deltaTime);
        
    }
}
