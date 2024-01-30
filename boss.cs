using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class boss : MonoBehaviour
{
    public TextMeshProUGUI youWinMetni;
    public GameObject kapiObjesi;
    public float gorunmeSuresi = 2f; // Yazýnýn ve kapýnýn kaç saniye boyunca görüneceðini belirler

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AktivasyonuYonet(true);
            Invoke("YaziyiKapat", gorunmeSuresi);
            Invoke("KapiyiKapat", gorunmeSuresi);
        }
    }

    private void AktivasyonuYonet(bool durum)
    {
        youWinMetni.gameObject.SetActive(durum);
    }

    private void YaziyiKapat()
    {
        AktivasyonuYonet(false);
    }

    private void KapiyiKapat()
    {
        kapiObjesi.SetActive(false);
    }
}