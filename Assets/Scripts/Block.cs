using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour{

    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable"){
            level.CountBreakableBlocks(); 
        }
       
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                FindObjectOfType<GameStatus>().AddToScore();
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                Destroy(gameObject);
                level.BlockDestroyed();
            }
            else
            {
                int spriteIndex = timesHit - 1;
                if (hitSprites[spriteIndex] != null)
                {
                    GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
                }
                }



        }
    }

  

}


