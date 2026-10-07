using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public int maxSutunX = 8;
    public int maxSatirZ = 8;
    public float kareBoyutu = 1f;

    public int guncelX = 0;
    public int guncelZ = 0;

    void Start()
    {
        PozisyonuGuncelle();
    }

    public void HamleYap(int xArtis, int zArtis)
    {
        int hedefX = guncelX + xArtis;
        int hedefZ = guncelZ + zArtis;

        if (hedefX >= 0 && hedefX < maxSutunX && hedefZ >= 0 && hedefZ < maxSatirZ)
        {
            guncelX = hedefX;
            guncelZ = hedefZ;
            PozisyonuGuncelle();
        }
    }

    public void PozisyonuGuncelle()
    {
        Vector3 merkezKonum = new Vector3(guncelX * kareBoyutu, transform.position.y, guncelZ * kareBoyutu);
        transform.position = merkezKonum;
    }
}