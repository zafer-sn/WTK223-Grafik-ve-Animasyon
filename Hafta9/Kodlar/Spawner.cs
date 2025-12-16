using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallen_object;
    public float fallen_time = 3f;
    private void Update()
    {
        // time.deltaTime = 2 frame arasında geçen süreyi saniye cinsinden verir.
        fallen_time -= Time.deltaTime;
        if(fallen_time <= 0)
        {
            float spawn_loc = UnityEngine.Random.Range(-2.5f, 2.5f);
            Instantiate(
                fallen_object,
                new Vector2(spawn_loc, 6f),
                Quaternion.identity
                );
            fallen_time = 3f;
        }
    }
}
