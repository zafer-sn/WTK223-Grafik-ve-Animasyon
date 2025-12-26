using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
