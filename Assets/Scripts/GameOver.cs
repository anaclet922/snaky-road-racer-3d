using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreTxt;
    public Text HighscoreTxt;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        score = PlayerPrefs.GetInt("LastScore");
        scoreTxt.text = "Score: " + score;
        HighscoreTxt.text = "Best score: " + PlayerPrefs.GetInt("HighScore");
    }
    // Update is called once per frame
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LastScore", 0);
        PlayerPrefs.DeleteKey("LastScore");
    }
}
