using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life_time;
    public static float damage = 20f;
    private void Start()
    {
        Destroy(gameObject, life_time);
    }
}
