using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreRedteam : MonoBehaviour
{
    public Text scoretext;
    public static int scorecount;
    public int scorecountMenu;

    void Update()
    {
        scorecountMenu = scorecount;
        scoretext.text = "Score: " + Mathf.Round(scorecount);
    }

    public void WinRedTeam()
    {
        if (scorecountMenu >= 7)
        {
            PlayerPrefs.SetInt("ScorecountMenuP1", scorecountMenu);
            PlayerPrefs.Save();

            SceneManager.LoadScene("MenuEndGame");
        }
    }

    public void Reinitialize()
    {
        scorecount = 0;
    }
}
