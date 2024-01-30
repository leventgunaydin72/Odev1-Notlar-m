using UnityEngine;
using TMPro;

public class Runspace : MonoBehaviour
{
    public TextMeshProUGUI textMeshProYazi;
    private bool ilkBastirma = true;

    void Start()
    {
        // Baþlangýçta yazýyý açýk hale getir
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
        // Space tuþuna basýldýðýnda yazýnýn durumunu tersine çevir
        bool yeniDurum = !textMeshProYazi.gameObject.activeSelf;
        textMeshProYazi.gameObject.SetActive(yeniDurum);
    }
}