using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    private int grossStages = 40;
    public int stageNumber = 1;
    public int[] clearStages;
    public GameManager gameManager;

    void Update()
    {
        for (int i = 0; i<grossStages; i++)
        {
            clearStages[i] =0;
        }
    }
    
}
