using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum TurDurumu { Planlama, Isleniyor }
    
    [Header("Tur Ayarları")]
    public float planlamaSuresi = 30f; // Inspector'dan değiştireceğin yer
    
    [Header("Sahnedeki Karakterler")]
    public GridMovement player1;
    public GridMovement player2;
    
    [Header("Canli Takip (Sadece Bilgi İçin)")]
    public float kalanSure;
    public TurDurumu mevcutDurum;

    void Start()
    {
        // Oyun başladığında ilk turu başlat
        YeniTuraGec();
    }

    void Update()
    {
        // Eğer planlama aşamasındaysak süreyi geriye doğru say
        if (mevcutDurum == TurDurumu.Planlama)
        {
            kalanSure -= Time.deltaTime; // Time.deltaTime saniyeleri gerçek zamanlı düşürür
            
            // Süre sıfırın altına düştüğünde
            if (kalanSure <= 0)
            {
                HamleleriUygula();
            }
        }
    }

    public void YeniTuraGec()
    {
        mevcutDurum = TurDurumu.Planlama;
        kalanSure = planlamaSuresi; // Sayacı senin belirlediğin süreye sıfırla
        Debug.Log($"--- YENİ TUR BAŞLADI! Süre: {planlamaSuresi} saniye ---");
    }

   void HamleleriUygula()
    {
        mevcutDurum = TurDurumu.Isleniyor;
        kalanSure = 0;
        
        Debug.Log("SÜRE DOLDU! Hamleler oynatiliyor...");
        
        // TEST HAMLESİ: P1'i X ekseninde (sağa) 1 kare, P2'yi Z ekseninde (ileriye) 1 kare yürüt
        //if (player1 != null) player1.HedefeGit(player1.transform.position + new Vector3(1, 0, 0));
        //if (player2 != null) player2.HedefeGit(player2.transform.position + new Vector3(0, 0, 1));
        
        Invoke("YeniTuraGec", 3f); // 3 saniye sonra yeni tur
    }
}