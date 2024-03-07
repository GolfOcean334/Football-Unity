using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text tex;
    float countdown = 300;
    float time_elapsed;
    float initial_value;

    void Start()
    {
        initial_value = countdown;
    }

    void Update()
    {
        if (countdown > 1)
        {
            countdown -= Time.deltaTime;
            time_elapsed = initial_value - countdown;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
        float min = Mathf.FloorToInt(countdown / 60);
        float sec = Mathf.FloorToInt(countdown % 60);
        tex.text = string.Format("{0,00}:{1,00}", min, sec);        
    }
}