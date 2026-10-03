using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType { Normal, Cukur, TamBlok }
    
    [Header("Karenin Durumu")]
    public TileType kareTipi = TileType.Normal;

    [Header("Kenar Duvarları")]
    public bool kuzeyDuvar;
    public bool guneyDuvar;
    public bool doguDuvar;
    public bool batiDuvar;

    [Header("Görsel Referanslar")]
    public GameObject floorVisual;
    public GameObject blockVisual;
    public GameObject wallNorth;
    public GameObject wallSouth;
    public GameObject wallEast;
    public GameObject wallWest;

    [Header("Materyaller (Sahnede Sürükle Bırak)")]
    public Material matZemin1;
    public Material matZemin2;
    public Material matEngel;
    public Material matDuvar;

    private int gridX, gridZ;

    // GridManager kareyi yaratırken koordinatları buraya gönderecek
    public void Init(int x, int z)
    {
        gridX = x;
        gridZ = z;
        GorselleriGuncelle();
    }

    private void OnValidate()
    {
        GorselleriGuncelle();
    }

    public void GorselleriGuncelle()
    {
        // Zemin Görseli ve Satranç Deseni
        if (floorVisual != null)
        {
            floorVisual.SetActive(kareTipi == TileType.Normal);
            MeshRenderer mr = floorVisual.GetComponent<MeshRenderer>();
            if (mr != null && matZemin1 != null && matZemin2 != null)
            {
                // x ve z toplamı çift sayıysa 1. materyal, tek sayıysa 2. materyal
                mr.material = ((gridX + gridZ) % 2 == 0) ? matZemin1 : matZemin2;
            }
        }

        // Tam Blok Görseli
        if (blockVisual != null)
        {
            blockVisual.SetActive(kareTipi == TileType.TamBlok);
            MeshRenderer mr = blockVisual.GetComponent<MeshRenderer>();
            if (mr != null && matEngel != null) mr.material = matEngel;
        }

        // Çukur Durumu
        if (kareTipi == TileType.Cukur)
        {
            if (floorVisual != null) floorVisual.SetActive(false);
            if (blockVisual != null) blockVisual.SetActive(false);
        }

        // Duvarları Ayarlama Metodu
        void DuvarAyarla(GameObject duvarObj, bool aktifMi)
        {
            if (duvarObj != null)
            {
                duvarObj.SetActive(aktifMi);
                MeshRenderer mr = duvarObj.GetComponent<MeshRenderer>();
                if (mr != null && matDuvar != null) mr.material = matDuvar;
            }
        }

        DuvarAyarla(wallNorth, kuzeyDuvar);
        DuvarAyarla(wallSouth, guneyDuvar);
        DuvarAyarla(wallEast, doguDuvar);
        DuvarAyarla(wallWest, batiDuvar);
    }
}