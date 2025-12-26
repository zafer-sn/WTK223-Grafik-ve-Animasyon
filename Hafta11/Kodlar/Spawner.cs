using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fallen_objects = new GameObject[3];
    public float fallen_time = 3f;
    private void Update()
    {
        // time.deltaTime = 2 frame arasında geçen süreyi saniye cinsinden verir.
        fallen_time -= Time.deltaTime;
        if(fallen_time <= 0)
        {
            float spawn_loc = UnityEngine.Random.Range(-2.5f, 2.5f);
            GameObject local_fallen_object = Instantiate(
                fallen_objects[UnityEngine.Random.Range(0, 3)],
                new Vector2(spawn_loc, 6f),
                Quaternion.identity
                );
            local_fallen_object.GetComponent<SpriteRenderer>().color = new Color32(
                    Convert.ToByte(UnityEngine.Random.Range(0, 255)),
                    Convert.ToByte(UnityEngine.Random.Range(0, 255)),
                    Convert.ToByte(UnityEngine.Random.Range(0, 255)),
                    Convert.ToByte(UnityEngine.Random.Range(0, 255))
                );
            fallen_time = 3f;
        }
    }
}
