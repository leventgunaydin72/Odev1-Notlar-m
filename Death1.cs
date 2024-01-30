using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Death1 : MonoBehaviour

{
    public TextMeshProUGUI dieText;

    private void Start()
    {
        // TextMeshProUGUI bileþenini al
        dieText = GameObject.Find("diee").GetComponent<TextMeshProUGUI>();
        dieText.gameObject.SetActive(false); // Baþlangýçta kapalý yap
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpýlan nesne oyuncu ise
        if (other.CompareTag("Player"))
        {
            // Oyuncu animasyonunu baþlat
            Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("PlayerDie");
            }

            // Oyuncunun Rigidbody bileþenini al
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            // Oyuncunun CharacterController bileþenini al
            CharacterController playerController = other.GetComponent<CharacterController>();

            // Eðer Rigidbody bileþeni varsa, hýzýný sýfýrla ve düþmeyi dondur
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // Yatay ve dikey hareketi dondur
            }

            // Eðer CharacterController bileþeni varsa, hareketi devre dýþý býrak
            if (playerController != null)
            {
                playerController.enabled = false;
            }

            // DieText'i etkinleþtir
            if (dieText != null)
            {
                dieText.gameObject.SetActive(true);
                dieText.text = "You Die"; // Metni güncelle
            }

            // Düþen nesnenin Rigidbody bileþenini al
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

            // Eðer Rigidbody bileþeni varsa, hýzýný sýfýrla ve düþmeyi dondur
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; // Y sýnýrdaki hareketi dondur
            }

            // Oyunu yeniden baþlatmayý geciktir
            Invoke("RestartScene", 1f);
        }
    }

    private void RestartScene()
    {
        // Oyunu yeniden baþlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}