using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour

{
    [SerializeField] private float speed = 2f;
   // [SerializeField] private float jumpForce = 50f;
    private Rigidbody2D _2rd;
    
    //private bool yer;
    private Animator _ant;
    //private bool jumping;
    




    private void Awake ()
     {
        _2rd = GetComponent<Rigidbody2D>();
       
        _ant = GetComponent<Animator>();
       
    }


    
    private void Update()
    {
        

        if (Input.GetKey("space"))
            {
              
                speed = 5f;
            
        } else
        {
          
                speed = 0f;
            
        }

        _ant.SetFloat("hýz2", speed);
        _2rd.velocity = new Vector2(speed, 0f);
    }




    }


