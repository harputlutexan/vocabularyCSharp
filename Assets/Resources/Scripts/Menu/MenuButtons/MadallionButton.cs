using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadallionButton : MonoBehaviour
{
    public GameObject madallionMenu, areYouSureCanvas;
    public List<GameObject> canvasses;


    public void madallionButtonPressed()
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
            if (obj != madallionMenu)
            {
                obj.SetActive(false);
            }
        }
    }

    void goTheHomeImmediately()
    {
        madallionMenu.SetActive(true);
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
