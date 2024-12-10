using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int hasSilverKeys = 0;
    int hasGoldKeys = 0;
    int hasArrows = 0;
    int hasLights = 0;
    int hp = 0;
    public GameObject SilverKeyText;
    public GameObject GoldKeyText;
    public GameObject arrowText;
    public GameObject lightText;
    public GameObject lifeImage;
    public Sprite life3Image;
    public Sprite life2Image;
    public Sprite life1Image;
    public Sprite life0Image;
    public GameObject mainImage;
    public GameObject retryButton;
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject inputPanel;
    public string retrySceneName = "";

    void UpdateItemCount()
    {
        if (hasArrows != ItemKeeper.hasArrows)
        {
            arrowText.GetComponent<Text>().text = ItemKeeper.hasArrows.ToString();
            hasArrows = ItemKeeper.hasArrows;
        }
        if (hasSilverKeys != ItemKeeper.hasSilverKeys)
        {
            SilverKeyText.GetComponent<Text>().text = ItemKeeper.hasSilverKeys.ToString();
            hasSilverKeys = ItemKeeper.hasSilverKeys;
        }
        if (hasGoldKeys != ItemKeeper.hasGoldKeys)
        {
            GoldKeyText.GetComponent<Text>().text = ItemKeeper.hasGoldKeys.ToString();
            hasGoldKeys = ItemKeeper.hasGoldKeys;
        }
        if (hasLights != ItemKeeper.hasLights)
        {
            lightText.GetComponent<Text>().text = ItemKeeper.hasLights.ToString();
            hasLights = ItemKeeper.hasLights;
        }
    }

    void UpdateHP()
    {
        if (PlayerScript.gameState != "gameEnd")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                if (PlayerScript.hp != hp)
                {
                    hp  = PlayerScript.hp;
                    if (hp <= 0)
                    {
                        lifeImage.GetComponent<Image>().sprite = life0Image;
                        retryButton.SetActive(true);
                        mainImage.SetActive(true);
                        mainImage.GetComponent<Image>().sprite = gameOverSpr;
                        inputPanel.SetActive(false);
                        PlayerScript.gameState = "gameend";
                    }
                    else if (hp == 1)
                    {
                        lifeImage.GetComponent<Image>().sprite = life1Image;
                    }
                    else if (hp == 2)
                    {
                        lifeImage.GetComponent<Image>().sprite = life2Image;
                    }
                    else
                    {
                        lifeImage.GetComponent<Image>().sprite = life3Image;
                    }
                }
            }
        }
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("PlayerHP", 3);
        SoundManager.playingBGM = BGMType.None;
        SceneManager.LoadScene(retrySceneName);
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateItemCount();
        UpdateHP();
        Invoke("InactiveImage", 1.0f);
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemCount();
        UpdateHP();
    }

    public void GameClear()
    {
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameClearSpr;
        inputPanel.SetActive(false);
        PlayerScript.gameState = "gameclear";
        Invoke("GoToTitle", 3.0f);
    }

    void GoToTitle()
    {
        PlayerPrefs.DeleteKey("LastScene");
        SceneManager.LoadScene("Title");
    }
}
