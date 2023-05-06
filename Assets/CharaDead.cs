using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDead : MonoBehaviour
{
    int spriteNum = 1;
    public Sprite ghost1;
    public Sprite ghost2;
    float timer = 0;
    float maxTimer = 0.5f;
    SpriteRenderer render;
    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > maxTimer)
        {
            timer = 0;
            if(spriteNum == 1)
            {
                spriteNum = 2;
                render.sprite = ghost2;
            }
            else
            {
                spriteNum = 1;
                render.sprite = ghost1;
            }
        }
    }
}
