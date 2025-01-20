using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private int grossStages = 40;
    public void NewGame()
    {
        for (int i = 0; i<grossStages;i++)
        {
            PlayerPrefs.SetInt($"{i+1}",0);
        }
    }
}
