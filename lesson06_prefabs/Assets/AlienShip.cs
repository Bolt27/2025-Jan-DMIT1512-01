using UnityEngine;

public class AlienShip : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int upperRandomRangeForFiringRate;

    void Update()
    {
        int rando = Random.Range(1, upperRandomRangeForFiringRate);
        if(rando == 1)
        {
            Fire();
        }
    }
    private void Fire()
    {
        //instantiate one projectile prefab
        GameObject projectile = Instantiate(projectilePrefab);

        float myHeight = GetComponent<Renderer>().bounds.size.y;
        float projectileHeight = projectile.GetComponent<Renderer>().bounds.size.y;
        Vector3 newPosition = transform.position - new Vector3(0, (myHeight / 2) + (projectileHeight / 2), 0);
        projectile.transform.position = newPosition;

        //in-class exercise: set the direction and speed of the projectile from here
        projectile.GetComponent<Projectile>().direction.y = -1;
        projectile.GetComponent<Projectile>().speed = 10;
    }
}
