using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDetaylari : MonoBehaviour
{
    public GameObject Game;
    public GameObject dogruButton, yanlisButton, bosButton;

    public GameObject DogruMenuContent, YanlisMenuContent, BosMenuContent;
    private bool isDogruBasildi, isYanlisBasildi, isBosBasildi;

    private Color temp;
    private MainGame mainGame;

    void Start()
    {
        isDogruBasildi = true;
        isYanlisBasildi = false;
        isBosBasildi = false;

        temp = dogruButton.GetComponent<Image>().color;
        dogruButton.GetComponent<Image>().color = Color.blue;

        mainGame = Game.GetComponent<MainGame>();
    }
    
    public void dogruBasildi()
    {
        isDogruBasildi = true;
        isYanlisBasildi = false;
        isBosBasildi = false;

        dogruButton.GetComponent<Image>().color = Color.blue;

        yanlisButton.GetComponent<Image>().color = temp;
        bosButton.GetComponent<Image>().color = temp;

        DogruMenuContent.SetActive(true);
        BosMenuContent.SetActive(false);
        YanlisMenuContent.SetActive(false);
    }
    public void yanlisBasildi()
    {
        isYanlisBasildi = true;
        isDogruBasildi = false;
        isBosBasildi = false;

        yanlisButton.GetComponent<Image>().color = Color.blue;

        dogruButton.GetComponent<Image>().color = temp;
        bosButton.GetComponent<Image>().color = temp;

        YanlisMenuContent.SetActive(true);
        DogruMenuContent.SetActive(false);
        BosMenuContent.SetActive(false);
    }
    public void bosBasildi()
    {
        isBosBasildi = true;
        isYanlisBasildi = false;
        isBosBasildi = false;

        bosButton.GetComponent<Image>().color = Color.blue;

        yanlisButton.GetComponent<Image>().color = temp;
        dogruButton.GetComponent<Image>().color = temp;

        BosMenuContent.SetActive(true);
        YanlisMenuContent.SetActive(false);
        DogruMenuContent.SetActive(false);
    }
}
