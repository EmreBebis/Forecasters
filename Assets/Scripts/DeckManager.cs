using System.Collections.Generic;
using UnityEngine;
using TMPro; // Yazılar için

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    [Header("Kart Listeleri")]
    public List<CardData> anaDeste; // Maça girerken seçilen tüm kartlar
    private List<CardData> cekilecekKartlar = new List<CardData>();
    public List<CardData> iskarta = new List<CardData>(); // İptal edilen / kullanılan kartlar buraya

    [Header("Arayüz Bağlantıları")]
    public TextMeshProUGUI desteSayaciText; // Sol alttaki "28 card" yazısı
    public Transform oyuncuEliPaneli; // Kartların dizileceği alt panel
    public GameObject kartSablonuPrefab; // O boyutunu düzelttiğin ana Prefab

    void Awake() { instance = this; }

    void Start()
    {
        OyunaBasla();
    }

    public void OyunaBasla()
    {
        // Oyuna başlarken ana desteyi kopyala ve karıştır
        cekilecekKartlar = new List<CardData>(anaDeste);
        DesteyiKaristir();
        
        // İlk tur için 5 kart çek
        KartCek(5); 
    }

    void DesteyiKaristir()
    {
        for (int i = 0; i < cekilecekKartlar.Count; i++)
        {
            CardData temp = cekilecekKartlar[i];
            int randomIndex = Random.Range(i, cekilecekKartlar.Count);
            cekilecekKartlar[i] = cekilecekKartlar[randomIndex];
            cekilecekKartlar[randomIndex] = temp;
        }
        Debug.Log("Deste karıştırıldı.");
    }

    public void KartCek(int miktar)
    {
        for (int i = 0; i < miktar; i++)
        {
            // Deste bittiyse ıskartayı geri alıp karıştır (GDD Kuralı)
            if (cekilecekKartlar.Count == 0)
            {
                if (iskarta.Count == 0) break; // Iskarta da boşsa kart çekemez
                
                Debug.Log("Deste bitti, ıskarta yeniden karıştırılıyor!");
                cekilecekKartlar = new List<CardData>(iskarta);
                iskarta.Clear();
                DesteyiKaristir();
            }

            // En üstteki kartı al
            CardData cekilen = cekilecekKartlar[0];
            cekilecekKartlar.RemoveAt(0);

            // UI'da kartı oluştur (Oluşturduğu kartı alt panele yerleştirir)
            GameObject yeniKart = Instantiate(kartSablonuPrefab, oyuncuEliPaneli);
            
            // Kartın verisini içine aktar ki resmini falan güncellesin
            yeniKart.GetComponent<CardDisplay>().kartVerisi = cekilen;
        }

        SayaciGuncelle();
    }

    public void IskartaEkle(CardData kullanilanKart)
    {
        iskarta.Add(kullanilanKart);
    }

    public void SayaciGuncelle()
    {
        if (desteSayaciText != null)
        {
            desteSayaciText.text = cekilecekKartlar.Count + " card";
        }
    }
}