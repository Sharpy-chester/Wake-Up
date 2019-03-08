using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHolder : MonoBehaviour {

    public int highScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        
    }
}
