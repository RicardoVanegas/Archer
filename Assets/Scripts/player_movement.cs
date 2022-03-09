using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player_movement : MonoBehaviour
{
    
    private Animator anim;
    private Transform t;
    public GameObject flecha;
    private float flechaX;
    private float flechaY;
    private bool isJumping= false;
    SpriteRenderer playerSprite;
    public bool facingRight;
    public SpriteRenderer arrowSprite;
    public Transform flechapos;
    public Text text;
    private int score=10;
    private Rigidbody2D rbPlayer;
    private AudioSource disparo;
    
    void Start()
    {
        text.text=score.ToString();
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        facingRight = true;
        arrowSprite = GetComponent<SpriteRenderer>();
        flechapos = GetComponent<Transform>();
        rbPlayer = GetComponent<Rigidbody2D>();
        disparo = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        text.text=score.ToString();
        float h = Input.GetAxis("Horizontal");


        if (h < 0) {
            playerSprite.flipX = true;
            facingRight = false;
        } else if (h>0) {
            playerSprite.flipX = false;
            facingRight = true;
        }
        
        t.Translate(h * 5 * Time.deltaTime, 0, 0);

        anim.SetFloat("speedRun",h);
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
        if (Input.GetKeyUp(KeyCode.Space) && !anim.GetCurrentAnimatorStateInfo(0).IsName("player_attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Fall")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Death")) {


            anim.SetTrigger("attackTrigger");
           
            Invoke("dispara", .65f);

            disparo.Play();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            anim.SetTrigger("dashTrigger");
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){

            if (!isJumping)
            {
                anim.SetTrigger("JumpTrigger");

                salto();
            }

        }

        flechaX = t.transform.position.x;
        flechaY = t.transform.position.y +.8f;
        
       
    }
    public void dispara() {
        if (facingRight)
        {
            GameObject a = Instantiate(flecha) as GameObject;
            a.transform.position = new Vector2(flechaX, flechaY);
            arrowSprite.flipX = false;
        }
        else if (!facingRight)
        {
            GameObject a = Instantiate(flecha) as GameObject;
            a.transform.position = new Vector2(flechaX, flechaY);
            arrowSprite.flipX = true;
        }

    }
    public void muerte() {
        anim.SetTrigger("deathTrigger");
        score--;
      
        
    }
    public void salto(){
        rbPlayer.velocity = new Vector2(0, 8.5f);
        isJumping = true;
    }
    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.layer==8){
          
            isJumping=false;
        }
        if (c.gameObject.layer==9 ) {
            SceneManager.LoadScene("Level 02");
        }
    }
  
}
