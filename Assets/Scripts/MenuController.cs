using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour {

    public GameObject highScoreObj;
    public TextMeshProUGUI highScoreText;

    void Awake()
    {
        highScoreText.text = highScoreObj.GetComponent<HighScoreHolder>().highScore.ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
