using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flecha : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        bool direction = FindObjectOfType<player_movement>().facingRight;
        if (direction) {
            rb.velocity = new Vector2(speed, 0);
        } else if (!direction) {
            rb.velocity = new Vector2(speed*-1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hound") {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
        if (collision.tag == "Enemy")
        {
            
            Destroy(this.gameObject);

        }
        if (collision.tag == "limiteIzquierdo" || collision.tag == "limiteDerecho") {
            Destroy(this.gameObject);
        }
    }
}
