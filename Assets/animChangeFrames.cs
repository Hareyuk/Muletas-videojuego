using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animChangeFrames : MonoBehaviour
{
    public int numImg = 0;
    public Sprite[] listSprites;
    public float maxTimer = 0.35f;
    float timer = 0;
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
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
            numImg += 1;
            if (numImg > listSprites.Length-1) numImg = 0;
            render.sprite = listSprites[numImg];
        }
    }
}
