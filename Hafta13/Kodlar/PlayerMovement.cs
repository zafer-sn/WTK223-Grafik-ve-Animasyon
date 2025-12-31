using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float move_speed;
    bool facing_right = true;
    Animator animator;
    public float jump_speed;
    public bool is_grounded;
    public Transform ground_transform;
    public float ground_radius;
    public LayerMask ground_layer;
    public float next_jump_time;
    public float jump_frequency;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float move = Input.GetAxis("Horizontal"); // Yatay
        // Vertical dikey
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
        // next_jump_time = 0 
        // jump_frequency = 0 = 1
        // 0 < 5
        // next_jump_time = 1 + 5
        // 6 < 5
        if(Input.GetAxis("Vertical") > 0 && is_grounded == true && next_jump_time < Time.timeSinceLevelLoad)
        {
            rb2D.AddForce(new Vector2(0f, jump_speed));
            next_jump_time = jump_frequency + Time.timeSinceLevelLoad;
        }
        GroundCheck();

        /* if(Input.GetKey(KeyCode.T))
        {
            print("GetKey çalıştı");

        } */

    }
    public void GroundCheck()
    {
        is_grounded = Physics2D.OverlapCircle(
            ground_transform.position,
            ground_radius,
            ground_layer
            );
        animator.SetBool("isGround", is_grounded);
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
