using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound : MonoBehaviour
{

    public Transform player;
    
    private Rigidbody2D hound;
    private Transform houndT;
    
   
    void Start()
    {
        player = GetComponent<Transform>();
        houndT = GetComponent<Transform>();
        hound = GetComponent<Rigidbody2D>();
        hound.velocity = new Vector2(-5, 0);
        
       
    }

  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            FindObjectOfType<player_movement>().muerte();  
        }
        if (collision.tag == "limiteIzquierdo") {
            Destroy(this.gameObject);
        }
    }
}
