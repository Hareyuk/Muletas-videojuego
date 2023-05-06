using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Level_3 : MonoBehaviour
{
    public GameObject secondPart;
    public PlayerChara player;
    public GameObject blackScreen;
    public void StartEvent(float idPlayer)
    {
        if(idPlayer > 0) //Not first life
        {
            secondPart.SetActive(true);
            player.canJumpLevel = true;
        }
        else
        {
            player.canJumpLevel = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Penguin")
        {
            Animation animScreen = blackScreen.GetComponent<Animation>();
            animScreen.Play("in_fade");
        }
    }
}
