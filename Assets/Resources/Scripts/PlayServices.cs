using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;



public class PlayServices : MonoBehaviour
{
    [SerializeField] Text debugtext;
    [SerializeField] InputField leaderboard;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    void Initialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestServerAuthCode(false).
            Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        debugtext.text = "playgames initialized";
        signinuserwithplaygames();
    }
    void signinuserwithplaygames()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (success) =>
        {
            switch (success)
            {
                case SignInStatus.Success:
                    debugtext.text = "signined in player using play games successfully";
                    break;
                default:
                    debugtext.text = "Signin not successfull";
                    break;
            }
        });
    }
    public void postscoretoleaderboard()
    {
        Social.ReportScore(int.Parse(leaderboard.text), "CgkIq9e956IIEAIQBg", (bool success) =>
        {
            if (success)
            {
                debugtext.text = "successfully add score to leaderboard";
            }
            else
            {
                debugtext.text = "not successfull";
            }
        });
    }
    public void showleaderboard()
    {
        Social.ShowLeaderboardUI();
    }
    public void achievementcompleted()
    {
        Social.ReportProgress("CgkIq9e956IIEAIQAQ", 100.0f, (bool success) =>
        {
            if (success)
            {
                debugtext.text = "successfully unlocked achievements";
            }
            else
            {
                debugtext.text = "not successfull";
            }
        });
    }
    public void showacievementui()
    {
        Social.ShowAchievementsUI();
    }
}
