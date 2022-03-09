using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    private bool alive;
    void Start()
    {
        StartCoroutine(Game());
    }

    
  
    public void SpawnPlayer() {
        GameObject p = Instantiate(player) as GameObject;
        alive = true;
    }
    IEnumerator Game() {
        while (!alive)
        {

            SpawnPlayer();

            yield return new WaitForSeconds(1);
        }

        
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.tag) { 
        
        }
    }*/
}
