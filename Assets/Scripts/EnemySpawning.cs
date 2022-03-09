using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject hound;
    public Transform player;
    public SpriteRenderer houndSprite;
    void Start()
    {
        player = GetComponent<Transform>();
        houndSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(spawnEnemy());
    }

  
    void spawn() {
            GameObject a = Instantiate(hound) as GameObject;
            a.transform.position = new Vector2(Random.Range(player.position.x + 30, 500), -3.79f);
    
    }
    IEnumerator spawnEnemy() {
        while (true) {
            yield return new WaitForSeconds(2.5f);
            
            spawn();
        }
    }
  
}
