using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_level_4 : MonoBehaviour
{
    public GameObject blackScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Penguin")
        {
            Animation animScreen = blackScreen.GetComponent<Animation>();
            animScreen.Play("in_fade");
        }
    }
}
