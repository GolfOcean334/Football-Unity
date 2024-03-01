using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreRedteam : MonoBehaviour
{
    public Text scoretext;
    public static int scorecount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
