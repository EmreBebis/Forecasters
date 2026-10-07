using UnityEngine;

[CreateAssetMenu(fileName = "YeniKart", menuName = "Forecasters/Kart Verisi")]
public class CardData : ScriptableObject
{
    [Header("Temel Bilgiler")]
    public string kartAdi;
    [TextArea(2, 3)] public string aciklama;
    public Sprite kartGorseli;

    [Header("Deste ve Sınıf Kuralları")]
    public KarakterSinifi sinifKisitlamasi;
    public KartKategorisi kategori;

    [Header("Temel Mekanikler")]
    public int apBedeli;
    public int hasar; // Hasar vermiyorsa 0
    public int kalkan; // Kalkan vermiyorsa 0
    public int menzil; 

    [Header("GDD - Stun ve AP Manipülasyonu")]
    public int stunMiktari; // Sersemleme (Tick) kaydırması
    public int apSiler; // Örn: EMP Mermisi (2 AP siler)
    public int apCalar; // Örn: Enerji Sifonu (2 AP çalar)

    [Header("GDD - Kalkan ve Defans Özel Durumları")]
    public bool yansiticiKalkanMi; 
    public bool katmanliKalkanMi; 
    public bool manaKalkaniMi; // Alınan hasarı Can yerine AP'den düşürür

    [Header("GDD - Zemin ve Alan Kontrolü (Zoning)")]
    public bool zeminEtkisiBrakirMi; // Sarmaşık, Zehir, Tuzak veya Ateş Duvarı
    public ZeminTipi zeminTipi; // Hangi tip zemin bırakılacak?
    public int zeminEtkiSuresi; // Kaç tur kalacak? (Tur sonu siliniyorsa 1)

    [Header("GDD - Özel Durum Efektleri (Buff/Debuff)")]
    public bool rakibiIsaretlerMi; // İzli Mermi veya İşaret Fişeği (Silüet/Hasar artışı)
    public bool rakibiKorEderMi; // Kör Edici Atış (Rakip kartları göremez)
    public bool havalanmaSaglarMi; // Havalanma kartı (Engellerin üzerinden geçme)
    public bool sonHamleyseEkstraHasar; // Kuyruk Atışı koşulu

    public enum KartTipi { Saldiri, Savunma, Hareket, OzelYetenek }
    public KartTipi kartTipi;

    public enum KarakterSinifi { Tumu, Buyucu, KeskinNisanci }
    public enum KartKategorisi { CharacterCard, SpecialCard, StandardCard }
    public enum ZeminTipi { Yok, Tuzak, Ates, Zehir, Sarmasik }
}