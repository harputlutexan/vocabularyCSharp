using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] canvasses;
    public GameObject game;
    public GameObject TürkçeButton, İngilizceButton, ResimlerButton, ÜlkelerButton, KolayButton, OrtaButton, ZorButton, StartButton;
    public GameObject areYouSurePanel;

    public bool isHomeButtonPressed, isProfileButtonPressed, isStatisticButtonPressed, isMadallionButtonPressed;
    public bool isİngilizceButtonPressed, isTürkçeButtonPressed, isÜlkelerButtonPressed, isResimlerButtonPressed;
    public bool isİnHome;
    private bool isKolayButtonPressed, isOrtaButtonPressed, isZorButtonPressed;
    private bool isStartButtonPressed;
    private bool isİnGame;
    private bool atStart;


    private bool oneTime;

    private MainGame mainGame;
    private Color32 colorTemp;

    private int yapilanDogruSoruSayisi, yapilanYanlisSoruSayisi, yapilanBosSoruSayisi;

    private string secim = "";

    void Start()
    { 
        atStart = true;

        colorTemp = TürkçeButton.GetComponent<Image>().color;
        mainGame = game.GetComponent<MainGame>();

        isİnGame = false;
        isİnHome = true;
        oneTime = false;
        isHomeButtonPressed = false;
        isProfileButtonPressed = false;
        isStatisticButtonPressed = false;
        isMadallionButtonPressed = false;

        isİngilizceButtonPressed = false;
        isTürkçeButtonPressed = false;
        isÜlkelerButtonPressed = false;
        isResimlerButtonPressed = false;

        isStartButtonPressed = false;

        if (PlayerPrefs.GetInt("firststart") == 0)
        {
            PlayerPrefs.SetInt("firststart", 1);

            türkçeButtonPressed();
            ortaButtonPressed();
            KolayButton.GetComponent<Button>().interactable = false;
            ZorButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            string prefs = PlayerPrefs.GetString("secilen");
            int difficulty = PlayerPrefs.GetInt("difficulty");
            switch (prefs)
            {
                case "türkçe":
                    türkçeButtonPressed();
                    if (difficulty == 0) kolayButtonPressed();
                    if (difficulty == 1) ortaButtonPressed();
                    if (difficulty == 2) zorButtonPressed();
                    break;
                case "ingilizce":
                    ingilizceButtonPressed();
                    if (difficulty == 0) kolayButtonPressed();
                    if (difficulty == 1) ortaButtonPressed();
                    if (difficulty == 2) zorButtonPressed();
                    break;
                case "ülkeler":
                    ülkelerButtonPressed();
                    if (difficulty == 1) ortaButtonPressed();
                    KolayButton.GetComponent<Button>().interactable = false;
                    ZorButton.GetComponent<Button>().interactable = false;
                    break;
                case "resimler":
                    resimlerButtonPressed();
                    if (difficulty == 1) ortaButtonPressed();
                    KolayButton.GetComponent<Button>().interactable = false;
                    ZorButton.GetComponent<Button>().interactable = false;
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (oneTime)
        {
            setColourSoruTürü();
            setColourZorlukSeviyesi();
            oneTime = false;
        }
    }

    void setButtonColour(GameObject button, Color color)
    {
        button.GetComponent<Image>().color = color;
    }

    void clearOtherButtonColours(GameObject a, GameObject b, GameObject c)
    {
        setButtonColour(a, colorTemp);
        setButtonColour(b, colorTemp);
        if (c != null)
        {
            setButtonColour(c, colorTemp);
        }

    }

    void setColourSoruTürü()
    {
        if (isİngilizceButtonPressed)
        {
            setButtonColour(İngilizceButton, Color.blue);
            clearOtherButtonColours(TürkçeButton, ÜlkelerButton, ResimlerButton);
        }
        else if (isTürkçeButtonPressed)
        {
            setButtonColour(TürkçeButton, Color.blue);
            clearOtherButtonColours(ÜlkelerButton, ResimlerButton, İngilizceButton);
        }
        else if (isÜlkelerButtonPressed)
        {
            setButtonColour(ÜlkelerButton, Color.blue);
            clearOtherButtonColours(TürkçeButton, İngilizceButton, ResimlerButton);
        }
        else if (isResimlerButtonPressed)
        {
            setButtonColour(ResimlerButton, Color.blue);
            clearOtherButtonColours(TürkçeButton, İngilizceButton, ÜlkelerButton);
        }
        else
        {
            //
        }
    }

    void setColourZorlukSeviyesi()
    {
        if (isKolayButtonPressed)
        {
            setButtonColour(KolayButton, Color.blue);
            clearOtherButtonColours(OrtaButton, ZorButton, null);
        }
        else if (isOrtaButtonPressed)
        {
            setButtonColour(OrtaButton, Color.blue);
            clearOtherButtonColours(KolayButton, ZorButton, null);
        }
        else if (isZorButtonPressed)
        {
            setButtonColour(ZorButton, Color.blue);
            clearOtherButtonColours(OrtaButton, KolayButton, null);
        }
        else
        {
            //
        }
    }

    public void goHome()
    {
        canvasses[0].SetActive(true);
        for(int a = 1; a < canvasses.Length; a++)
        {
            canvasses[a].SetActive(false);
            canvasses[a].SetActive(false);
        }
        isİnGame = true;
    }

    public void madallionButtonPressed()
    {

    }

    public void ingilizceButtonPressed()
    {
        oneTime = true;

        isİngilizceButtonPressed = true;

        isTürkçeButtonPressed = false;
        isÜlkelerButtonPressed = false;
        isResimlerButtonPressed = false;

        secim = "ingilizce";

        KolayButton.GetComponent<Button>().interactable = true;
        ZorButton.GetComponent<Button>().interactable = true;
    }
    public void türkçeButtonPressed()
    {
        oneTime = true;

        isTürkçeButtonPressed = true;

        isİngilizceButtonPressed = false;
        isÜlkelerButtonPressed = false;
        isResimlerButtonPressed = false;

        secim = "türkçe";

        KolayButton.GetComponent<Button>().interactable = true;
        ZorButton.GetComponent<Button>().interactable = true;
    }
    public void ülkelerButtonPressed()
    {
        oneTime = true;

        isÜlkelerButtonPressed = true;

        isİngilizceButtonPressed = false;
        isTürkçeButtonPressed = false;
        isResimlerButtonPressed = false;

        secim = "ülkeler";

        KolayButton.GetComponent<Button>().interactable = false;
        ZorButton.GetComponent<Button>().interactable = false;

        ortaButtonPressed();
    }
    public void resimlerButtonPressed()
    {
        oneTime = true;

        isResimlerButtonPressed = true;

        isİngilizceButtonPressed = false;
        isTürkçeButtonPressed = false;
        isÜlkelerButtonPressed = false;

        secim = "resimler";

        KolayButton.GetComponent<Button>().interactable = false;
        ZorButton.GetComponent<Button>().interactable = false;

        ortaButtonPressed();
    }

    public void kolayButtonPressed()
    {
        oneTime = true;

        isKolayButtonPressed = true;

        isOrtaButtonPressed = false;
        isZorButtonPressed = false;
    }
    public void ortaButtonPressed()
    {
        oneTime = true;

        isOrtaButtonPressed = true;

        isKolayButtonPressed = false;
        isZorButtonPressed = false;
    }
    public void zorButtonPressed()
    {
        oneTime = true;

        isZorButtonPressed = true;

        isKolayButtonPressed = false;
        isOrtaButtonPressed = false;
    }

    public void startButtonPressed()
    {
        isStartButtonPressed = true;

        PlayerPrefs.SetString("secilen", secim);

        if (isResimlerButtonPressed || isÜlkelerButtonPressed || isİngilizceButtonPressed || isTürkçeButtonPressed)
        {
            if (isKolayButtonPressed) PlayerPrefs.SetInt("difficulty", 0);
            else if (isOrtaButtonPressed) PlayerPrefs.SetInt("difficulty", 1);
            else if (isZorButtonPressed) PlayerPrefs.SetInt("difficulty", 2);

            mainGame.isGameEnd = false;
            mainGame.inGame = true;
            mainGame.oneTime2 = true;

            foreach(GameObject obj in canvasses)
            {
                if(obj != canvasses[2])
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
            }

            isİnHome = false;

            if (!atStart)
            {
                mainGame.resetQuestionCount();
                mainGame._nextQuestion();
            }

            atStart = false;
        }

    }

    private void doYouWantToQuit()
    {
        areYouSurePanel.SetActive(true);
    }
}