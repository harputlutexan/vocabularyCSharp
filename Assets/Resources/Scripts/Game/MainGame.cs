using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    PlayerClass player;

    public Text scoreCounterText, questionLeftCounterText, categoryText;
    public Text doğruCevaplarText, yanlışCevaplarText, scoreText;
    public Text _soru;

    public GameObject HomeCanvas;

    public GameObject areYouSure, PlayerTableCanvas, GameCanvas, TestOzetiCanvas;
    public TextAsset json,playerJson;
    public TextAsset ingingbeginner, ingingmedium, ingingadvanced;
    public TextAsset beginnertren, intermediatetren, advancedtren;
    public Image image;
    public Text button1, button2, button3, button4;
    public Text timeText;
    public GameObject prefab;
    public GameObject soruContent, kullaniciCevaplariContent, DogruContent;
    public GameObject soruContent2, kullaniciCevaplariContent2, DogruContent2;
    public GameObject soruContent3, kullaniciCevaplariContent3, DogruContent3;

    public GameObject DogruMenuContent, YanlisMenuContent, BosMenuContent;

    public GameObject testDetaylariCanvas;

    string doğruCevap;

    RootForItems myRootForItems;
    RootForEnglish myRootForEnglish;

    public bool anyMenuButtonPressed;

    public bool isİtEnd, isGameEnd;
    public bool inGame,isInTable;
    private float timer, timerTemp;
    private bool oneTime = false;
    public bool oneTime2 = true;
    private bool oneTimeTimer = true;
    private bool nextButtonPressed;
    private bool isButtonsBlocked;

    public int playerScore;

    public int questionLeft;

    private MainMenu mainMenuClass;

    private int random,testCounter;
    private float timerForText;

    private int doğruCevaplarCounter, yanlışCevaplarCounter, score;

    private List<string> soru, kullanicicevaplari, dogru,yanlis;
    private List<string> soru2, kullanicicevaplari2,dogru2,yanlis2;
    private List<string> soru3, kullanicicevaplari3, dogru3, yanlis3;
    private List<string> boş;

    private List<GameObject> gameObjects;

    private string soruSTR = "";
    private bool oneTime3;

    private bool _continue = true;

    private int difficulty;

    float totalTimeCounter;


    void Start()
    {
        setup();
    }

    private void Update()
    {
        questionMotor();
        if(_continue) timerForTimeText();
    }

    /// <functions>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </functions>
    /// 


    void timerForTimeText()
    {
        totalTimeCounter += Time.deltaTime;
        if (timerForText > 0)
        {
            timerForText -= Time.deltaTime;
            timeText.text = "" + (int)timerForText;
        }
        else
        {
            if(questionLeft!= 10)
            {
                boş.Add(soruSTR);
                setQuestionLeft(++questionLeft);
                _nextQuestion();
            }
            else
            {
                if (oneTime3)
                {
                    boş.Add(soruSTR);
                    Invoke("showTheTable", 1f);
                }
                oneTime3 = false;
            }          
        }
    }

    void showTheTable()
    {
        writeScoreToTheTable();
        scoreText.text = "" + _setScore(doğruCevaplarCounter, yanlışCevaplarCounter);
        GameCanvas.SetActive(false);
        PlayerTableCanvas.SetActive(true);
        isİtEnd = true;

        isInTable = true;
    }

    void writeScoreToTheTable()
    {
        doğruCevaplarText.text = "" + doğruCevaplarCounter;
        yanlışCevaplarText.text = "" + yanlışCevaplarCounter;

        int playerScorePref = PlayerPrefs.GetInt("playerscore");
        int playerCorrectScorePref = PlayerPrefs.GetInt("playercorrectscore");
        int playerFalseScorePref = PlayerPrefs.GetInt("playerfalsescore");
        float totalTimePref = PlayerPrefs.GetFloat("totaltime");

        PlayerPrefs.SetInt("playerscore", playerScore + playerScorePref);
        PlayerPrefs.SetInt("playercorrectscore", doğruCevaplarCounter + playerCorrectScorePref);
        PlayerPrefs.SetInt("playerfalsescore", yanlışCevaplarCounter + playerFalseScorePref);
        PlayerPrefs.SetFloat("totaltime", totalTimeCounter + totalTimePref);
        Debug.Log(playerScorePref+" "+ PlayerPrefs.GetInt("playerscore"));
    }

    void resetTimerForTimeText()
    {
        timerForText = 15f;
    }

    public bool isİnGame()
    {
        if (!isİtEnd)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void questionMotor()
    {
        if (nextButtonPressed)
        {
            _continue = false;
            if (_waitForTime(1.5f))
            {
                setQuestionLeft(++questionLeft);
                _nextQuestion();
            }
        }
    }

    void goToMainMenu()
    {
        //
    }


    public void _nextQuestion()
    {
        _continue = true;
        isButtonsBlocked = false;

        nextButtonPressed = false;

        resetTimerForTimeText();

        button1.color = Color.black;
        button2.color = Color.black;
        button3.color = Color.black;
        button4.color = Color.black;

        string secim = PlayerPrefs.GetString("secilen");
        string imageName = "";

        switch (secim)
        {
            case "ülkeler":
                for (int a = 0; a < myRootForItems.root.Length - 2; a++)
                {
                    random = Random.Range(0, myRootForItems.root.Length - 1);
                    if (myRootForItems.root[random].CATEGORY != "tools" && myRootForItems.root[random].CATEGORY != "animals" && myRootForItems.root[random].CATEGORY != "vegetables")
                    {
                        break;
                    }
                }

                imageName = myRootForItems.root[random].IMAGESTRING;
                break;

            case "resimler":
                for (int a = 0; a < myRootForItems.root.Length - 2; a++)
                {
                    random = Random.Range(0, myRootForItems.root.Length - 1);
                    if (myRootForItems.root[random].CATEGORY != "flags" && myRootForItems.root[random].CATEGORY != "capitals")
                    {
                        break;
                    }
                }

                imageName = myRootForItems.root[random].IMAGESTRING;
                break;

            case "ingilizce":
                   random = Random.Range(0, myRootForEnglish.root.Length);
                break;

            case "türkçe":
                random = Random.Range(0, myRootForEnglish.root.Length);
                break;
        }

        


        if(secim == "ingilizce")
        {
            categoryText.text = "English";

            _soru.enabled = true;
            _soru.text = myRootForEnglish.root[random].EN;
        }
        else if(secim == "türkçe")
        {
            categoryText.text = "Turkish";

            _soru.enabled = true;
            _soru.text = myRootForEnglish.root[random].EN;
        }
        else
        {
            if (myRootForItems.root[random].CATEGORY == "capitals")
            {
                if (image.IsActive()) image.enabled = false;
                _soru.enabled = true;
                _soru.text = imageName;
            }
            else
            {
                if (!image.IsActive()) image.enabled = true;
                _soru.enabled = false;
                image.sprite = Resources.Load<Sprite>("Sprites/drawable/" + imageName);
            }

            categoryText.text = myRootForItems.root[random].CATEGORY.ToUpper();
        }

        

        //image.GetComponent<RectTransform>().sizeDelta = new Vector2(image.sprite.rect.width,image.sprite.rect.height);
        //image.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 0);

        if(secim == "ülkeler" || secim == "resimler")
        {
            button1.text = myRootForItems.root[random].OPT1;
            button2.text = myRootForItems.root[random].OPT2;
            button3.text = myRootForItems.root[random].OPT3;
            button4.text = myRootForItems.root[random].OPT4;
        }
        else
        {
            button1.text = myRootForEnglish.root[random].TR1;
            button2.text = myRootForEnglish.root[random].TR2;
            button3.text = myRootForEnglish.root[random].TR3;
            button4.text = myRootForEnglish.root[random].TR4;
        }
        

        string[] buttonNames = new string[5];

        buttonNames[0] = button1.text;
        buttonNames[1] = button2.text;
        buttonNames[2] = button3.text;
        buttonNames[3] = button4.text;

        doğruCevap = buttonNames[0];
        soru.Add(doğruCevap);
        soruSTR = doğruCevap;

        for (int a = 0; a < 4; a++)
        {
            string temp = buttonNames[a];
            int randomIndex = Random.Range(a, 4);
            buttonNames[a] = buttonNames[randomIndex];
            buttonNames[randomIndex] = temp;
        }

        button1.text = buttonNames[0];
        button2.text = buttonNames[1];
        button3.text = buttonNames[2];
        button4.text = buttonNames[3];

    }

    void _setBoolToNextButtonPressed()
    {
        nextButtonPressed = true;
    }

    public void _button1()
    {
        if (!isButtonsBlocked)
        {
            kullanicicevaplari.Add(button1.text);

            if (questionLeft == 10)
            {
                isGameEnd = true;
                setColourToAnswers(button1);
                setScoreLastTime(button1);
                Invoke("showTheTable", 1f);
            }
            else
            {
                if (button1.text.Equals(doğruCevap))
                {
                    dogru.Add(doğruCevap);
                    doğruCevaplarCounter++;

                    button1.color = Color.blue;

                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }


                    switch (difficulty)
                    {
                        case 0:
                            playerScore += 5;
                            break;
                        case 1:
                            playerScore += 10;
                            break;
                        case 2:
                            playerScore += 15;
                            break;
                    }



                    player.setPlayerScore(playerScore);
                    if (questionLeft != 11)
                    {
                        setScore(player.getPlayerScore());
                    }


                }
                else
                {
                    yanlis.Add(button1.text);
                    soru2.Add(doğruCevap);
                    kullanicicevaplari2.Add(button1.text);
                    dogru2.Add(doğruCevap);
                    yanlışCevaplarCounter++;
                    //dogru.Add("");

                    button1.color = Color.red;
                    _doğruCevabiGöster();
                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }
                }
            }
        }

        isButtonsBlocked = true;
    }
    public void _button2()
    {
        if (!isButtonsBlocked)
        {
            kullanicicevaplari.Add(button2.text);
            if (questionLeft == 10)
            {
                isGameEnd = true;
                setColourToAnswers(button2);
                setScoreLastTime(button2);
                Invoke("showTheTable", 1f);
            }
            else
            {
                if (button2.text.Equals(doğruCevap))
                {
                    dogru.Add(doğruCevap);
                    doğruCevaplarCounter++;

                    button2.color = Color.blue;

                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }


                    switch (difficulty)
                    {
                        case 0:
                            playerScore += 5;
                            break;
                        case 1:
                            playerScore += 10;
                            break;
                        case 2:
                            playerScore += 15;
                            break;
                    }

                    player.setPlayerScore(playerScore);
                    if (questionLeft != 11)
                    {
                        setScore(player.getPlayerScore());
                    }
                }
                else
                {
                    yanlis.Add(button2.text);
                    soru2.Add(doğruCevap);
                    kullanicicevaplari2.Add(button2.text);
                    dogru2.Add(doğruCevap);
                    yanlışCevaplarCounter++;
                    //dogru.Add("");

                    button2.color = Color.red;
                    _doğruCevabiGöster();
                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }

                }
            }
        }

        isButtonsBlocked = true;
    }
    public void _button3()
    {
        if (!isButtonsBlocked)
        {
            kullanicicevaplari.Add(button3.text);
            if (questionLeft == 10)
            {
                isGameEnd = true;
                setColourToAnswers(button3);
                setScoreLastTime(button3);
                Invoke("showTheTable", 1f);
            }
            else
            {
                if (button3.text.Equals(doğruCevap))
                {
                    dogru.Add(doğruCevap);
                    doğruCevaplarCounter++;

                    button3.color = Color.blue;

                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }


                    switch (difficulty)
                    {
                        case 0:
                            playerScore += 5;
                            break;
                        case 1:
                            playerScore += 10;
                            break;
                        case 2:
                            playerScore += 15;
                            break;
                    }

                    player.setPlayerScore(playerScore);
                    if (questionLeft != 11)
                    {
                        setScore(player.getPlayerScore());
                    }
                }
                else
                {
                    yanlis.Add(button3.text);
                    soru2.Add(doğruCevap);
                    kullanicicevaplari2.Add(button3.text);
                    dogru2.Add(doğruCevap);
                    yanlışCevaplarCounter++;
                    //dogru.Add("");

                    button3.color = Color.red;
                    _doğruCevabiGöster();
                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }
                }
            }
        }

        isButtonsBlocked = true;
    }
    public void _button4()
    {
        if (!isButtonsBlocked)
        {
            kullanicicevaplari.Add(button4.text);
            if (questionLeft == 10)
            {
                isGameEnd = true;
                setColourToAnswers(button4);
                setScoreLastTime(button4);
                Invoke("showTheTable", 1f);
            }
            else
            {
                if (button4.text.Equals(doğruCevap))
                {
                    dogru.Add(doğruCevap);
                    doğruCevaplarCounter++;

                    button4.color = Color.blue;

                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }


                    switch (difficulty)
                    {
                        case 0:
                            playerScore += 5;
                            break;
                        case 1:
                            playerScore += 10;
                            break;
                        case 2:
                            playerScore += 15;
                            break;
                    }

                    player.setPlayerScore(playerScore);
                    if (questionLeft != 11)
                    {
                        setScore(player.getPlayerScore());
                    }
                }
                else
                {
                    yanlis.Add(button4.text);
                    soru2.Add(doğruCevap);
                    kullanicicevaplari2.Add(button4.text);
                    dogru2.Add(doğruCevap);
                    yanlışCevaplarCounter++;
                    //dogru.Add("");

                    button4.color = Color.red;
                    _doğruCevabiGöster();
                    if (questionLeft < 10)
                    {
                        _setBoolToNextButtonPressed();
                    }
                }
            }
        }

        isButtonsBlocked = true;
    }

    void _doğruCevabiGöster()
    {
        if (button1.text.Equals(doğruCevap))
        {
            button1.color = Color.blue;
        }
        else if (button2.text.Equals(doğruCevap))
        {
            button2.color = Color.blue;
        }
        else if (button3.text.Equals(doğruCevap))
        {
            button3.color = Color.blue;
        }
        else if (button4.text.Equals(doğruCevap))
        {
            button4.color = Color.blue;
        }
        else
        {
            //
        }
    }

    bool _waitForTime(float timeCount)
    {
        if (oneTimeTimer)
        {
            timer = timeCount;
            oneTimeTimer = false;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else
        {
            timer = timeCount;
            oneTimeTimer = true;
            return true;
        }
    }

    void setScore(int _scoreCounter)
    {
        scoreCounterText.text = "" + _scoreCounter;
    }
    void setQuestionLeft(int question)
    {
        questionLeftCounterText.text = "" + (question);
    }

    public void _yes()
    {
        /*
        timerForText = 15f;
        if (PlayerTableCanvas.activeSelf)
        {
            PlayerTableCanvas.SetActive(false);
        }
        if (mainMenuClass.areYouSurePanel.activeSelf)
        {
            mainMenuClass.areYouSurePanel.SetActive(false);
        }

        resetQuestionCount();
        inGame = false;
        isGameEnd = true;
        clear();
        */
        PlayerTableCanvas.SetActive(false);
        showTheTable();
    }
    public void _no()
    {
        areYouSure.SetActive(false);
    }
    
    public void testleriGoster()
    {
        TestOzetiCanvas.SetActive(true);
        PlayerTableCanvas.SetActive(false);
        areYouSure.SetActive(false);

        dogruTest();
        yanlisTest();
        bosTest();
    }

    public void resetQuestionCount()
    {
        questionLeft = player.getQuestionCount();
        setQuestionLeft(questionLeft);
        //setQuestionLeft(questionLeft);
    }

    public void _end()
    {
        PlayerTableCanvas.active = false;
        goToMainMenu();
    }

    int _setScore(int dogruCevap, int yanlışCevap)
    {
        if (dogruCevap != 0)
        {
            score = dogruCevap * 10 - yanlışCevap * 2;
            if (score < 0)
            {
                return 0;
            }
            return score;
        }
        else
        {
            return 0;
        }
        
    }

    void setColourToAnswers(Text button)
    {
        if (button.text.Equals(doğruCevap))
        {

            button.color = Color.blue;
        }
        else
        {

            button.color = Color.red;
            _doğruCevabiGöster();

        }
    }

    void dogruTest()
    {
        foreach (string str in dogru)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(soruContent.transform);

            testCounter++;
        }

        foreach (string str in dogru)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(kullaniciCevaplariContent.transform);

            testCounter++;
        }

        foreach (string str in dogru)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(DogruContent.transform);

            testCounter++;
        }
    }

    void yanlisTest()
    {
        foreach (string str in soru2)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(soruContent2.transform);

            testCounter++;
        }

        foreach (string str in kullanicicevaplari2)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(kullaniciCevaplariContent2.transform);

            testCounter++;
        }

        foreach (string str in dogru2)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(DogruContent2.transform);

            testCounter++;
        }
    }

    void bosTest()
    {
        foreach (string str in boş)
        {
            gameObjects.Add(Instantiate(prefab));

            gameObjects[testCounter].GetComponent<Text>().text = str;

            gameObjects[testCounter].transform.SetParent(soruContent3.transform);

            testCounter++;
        }
        testCounter = 0;
    }

    void setScoreLastTime(Text button)
    {
        if (button.text.Equals(doğruCevap))
        {
            doğruCevaplarCounter++;
            dogru.Add(doğruCevap);
        }
        else
        {
            yanlışCevaplarCounter++;
            //dogru.Add("");
            yanlis.Add(button1.text);
            soru2.Add(doğruCevap);
            kullanicicevaplari2.Add(button.text);
            dogru2.Add(doğruCevap);
        }
}

    void clear()
    {
        testCounter = 0;

        yanlışCevaplarCounter = 0;
        doğruCevaplarCounter = 0;

        soru.Clear();
        soru2.Clear();
        soru3.Clear();

        yanlis.Clear();
        yanlis2.Clear();
        yanlis3.Clear();

        dogru.Clear();
        dogru2.Clear();
        dogru3.Clear();

        kullanicicevaplari.Clear();
        kullanicicevaplari2.Clear();
        kullanicicevaplari3.Clear();

        soruSTR = "";

        boş.Clear();


        foreach(GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
        gameObjects.Clear();

    }


void setup()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");

        oneTime3 = true;
        soru = new List<string>();
        kullanicicevaplari = new List<string>();
        dogru = new List<string>();
        yanlis = new List<string>();

        soru2 = new List<string>();
        kullanicicevaplari2 = new List<string>();
        dogru2 = new List<string>();
        yanlis2 = new List<string>();

        soru3 = new List<string>();
        kullanicicevaplari3 = new List<string>();
        dogru3 = new List<string>();
        yanlis3 = new List<string>();
        boş = new List<string>();


        gameObjects = new List<GameObject>();

        isButtonsBlocked = false;
        score = 0;
        doğruCevaplarCounter = 0;
        yanlışCevaplarCounter = 0;
        testCounter = 0;

        timerForText = 15f;
        inGame = true;
        isInTable = false;
        anyMenuButtonPressed = false;
        isİtEnd = false;
        isGameEnd = false;

        mainMenuClass = GameObject.Find("Home").GetComponent<MainMenu>();

        player = new PlayerClass(1);

        questionLeft = player.getQuestionCount();

        playerScore = 0;
        timer = 2f;
        nextButtonPressed = false;
        //string path_to_json = Application.streamingAssetsPath + "/animals.json";


        string secim = PlayerPrefs.GetString("secilen");

        switch (secim)
        {
            case "ülkeler":
                myRootForItems = JsonUtility.FromJson<RootForItems>("{\"root\":" + json.text + "}");
                ülkeler();
                break;
            case "resimler":
                myRootForItems = JsonUtility.FromJson<RootForItems>("{\"root\":" + json.text + "}");
                resimler();
                break;
            case "ingilizce":
                int difficultyEN = PlayerPrefs.GetInt("difficulty");
                
                if(difficultyEN == 0) myRootForEnglish = JsonUtility.FromJson<RootForEnglish>("{\"root\":" + ingingbeginner.text + "}");
                else if(difficultyEN == 1) myRootForEnglish = JsonUtility.FromJson<RootForEnglish>("{\"root\":" + ingingmedium.text + "}");
                else if(difficultyEN == 2) myRootForEnglish = JsonUtility.FromJson<RootForEnglish>("{\"root\":" + ingingadvanced.text + "}");

                ingilizce();
                break;
            case "türkçe":
                int difficultyTR = PlayerPrefs.GetInt("difficulty");

                if (difficultyTR == 0) myRootForEnglish = JsonUtility.FromJson<RootForEnglish>("{\"root\":" + beginnertren.text + "}");
                else if (difficultyTR == 1) myRootForEnglish = JsonUtility.FromJson<RootForEnglish>("{\"root\":" + intermediatetren.text + "}");
                else if (difficultyTR == 2) myRootForEnglish = JsonUtility.FromJson<RootForEnglish>("{\"root\":" + advancedtren.text + "}");
     
                türkçe();
                break;
        }

        
    }

    public void AnaMenuButtonPressed()
    {
        player.setDogruSoruSayisi(dogru.Count);
        player.setYanlisSoruSayisi(yanlis.Count);

        writeToJSON();
        //player.setBosSoruSayisi();
        clear();
        goHome();
    }

    void goHome()
    {
        HomeCanvas.SetActive(true);
        PlayerTableCanvas.SetActive(false);
        areYouSure.SetActive(false);
        testDetaylariCanvas.SetActive(false);
        inGame = false;
    }

    void writeToJSON()
    {
        string path = path = Path.Combine(Application.persistentDataPath,"player.json");
        string data = JsonUtility.ToJson(player, true);
        File.WriteAllText(path, data);
    }

    private void ülkeler()
    {
        for (int a = 0; a < myRootForItems.root.Length - 2; a++)
        {
            random = Random.Range(0, myRootForItems.root.Length - 1);
            if (myRootForItems.root[random].CATEGORY != "tools" && myRootForItems.root[random].CATEGORY != "animals" && myRootForItems.root[random].CATEGORY != "vegetables")
            {
                break;
            }
        }
        if(myRootForItems.root[random].CATEGORY == "capitals")
        {
            image.enabled = false;
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("Sprites/drawable/" + myRootForItems.root[random].IMAGESTRING);
        }
        
        categoryText.text = myRootForItems.root[random].CATEGORY.ToUpper();

        button1.text = myRootForItems.root[random].OPT1;
        button2.text = myRootForItems.root[random].OPT2;
        button3.text = myRootForItems.root[random].OPT3;
        button4.text = myRootForItems.root[random].OPT4;

        setQuestionLeft(questionLeft);
        _nextQuestion();
    }

    private void resimler()
    {
        for (int a = 0; a < myRootForItems.root.Length - 2; a++)
        {
            random = Random.Range(0, myRootForItems.root.Length - 1);
            if (myRootForItems.root[random].CATEGORY != "capitals" && myRootForItems.root[random].CATEGORY != "flags")
            {
                break;
            }
        }

        image.sprite = Resources.Load<Sprite>("Sprites/drawable/" + myRootForItems.root[random].IMAGESTRING);
        categoryText.text = myRootForItems.root[random].CATEGORY.ToUpper();

        button1.text = myRootForItems.root[random].OPT1;
        button2.text = myRootForItems.root[random].OPT2;
        button3.text = myRootForItems.root[random].OPT3;
        button4.text = myRootForItems.root[random].OPT4;

        setQuestionLeft(questionLeft);
        _nextQuestion();
    }

    private void ingilizce()
    {
        image.enabled = false;
        _soru.enabled = false;

        random = Random.Range(0, myRootForEnglish.root.Length - 1);

        categoryText.text = "English";

        button1.text = myRootForEnglish.root[random].TR1;
        button2.text = myRootForEnglish.root[random].TR2;
        button3.text = myRootForEnglish.root[random].TR3;
        button4.text = myRootForEnglish.root[random].TR4;

        setQuestionLeft(questionLeft);
        _nextQuestion();
    }

    private void türkçe()
    {
        image.enabled = false;
        _soru.enabled = false;

        random = Random.Range(0, myRootForEnglish.root.Length - 1);

        categoryText.text = "Turkish";

        button1.text = myRootForEnglish.root[random].TR1;
        button2.text = myRootForEnglish.root[random].TR2;
        button3.text = myRootForEnglish.root[random].TR3;
        button4.text = myRootForEnglish.root[random].TR4;

        setQuestionLeft(questionLeft);
        _nextQuestion();
    }

    private void OnEnable()
    {
        Start();
    }

}