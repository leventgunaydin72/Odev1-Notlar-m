using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
  
    private int sayma;
    [SerializeField] AudioClip _ses;
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("topla"))
        {
            sayma++;
            AudioSource.PlayClipAtPoint(_ses, other.transform.position);
            Destroy(other.gameObject);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
