using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour
{
    private int[] isClear;
    public Image image;
    public int btnNum =1;
    private int grossStages =40;
    void Start()
    {
        isClear = new int[grossStages];
        image = GetComponent<Image>();
    }
    void Update()
    {
        for (int i=0; i<grossStages;i++)
        {
            isClear[i] = PlayerPrefs.GetInt((i+1).ToString());
        }
        if (isClear[btnNum-1] == 1)
        {
            image.color = new Color(0f, 170f, 255f);
        }
    }
}
