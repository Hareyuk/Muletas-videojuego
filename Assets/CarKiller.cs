using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarKiller : MonoBehaviour
{
    public SaveReadData dataGame;
    private void Awake()
    {
    }
    public void KilledCharacter()
    {
        dataGame.CharacterDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Penguin")
        {
            Animator anim = GetComponent<Animator>();
            anim.enabled = true;
            anim.Play("death_player_3");
        }
    }

    public void playSoundCar()
    {

        this.GetComponent<soundManager>().PlaySound("car");
    }
}
