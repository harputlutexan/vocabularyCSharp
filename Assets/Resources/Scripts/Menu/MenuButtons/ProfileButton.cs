using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileButton : MonoBehaviour
{
    public GameObject profileMenu, areYouSureCanvas;
    public List<GameObject> canvasses;


    public void ProfileButtonPressed()
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
            if (obj != profileMenu)
            {
                obj.SetActive(false);
            }
        }
    }

    void goTheHomeImmediately()
    {
        profileMenu.SetActive(true);
        deActiveAnotherScenes();
    }

    bool isItCameHereWhileGameIsPlaying()
    {
        if(GameObject.Find("GameMotor") != null)
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
