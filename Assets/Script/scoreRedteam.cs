using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreRedteam : MonoBehaviour
{
    public Text scoretext;
    public static int scorecount;
    void Start()
    {
        
    }

    void Update()
    {
        scoretext.text = "score: " + Mathf.Round(scorecount);
    }

    public void WinRedTeam()
    {
        if (scorecount >= 7)
        {
            scorecount = 0;
            Debug.Log("Joueur Rouge à gagné !");
        }
    }
}
