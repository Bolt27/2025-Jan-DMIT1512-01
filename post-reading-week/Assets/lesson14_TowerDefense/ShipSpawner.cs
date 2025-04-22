using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    protected PrefabPool prefabPool;
    public int numShipsWave01;
    public Transform target;
    void Awake()
    {
        prefabPool = GameObject.Find("PrefabPool").GetComponent<PrefabPool>();
    }
    void Start()
    {
        SpawnWave01();
    }
    protected void SpawnWave01()
    {
        Transform[] ships = new Transform[numShipsWave01];
        for(int c = 0; c < numShipsWave01; c++)
        {
            ships[c] = prefabPool.Ship;
            ships[c].GetComponent<Ship>().target = this.target;
        }

        Vector3 centrePos = target.position;
        //place the ships in a circle
        for (int pointNum = 0; pointNum < numShipsWave01; pointNum++)
        {
            float i = (pointNum * 1.0f) / numShipsWave01;
            // get the angle for this step (in radians, not degrees)
            float angle = i * Mathf.PI * 2;
            // the X & Y position for this angle are calculated using Sin & Cos
            float x = Mathf.Sin(angle) * 10;
            float y = Mathf.Cos(angle) * 10;
            Vector3 pos = new Vector3(x, y, 0) + centrePos;
            // no need to assign the instance to a variable unless you're using it afterwards:
            ships[pointNum].transform.position = pos;
        }
    }
}
