using TMPro;
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
    public Transform spawn_point; // null, none
    public GameObject bullet;
    public Transform muzzle_position;
    public float force_magnitude;
    public int score;
    public TMP_Text score_text;

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
        if(Input.GetKeyDown(KeyCode.E))
        {
            ShootBullet();
        }
        if(gameObject.transform.position.y < -10)
        {
            gameObject.transform.position = spawn_point.position;
        }

    }
    public void ShootBullet()
    {
        GameObject temp_bullet;
        temp_bullet = Instantiate(bullet, muzzle_position.position, Quaternion.identity);
        temp_bullet.GetComponent<Rigidbody2D>().AddForce(muzzle_position.forward * force_magnitude);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Saw"))
        {
            //Destroy(gameObject);
            gameObject.transform.position = spawn_point.position;
        }      
        if(collision.gameObject.CompareTag("Spike"))
        {
            gameObject.transform.position = spawn_point.position;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            score++;
            score_text.text = $"Puan: {score}";
            Destroy(collision.gameObject);
        }
    }





}
