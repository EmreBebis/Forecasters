using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float hareketHizi = 5f;
    
    private Vector3 hedefPozisyon;
    private bool hareketEdiyorMu = false;

    void Start()
    {
        // Oyun başladığında durduğu yeri hedef belle (yanlışlıkla kaymasın)
        hedefPozisyon = transform.position;
    }

    void Update()
    {
        // Eğer GameManager "hareket et" dediyse
        if (hareketEdiyorMu)
        {
            // Pürüzsüzce hedefe doğru kay
            transform.position = Vector3.MoveTowards(transform.position, hedefPozisyon, hareketHizi * Time.deltaTime);

            // Hedefe ulaştıysa dur
            if (Vector3.Distance(transform.position, hedefPozisyon) < 0.01f)
            {
                transform.position = hedefPozisyon; // Kareye tam oturt
                hareketEdiyorMu = false;
            }
        }
    }

    // GameManager zaman dolduğunda bu metodu çağıracak
    public void HedefeGit(Vector3 yeniHedef)
    {
        // Hedefi Y ekseninde (yukarıda) piyonun boyuna göre ayarla ki yerin içine girmesin
        hedefPozisyon = new Vector3(yeniHedef.x, transform.position.y, yeniHedef.z);
        hareketEdiyorMu = true;
    }
}