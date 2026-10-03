using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int genislik = 10;
    public int uzunluk = 10;
    public GameObject tilePrefab;

    [ContextMenu("Haritayi Olustur")]
    public void HaritaOlustur()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        for (int x = 0; x < genislik; x++)
        {
            for (int z = 0; z < uzunluk; z++)
            {
                GameObject yeniKare = Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                yeniKare.name = $"Kare_{x}_{z}";
                yeniKare.transform.SetParent(this.transform);

                // YENİ EKLENEN KISIM: Kareye koordinatlarını gönderiyoruz
                Tile tileScript = yeniKare.GetComponent<Tile>();
                if (tileScript != null)
                {
                    tileScript.Init(x, z);
                }
            }
        }
    }
}