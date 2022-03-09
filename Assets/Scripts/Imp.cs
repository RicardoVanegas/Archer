using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : MonoBehaviour
{
    private int life;
    
    private Animator anim;
    public BoxCollider2D imp;
    public SpriteRenderer impSprite;
    public Transform impT;
    private Rigidbody2D imprb;
    public Transform player;
    public float speed;
    public float rango;
    private float posIni;
    private float limD;
    private float limIz;

    private IEnumerator pat;
    
    
    void Start()
    {
        life = 10;
        anim = GetComponent<Animator>();
        imp = GetComponent<BoxCollider2D>();
        impSprite = GetComponent<SpriteRenderer>();
        impT = GetComponent<Transform>();
        imprb = GetComponent<Rigidbody2D>();
        
        posIni = impT.transform.position.x;
        limD = impT.transform.position.x + 4;
        limIz = impT.transform.position.x - 4;
        pat = Patrullaje();
        StartCoroutine(pat);

    }

    
    void Update()
    {

        float distance = Vector2.Distance(impT.position , player.position );
        Debug.Log(distance);
        if (distance < rango) {
            StopCoroutine(pat);
            StartCoroutine(persecucion());
        }
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flecha")
        {
            StopAllCoroutines();
            StartCoroutine(persecucion());
            anim.SetTrigger("hit");
            
            life--;
            if (life == 5) {

                
                imp.GetComponent<Collider2D>().enabled = false;
                anim.SetTrigger("fall");
                
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("stand")) {
                    imp.GetComponent<Collider2D>().enabled = true;

                    

                }
            }
            if (life == 0 ) {
               
                anim.SetTrigger("death");
                Invoke("impDeath",.85f);
                
            }

        }
    }
    private void impDeath() {
        Destroy(this.gameObject);
        StopCoroutine(Patrullaje());
    }

    IEnumerator Patrullaje() {
       
        while (true)
        {
            anim.SetTrigger("walk");
            posIni = impT.transform.position.x;
            impT.transform.Translate(Vector2.right * Time.deltaTime * speed);
            if (posIni > limD)
            {
                impT.transform.eulerAngles = new Vector3(0,180,0);
                

            }else if (posIni < limIz)
            {
                impT.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(.001f);
        }
        
    }
    IEnumerator persecucion() {

        while (true) {
            anim.SetTrigger("walk");
            if (player.position.x < impT.position.x) {
                impT.eulerAngles = new Vector3(0,180,0);
                imprb.velocity= new Vector2(-3,0);
            } else if (player.position.x > impT.position.x) {
                impT.eulerAngles = new Vector3(0, 0, 0);
                imprb.velocity = new Vector2(3, 0);
            }




            yield return new WaitForSeconds(1);
        }
    }
}
