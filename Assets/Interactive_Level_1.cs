using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Level_1 : MonoBehaviour
{
    public PlayerChara target;
    public GameObject door;
    public GameObject showKeys;
    public bool isTargetFound = false;
    public Sprite doorOpen;
    public GameObject blackScreen;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChara>();
    }

    void Update()
    {
        if(target.pressedUp && isTargetFound)
        {
            door.GetComponent<SpriteRenderer>().sprite = doorOpen;
            target.canInteractue = false;
            Animation animScreen = blackScreen.GetComponent<Animation>();
            animScreen.Play("in_fade");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject == target.gameObject)
        {
            showKeys.SetActive(true);
            isTargetFound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            showKeys.SetActive(false);
            isTargetFound = false;
        }
    }
}
