using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OnCollisionEnter2D çalıştı");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("OnCollisionStay2D çalıştı");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("OnCollisionExit2D çalıştı");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D çalıştı");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("OnTriggerStay2D çalıştı");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("OnTriggerExit2D çalıştı");
    }

}
