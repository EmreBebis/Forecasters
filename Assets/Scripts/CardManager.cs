using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance; // Diğer scriptlerden kolayca ulaşmak için

    [Header("Sol Panel (İnfo) Bağlantisi")]
    public Image detayResmi; // Sol paneldeki büyük kart görseli
    
    [Header("Canlı Takip")]
    public CardData seciliKart; // O an elimizde tuttuğumuz kart

    void Awake()
    {
        instance = this;
    }

    public void KartSec(CardData tiklananKart)
    {
        seciliKart = tiklananKart;
        
        // Sol paneldeki resmi seçilen kartın resmiyle değiştir
        if (tiklananKart.kartGorseli != null)
        {
            detayResmi.sprite = tiklananKart.kartGorseli;
            detayResmi.color = Color.white; // Eğer başta saydamsa görünür yap
        }
        
        Debug.Log($"<color=green>{tiklananKart.kartAdi}</color> aktif edildi! Şimdi haritadan bir hedef kare seçin.");
    }
}