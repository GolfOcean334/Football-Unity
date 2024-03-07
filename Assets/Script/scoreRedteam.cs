using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreRedteam : MonoBehaviour
{
    public Text scoretext;
    public static int scorecount;
    void Update()
    {
        scoretext.text = "score: " + Mathf.Round(scorecount);
    }

    public void WinRedTeam()
    {
        if (scorecount >= 1)
        {
            scorecount = 0;
            SceneManager.LoadScene("MenuEndGame");
        }
    }
}
