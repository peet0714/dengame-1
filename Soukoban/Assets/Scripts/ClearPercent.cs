using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearPercent : MonoBehaviour
{
    private int grossStages =40;
    private int clearStages = 0;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        for (int i=0; i<grossStages; i++)
        {
            clearStages += PlayerPrefs.GetInt((i+1).ToString());
        }
        text.text=$"クリア率 {clearStages} / 40";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
