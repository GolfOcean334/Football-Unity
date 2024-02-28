using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionBalle : MonoBehaviour
{
    public Text Score_Txt_P1;
    int score = 0;
    void Start()
    {

    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("Touché par " + collision.gameObject.name);
            AddScore();
        }
    }

    private void AddScore() 
    {
        score++;
        Score_Txt_P1.text = "" + score;
    }
}
