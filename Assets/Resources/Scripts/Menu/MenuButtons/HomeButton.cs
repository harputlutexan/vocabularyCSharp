using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public GameObject homeMenu,areYouSureCanvas;
    public List<GameObject> canvasses;

    private void Update()
    {
        
    }

    public void HomeButtonPressed()
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
        foreach(GameObject obj in canvasses)
        {
            if(obj != homeMenu)
            {
                obj.SetActive(false);
            }
        }
    }

    void goTheHomeImmediately()
    {
        homeMenu.SetActive(true);
        deActiveAnotherScenes();
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
}
