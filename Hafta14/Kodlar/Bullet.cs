using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life_time;
    private void Start()
    {
        Destroy(gameObject, life_time);
    }
}
