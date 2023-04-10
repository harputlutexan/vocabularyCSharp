using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClass
{
    public int answerİndis;
    public int questionCount;
    public int score,playerBestTimeScore;

    public int dogruSoruSayisi, yanlisSoruSayisi, bosSoruSayisi;

    public string playerName;

    public PlayerClass(int _questionCount)
    {
        dogruSoruSayisi = 0;
        yanlisSoruSayisi = 0;
        bosSoruSayisi = 0;

        answerİndis = 0;
        score = 0;
        playerBestTimeScore = 0;
        questionCount = _questionCount;

        playerName = "Player";
    }

    public void setDogruSoruSayisi(int sayi)
    {
        dogruSoruSayisi = sayi;
    }
    public void setYanlisSoruSayisi(int sayi)
    {
        yanlisSoruSayisi = sayi;
    }
    public void setBosSoruSayisi(int sayi)
    {
        bosSoruSayisi = sayi;
    }

    public int getQuestionCount()
    {
        return questionCount;
    }

    public void setPlayerScore(int _score)
    {
        score = _score;
    }

    public void setPlayerName(string name)
    {
        playerName = name;
    }

    public void setPlayerFirstTimeScore(int score)
    {
        playerBestTimeScore = score;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    public int getPlayerFirstTimeScore()
    {
        return playerBestTimeScore;
    }

    public int getPlayerScore()
    {
        return score;
    }
}
