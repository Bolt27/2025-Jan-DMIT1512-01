using UnityEngine;
public class PrefabPool : MonoBehaviour
{
    private void Awake()
    {
        InitializeProjectiles();
        InitializeShips();
        InitializeTurrets();
    } 

    #region Turrets
    public int numTurretsInScene;
    public Transform turretPrefab;
    protected Transform[] turretPool = new Transform[0];
     public void InitializeTurrets()
    {
        if (turretPool.Length == 0)
        {
            turretPool = new Transform[numTurretsInScene];
            for (int c = 0; c < numTurretsInScene; c++)
            {
                turretPool[c] = Instantiate(turretPrefab, this.gameObject.transform);
                turretPool[c].gameObject.SetActive(false);
            }
        }
    }
    public Transform Turret
    {
        get
        {
            Transform returnTransform = null;
            int c = 0;
            while (c < turretPool.Length && returnTransform == null)
            {
                if (!turretPool[c].gameObject.activeInHierarchy)
                {
                    returnTransform = turretPool[c];
                    turretPool[c].gameObject.SetActive(true);
                }
                c++;
            }
            return returnTransform;
        }
    }
    #endregion



    #region Ships
    public int numShipsInScene;
    public Transform shipPrefab;
    protected Transform[] shipPool = new Transform[0];
     public void InitializeShips()
    {
        if (shipPool.Length == 0)
        {
            shipPool = new Transform[numShipsInScene];
            for (int c = 0; c < numShipsInScene; c++)
            {
                shipPool[c] = Instantiate(shipPrefab, this.gameObject.transform);
                shipPool[c].gameObject.SetActive(false);
            }
        }
    }
    public Transform Ship
    {
        get
        {
            Transform returnTransform = null;
            int c = 0;
            while (c < shipPool.Length && returnTransform == null)
            {
                if (!shipPool[c].gameObject.activeInHierarchy)
                {
                    returnTransform = shipPool[c];
                    shipPool[c].gameObject.SetActive(true);
                }
                c++;
            }
            return returnTransform;
        }
    }
    #endregion

    #region Projectiles
    public int numPlayerProjectilesInScene;
    public Transform projectilePrefab;
    protected Transform[] projectilePool = new Transform[0];
    public void InitializeProjectiles()
    {
        if (projectilePool.Length == 0)
        {
            projectilePool = new Transform[numPlayerProjectilesInScene];
            for (int c = 0; c < numPlayerProjectilesInScene; c++)
            {
                projectilePool[c] = Instantiate(projectilePrefab, this.gameObject.transform);
                projectilePool[c].gameObject.SetActive(false);
            }
        }
    }
    public Transform Projectile
    {
        get
        {
            Transform returnTransform = null;
            int c = 0;
            while (c < projectilePool.Length && returnTransform == null)
            {
                if (!projectilePool[c].gameObject.activeInHierarchy)
                {
                    returnTransform = projectilePool[c];
                    projectilePool[c].gameObject.SetActive(true);
                }
                c++;
            }
            return returnTransform;
        }
    }
    #endregion
}