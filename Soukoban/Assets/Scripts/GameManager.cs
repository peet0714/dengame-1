using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int remaingoals = 1;
    public bool isClear = false;
    public Text clearText;
    public GameObject clearImage;
    public GameObject nextStage;
    public Text gameoverText;
    public GameObject gameoverImage;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        clearText.text = "";
        clearImage.SetActive(false);
        nextStage.SetActive(false);
        gameoverText.text = "";
        gameoverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(remaingoals);
        
        
        if (player.isGameover == true)
        {
            gameoverText.text = "GAMEOVER";
            gameoverImage.SetActive(true);
        }
        else if (player.isGameover == false)
        {
            if (remaingoals <= 0)
            {
                clearImage.SetActive(true);
                isClear = true;            
                clearText.text = "CLEAR";
                nextStage.SetActive(true);
            }
        }
    }
}
