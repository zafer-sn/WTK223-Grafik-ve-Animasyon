using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float move_speed;
    bool facing_right = true;
    Animator animator;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * move_speed, rb2D.linearVelocity.y);
        animator.SetFloat("velocity", Mathf.Abs(rb2D.linearVelocity.x));
        if (rb2D.linearVelocity.x < 0 && facing_right == true)
        {
            FlipFace();
        }
        if((rb2D.linearVelocity.x > 0 && facing_right == false))
        {
            FlipFace();
        }


        /* if(Input.GetKey(KeyCode.T))
        {
            print("GetKey çalıştı");

        } */

    }
    public void FlipFace()
    {
        facing_right = !facing_right;
        transform.localScale = new Vector3(
                -1 * transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z
            );
    }
}
