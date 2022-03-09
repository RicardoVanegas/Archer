using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorm : MonoBehaviour
{
    public int life;
    public Animator anim;
    void Start()
    {
        life = 5;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flecha")
        {
            anim.SetTrigger("hit");
            life--;
           
            if (life == 0)
            {
                anim.SetTrigger("death");
                Invoke("WormDeath", .75f);

            }

        }
    }
    public void WormDeath() {
        Destroy(this.gameObject);
    }

   
}
