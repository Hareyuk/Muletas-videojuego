using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevel : MonoBehaviour
{
    public SaveReadData go;
    public GameObject blackScreen;
    public void FinishLevel()
    {
        go.FinishedLevel();
    }

    public void FinishGame()
    {
        Animation animScreen = blackScreen.GetComponent<Animation>();
        animScreen.Play("in_fade");
    }

    public void DiedPlayer()
    {
        go.BackLevels();
    }
}
