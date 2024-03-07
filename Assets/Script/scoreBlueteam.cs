using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreBlueteam : MonoBehaviour
{
    public Text scoretext;
    public static int scorecount;
    void Update()
    {
        scoretext.text = "score: " + Mathf.Round(scorecount);
    }

    public void WinBlueTeam()
    {
        if (scorecount >= 7)
        {
            scorecount = 0;
            SceneManager.LoadScene("Menu");
        }
    }
}
