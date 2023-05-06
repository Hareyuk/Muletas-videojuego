using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    public Animator animGame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Penguin")
        {
            animGame.enabled = true;
            animGame.Play("cutscene");
        }
    }
}
