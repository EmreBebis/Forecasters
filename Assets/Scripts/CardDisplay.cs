using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardData kartVerisi;
    public Image kartGorselAlani;

    void Start()
    {
        if (kartVerisi != null && kartVerisi.kartGorseli != null)
        {
            kartGorselAlani.sprite = kartVerisi.kartGorseli; 
        }
    }

    // Butona tıklandığında bu çalışacak
    public void KartaTiklandi()
    {
        if (CardManager.instance != null && kartVerisi != null)
        {
            CardManager.instance.KartSec(kartVerisi); // Yöneticiye haber ver
        }
    }
}