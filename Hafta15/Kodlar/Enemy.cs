using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public Slider health_slider;    
    private void Update()
    {
        health_slider.value = health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= Bullet.damage;
            Destroy(collision.gameObject);
        }
    }
}
