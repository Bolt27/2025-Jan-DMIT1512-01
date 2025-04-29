using UnityEngine;

public class ClickInterceptor : MonoBehaviour
{
    private PrefabPool _prefabPool;
    void Awake()
    {
        _prefabPool = GameObject.Find("PrefabPool").GetComponent<PrefabPool>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;

            Transform projectile = _prefabPool.Turret;
            projectile.position = worldPosition;
        }
    }
}
