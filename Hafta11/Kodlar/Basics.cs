using UnityEngine;

public class Basics : MonoBehaviour
{
    // Oyun başladığı anda 1 kez çalışacak işlemler buraya yazılır
    // Script aktif değilse çalışmaz.
    private void Start()
    {
        print("Start calisti");
    }
    
    // Oyun başladığı anda 1 kez çalışacak işlemler buraya yazılır, Unity'de ilk çalışan metottur. Her zaman Start'tan önce çalışır.
    // Script aktif olmasa bile çalışır.
    private void Awake()
    {
        print("Awake calisti");
    }
    // Bu metot sürekli çalışır.
    // Kaç FPS alıyorsanız saniyede o kadar çalışır.
    // 250 FPS alıyorsam Update saniye de kaç kez çalışır? 250
    private void Update()
    {
        print("Update calisti");
    }
    // Varsayılan olarak saniyede her zaman 50 kez çalışır.
    private void FixedUpdate()
    {
        print("FixedUpdate calisti");
    }
    // Update ile aynı sayıda çalışır, farkı Update'ten daima sonra çalışır.
    private void LateUpdate()
    {
        print("LateUpdate calisti");
    }
}
