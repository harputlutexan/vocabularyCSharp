using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StatisticButton : MonoBehaviour
{
    public GameObject statisticMenu,areYouSureCanvas;
    public List<GameObject> canvasses;

    public Text dogru, yanlis, bos;

    public TextAsset playerJson;

    private GameObject jsonOBJ;
    PlayerItems items;

    public void StatisticButtonPressed()
    {
        if (isItCameHereWhileGameIsPlaying())
        {
            okNoProblemLetTheGameFinishAndGoToTheHome();
        }
        else
        {
            goTheHomeImmediately();
        }
    }

    void deActiveAnotherScenes()
    {
        foreach (GameObject obj in canvasses)
        {
            if (obj != statisticMenu)
            {
                obj.SetActive(false);
            }
        }
    }

    void goTheHomeImmediately()
    {
        statisticMenu.SetActive(true);
        deActiveAnotherScenes();

        showTheScores();
    }

    bool isItCameHereWhileGameIsPlaying()
    {
        if (GameObject.Find("GameMotor") != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void okNoProblemLetTheGameFinishAndGoToTheHome()
    {
        showTheAreYouSure();
    }

    void showTheAreYouSure()
    {
        areYouSureCanvas.SetActive(true);
    }

    void showTheScores()
    {
        string path = Path.Combine(Application.persistentDataPath,"player.json");
        string loadedJsonDataString = File.ReadAllText(path);
        items = JsonUtility.FromJson<PlayerItems>(loadedJsonDataString);

        dogru.text =""+ items.dogruSoruSayisi;
        yanlis.text = "" + items.yanlisSoruSayisi;
        bos.text = "" + items.bosSoruSayisi;
    }
}
