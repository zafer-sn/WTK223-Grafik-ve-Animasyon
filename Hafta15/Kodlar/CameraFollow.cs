using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float camera_speed;
    private void Update()
    {
        gameObject.transform.position = Vector3.Slerp(
                new Vector3(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                    ),
                new Vector3(
                    player.transform.position.x,
                    player.transform.position.y,
                    gameObject.transform.position.z
                    ),
                camera_speed

            );
    }
}
