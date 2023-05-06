using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class SaveReadData : MonoBehaviour
{
    public float level = -1; //Asign manual this

    //From below, everything updated by saved data
    public int idCharacter = -1;
    public int restartData = 0;
    public bool[] charas_deaths = new bool[5] { false, false, false, false, false };
    public int[] where_deaths = new int[5] { -1, -1, -1, -1, -1 };
    public Vector2[] charas_positions_deaths = new Vector2[5] { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) };
    public GameObject organizeLevels;
    public GameObject[] tombsPlayers = new GameObject[4] { null, null, null,null };
    public GameObject blackScreen;
    
    void Awake()
    {
        CheckIfData();
        GetData();
        UpdatePlayer();
        switch(level)
        {
            case 0:
                //Nivel 1
                break;
            case 1:
                //Nivel 2
                break;
            case 2:
                //Nivel 3
                organizeLevels.GetComponent<Interactive_Level_3>().StartEvent(idCharacter);
                break;
            case 3:
                //Nivel 4
                break;
            case 4:
                //Nivel final
                break;
        }

        //Check dead players
        if(level > 0)
        {
            for(int i=0;i<4;i++)
            {
                if(charas_deaths[i] && where_deaths[i] == level)
                {
                    //Colocate the tomb
                    tombsPlayers[i].transform.position = charas_positions_deaths[i];
                }
            }
        }
    }

    public void UpdatePlayer()
    {
        PlayerChara player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChara>();
        player.UpdateChara(idCharacter);
    }

    public void CharacterDead()
    {
        charas_deaths[idCharacter] = true;
        where_deaths[idCharacter] = (int)level;
        PlayerChara player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChara>();
        charas_positions_deaths[idCharacter] = player.transform.position;
        player.Die();
        idCharacter++;
        SaveData();
        Animation animScreen = blackScreen.GetComponent<Animation>();
        animScreen.Play("in_fade_death");
    }

    public void BackLevels()
    {
        if (idCharacter == 4) SceneManager.LoadScene("Game Over");
        else SceneManager.LoadScene("Level 1");
    }

    public void CheckIfData()
    {
        if (PlayerPrefs.GetInt("existData") == 1)
        {
            if(PlayerPrefs.GetInt("restartData") == 1)
            {
                CreateData();
            }
        }
        else
        {
            print("No existe dato");
            CreateData();
        }
    }

    public void GetData()
    {
        idCharacter = PlayerPrefs.GetInt("IdCharacter");
        for(int i=0;i<5;i++)
        {
            bool died;
            if (PlayerPrefs.GetInt("character_" + i + "_died") == 0) died = false;
            else died = true;
            charas_deaths[i] = died;
        }

        for (int i = 0; i < 5; i++)
        {
            where_deaths[i] = PlayerPrefs.GetInt("death_"+i+"_level");
        }

        for (int i = 0; i < 5; i++)
        {
            charas_positions_deaths[i] = new Vector2(PlayerPrefs.GetFloat("death_"+i+"_x"), PlayerPrefs.GetFloat("death_" + i + "_y"));
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("existData", 1);
        PlayerPrefs.SetInt("restartData", restartData);
        PlayerPrefs.SetInt("IdCharacter", idCharacter);
        //0 = false || 1 = true
        for(int i=0;i<5;i++)
        {
            int died = 0;
            if (charas_deaths[i]) died = 1;
            PlayerPrefs.SetInt("character_" + i + "_died", died);
        }
        //Which level they died. -1 = false
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("death_" + i + "_level", where_deaths[i]);
        }
        //Pos X and Y of characters 
        for (int i = 0; i < 4; i++)
        {
            float posX = charas_positions_deaths[i].x;
            float posY = charas_positions_deaths[i].y;
            print("posX: " + posX + " - posY: " + posY);
            PlayerPrefs.SetFloat("death_" + i + "_x", posX);
            PlayerPrefs.SetFloat("death_" + i + "_y", posY);
        }
    }

    public void CreateData()
    {
        PlayerPrefs.SetInt("existData", 1);
        PlayerPrefs.SetInt("restartData", 0);
        PlayerPrefs.SetInt("IdCharacter", 0);
        //0 = false || 1 = true
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("character_" + i + "_died", 0);
        }
        /*
        PlayerPrefs.SetInt("character_0_died", 0);
        PlayerPrefs.SetInt("character_1_died", 0);
        PlayerPrefs.SetInt("character_2_died", 0);
        PlayerPrefs.SetInt("character_3_died", 0);
        PlayerPrefs.SetInt("character_4_died", 0);
        */
        //Which level they died. -1 = false
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("death_" + i + "_level", -1);
        }
        /*
        PlayerPrefs.SetInt("death_0_level", -1);
        PlayerPrefs.SetInt("death_1_level", -1);
        PlayerPrefs.SetInt("death_2_level", -1);
        PlayerPrefs.SetInt("death_3_level", -1);
        PlayerPrefs.SetInt("death_4_level", -1);
        */
        //Pos X and Y of characters 
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("death_" + i + "_x", 0);
            PlayerPrefs.SetInt("death_" + i + "_y", 0);
        }
        /*
        PlayerPrefs.SetFloat("death_0_x", 0);
        PlayerPrefs.SetFloat("death_0_y", 0);
        PlayerPrefs.SetFloat("death_1_x", 0);
        PlayerPrefs.SetFloat("death_1_y", 0);
        PlayerPrefs.SetFloat("death_2_x", 0);
        PlayerPrefs.SetFloat("death_2_y", 0);
        PlayerPrefs.SetFloat("death_3_x", 0);
        PlayerPrefs.SetFloat("death_3_y", 0);
        PlayerPrefs.SetFloat("death_4_x", 0);
        PlayerPrefs.SetFloat("death_4_y", 0);
        */
    }

    public void FinishedLevel()
    {
        if (level == 4)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Win");
        }
        else if (idCharacter < 4) SceneManager.LoadScene("Level " + (level + 2));
    }
}