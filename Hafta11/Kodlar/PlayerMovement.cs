using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 3f;
    public float screen_width = 5.62f;
    int puan = 0;
    public TMP_Text puan_text;
    public TMP_Text winner_loser_text;
    public GameObject game_over_panel;
    private void Update()
    {
        float yon = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2
            (
            yon * move_speed, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y
            );
        if (gameObject.transform.position.x > screen_width)
        {
            gameObject.transform.position -= new Vector3(screen_width, 0, 0);
        } else if (gameObject.transform.position.x < -screen_width)
        {
            gameObject.transform.position += new Vector3(screen_width, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Circle_Fallen"))
        {
            Destroy(collision.gameObject);
            puan -= 10;
            puan_text.text = $"Puan: {puan}";
            if (puan < 0)
            {
                winner_loser_text.text = "GAME OVER!";
                game_over_panel.SetActive(true);
                Time.timeScale = 0;
            }
        } 
        else if (collision.gameObject.CompareTag("Square_Fallen"))
        {
            Destroy(collision.gameObject);
            puan += 20;
            puan_text.text = $"Puan: {puan}";
            if (puan >= 100)
            {
                winner_loser_text.text = "VICTORY!";
                game_over_panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Triangle_Fallen"))
        {
            Destroy(collision.gameObject);
            puan += 30;
            puan_text.text = $"Puan: {puan}";
            if (puan >= 100)
            {
                winner_loser_text.text = "VICTORY!";
                game_over_panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }    

    public void quit_game()
    {
        Application.Quit();
    }

    public void restart_level()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
