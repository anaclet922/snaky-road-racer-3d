using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;
    public GameObject ScoreUIContainer;
    public GameObject MenuUi;
    //public GameObject RespawnUi;
    //public GameObject GoogleAds;

    public Text highScoreTxt;
    public Text ScoreUi;

    AudioSource audioSource;
    public AudioClip[] audioClips;

    public GameObject[] textMenus;

    int score;
    int highScore;

    public bool HasPlayed = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
        //audioSource.
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "Best Score: " + highScore;
        if (PlayerPrefs.HasKey("LastScore"))
        {
            textMenus[0].SetActive(false);
            textMenus[1].SetActive(false);
            highScoreTxt.text = "Current score: " + PlayerPrefs.GetInt("LastScore");
            textMenus[2].GetComponent<Text>().text = "Tap to resume";
            score = PlayerPrefs.GetInt("LastScore");
        }
        else
        {
            score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void GameStart()
    {
       
            gameStarted = true;
            platformSpawner.SetActive(true);
            MenuUi.SetActive(false);
            ScoreUIContainer.SetActive(true);
            StartCoroutine(UpdateScore());

            audioSource.clip = audioClips[1];
            audioSource.Play();

    }
    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine(UpdateScore());
        SaveHighScore();
        //Invoke("Game", 1f);
        SceneManager.LoadScene("GameOverScene");
    }
    
    
    public void ReLoadLevel()
    {
        PlayerPrefs.SetInt("LastScore", score);
        SceneManager.LoadScene("GameOverScene");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            score++;
            ScoreUi.text = score.ToString();
        }
    }

    private void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("LastScore", score);
    }
    public void BonusScore(int bonus)
    {
        score += bonus;
        ScoreUi.text = score.ToString();

        audioSource.PlayOneShot(audioClips[2], 0.3f);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LastScore", 0);
        PlayerPrefs.DeleteKey("LastScore");
    }
}
