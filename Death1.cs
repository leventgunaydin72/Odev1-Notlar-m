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
        // TextMeshProUGUI bile�enini al
        dieText = GameObject.Find("diee").GetComponent<TextMeshProUGUI>();
        dieText.gameObject.SetActive(false); // Ba�lang��ta kapal� yap
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arp�lan nesne oyuncu ise
        if (other.CompareTag("Player"))
        {
            // Oyuncu animasyonunu ba�lat
            Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("PlayerDie");
            }

            // Oyuncunun Rigidbody bile�enini al
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            // Oyuncunun CharacterController bile�enini al
            CharacterController playerController = other.GetComponent<CharacterController>();

            // E�er Rigidbody bile�eni varsa, h�z�n� s�f�rla ve d��meyi dondur
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // Yatay ve dikey hareketi dondur
            }

            // E�er CharacterController bile�eni varsa, hareketi devre d��� b�rak
            if (playerController != null)
            {
                playerController.enabled = false;
            }

            // DieText'i etkinle�tir
            if (dieText != null)
            {
                dieText.gameObject.SetActive(true);
                dieText.text = "You Die"; // Metni g�ncelle
            }

            // D��en nesnenin Rigidbody bile�enini al
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

            // E�er Rigidbody bile�eni varsa, h�z�n� s�f�rla ve d��meyi dondur
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; // Y s�n�rdaki hareketi dondur
            }

            // Oyunu yeniden ba�latmay� geciktir
            Invoke("RestartScene", 1f);
        }
    }

    private void RestartScene()
    {
        // Oyunu yeniden ba�lat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}