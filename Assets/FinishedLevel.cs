using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevel : MonoBehaviour
{
    public SaveReadData go;
    public void FinishLevel()
    {
        go.FinishedLevel();
    }

    public void DiedPlayer()
    {
        go.BackLevels();
    }
}
