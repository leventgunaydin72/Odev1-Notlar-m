using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downfall : MonoBehaviour
{
    public Transform Player; // Oyuncu karakterin referansý
    public float triggerDistance = 5f; // Tetikleme mesafesi

    private bool hasFallen = false; // Nesnenin daha önce düþüp düþmediðini kontrol etmek için

    void Update()
    {
        // Eðer nesne daha önce düþmediyse ve oyuncu karakter belirli bir mesafede ise
        if (!hasFallen && Player != null && Mathf.Abs(Player.position.x - transform.position.x) < triggerDistance)
        {
            // Nesnenin düþmesini saðla
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            hasFallen = true; // Nesne bir kere düþtüðünde tekrar düþmemesi için iþaretle
        }
    }
}