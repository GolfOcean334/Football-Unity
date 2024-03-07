using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreBlueteam : MonoBehaviour
{
    public Text scoretext;
    public static int scorecount;
    public int scorecountMenu;
    void Update()
    {
        scorecountMenu = scorecount;
        scoretext.text = "Score: " + Mathf.Round(scorecount);
    }

    public void WinBlueTeam()
    {
        if (scorecountMenu >= 7)
        {
            PlayerPrefs.SetInt("ScorecountMenuP2", scorecountMenu);
            PlayerPrefs.Save();

            SceneManager.LoadScene("MenuEndGame");
        }
    }

    public void Reinitialize()
    {
        scorecount = 0;
    }
}
