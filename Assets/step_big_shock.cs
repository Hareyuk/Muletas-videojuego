using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step_big_shock : MonoBehaviour
{
    public GameObject rayo;
    public GameObject cloud;
    bool startToTime = false;
    float timer = 0;
    private void Update()
    {
        if (startToTime)
        {
            if (timer == 0) cloud.SetActive(true);
            if(timer > 0.25f) cloud.SetActive(false);
            if (timer > 0.5f) cloud.SetActive(true);
            if (timer > 0.75f) cloud.SetActive(false);
            if (timer > 1f) cloud.SetActive(true);
            if (timer > 1f) rayo.SetActive(true);
            if (timer > 1.3f) cloud.SetActive(false);
            if (timer > 1.3f) rayo.SetActive(false);
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Penguin")
        {
            startToTime = true;
        }
    }
}
