using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTree : MonoBehaviour
{
    public GameObject rayo;
    public GameObject fuego;
    bool startToTime = false;
    float timer = 0;
    private void Update()
    {
        if(startToTime)
        {
            if(timer == 0)
            {
                rayo.SetActive(true);
            }

            timer += Time.deltaTime;
            if(timer > 0.7f)
            {
                fuego.SetActive(true);
            }
            if(timer > 1f)
            {
                rayo.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Penguin")
        {
            startToTime = true;
        }
    }
}
