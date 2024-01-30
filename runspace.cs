using UnityEngine;
using TMPro;

public class Runspace : MonoBehaviour
{
    public TextMeshProUGUI textMeshProYazi;
    private bool ilkBastirma = true;

    void Start()
    {
        // Ba�lang��ta yaz�y� a��k hale getir
        textMeshProYazi.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ilkBastirma)
        {
            ToggleYaziDurumu();
            ilkBastirma = false;
        }
    }

    void ToggleYaziDurumu()
    {
        // Space tu�una bas�ld���nda yaz�n�n durumunu tersine �evir
        bool yeniDurum = !textMeshProYazi.gameObject.activeSelf;
        textMeshProYazi.gameObject.SetActive(yeniDurum);
    }
}