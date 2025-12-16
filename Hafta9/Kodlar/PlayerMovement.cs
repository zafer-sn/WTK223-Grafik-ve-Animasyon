using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 3f;
    private void Update()
    {
        float yon = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2
            (
            yon * move_speed, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y
            );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fallen"))
        {
            Destroy(collision.gameObject);
        }
    }
}
