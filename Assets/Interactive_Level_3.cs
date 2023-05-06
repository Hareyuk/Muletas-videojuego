using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Level_3 : MonoBehaviour
{
    public GameObject firstPart;
    public GameObject secondPart;
    public bool cars = false;
    public bool hole = false;
    public void StartEvent(float idPlayer)
    {
        if(idPlayer == 0) //first time, cars
        {
            cars = true;
        }
        else //Jump trough the hole
        {
            hole = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
