using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downfall : MonoBehaviour
{
    public Transform Player; // Oyuncu karakterin referans�
    public float triggerDistance = 5f; // Tetikleme mesafesi

    private bool hasFallen = false; // Nesnenin daha �nce d���p d��medi�ini kontrol etmek i�in

    void Update()
    {
        // E�er nesne daha �nce d��mediyse ve oyuncu karakter belirli bir mesafede ise
        if (!hasFallen && Player != null && Mathf.Abs(Player.position.x - transform.position.x) < triggerDistance)
        {
            // Nesnenin d��mesini sa�la
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            hasFallen = true; // Nesne bir kere d��t���nde tekrar d��memesi i�in i�aretle
        }
    }
}