using UnityEngine;
public class PrefabPool : MonoBehaviour
{
    private void Awake()
    {
        InitializeProjectiles();
    }
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
}