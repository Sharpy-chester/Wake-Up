using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemySpawner : MonoBehaviour {

    float randx1;
    int randx2;
    float randy;
    Vector2 spawnPos;
    public PlayerController player;
    public float maxTimer = 5f;
    float timer = 0;
    public GameObject spirit;
    public GameObject meterScale;
    float insanity = 0;
    public float maxInsanty = 100f;
    public List<GameObject> enemies = new List<GameObject>();
    public int score = 0;
    public TextMeshProUGUI scoreText;
    GameObject highScoreObj;
    public int highScore;
    public GameObject sure;
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalScore;

    void Awake()
    {
        meterScale.transform.localScale = new Vector3(insanity / maxInsanty, 1, 1);
        highScoreObj = GameObject.Find("HighScoreHolder");
        highScore = highScoreObj.GetComponent<HighScoreHolder>().highScore;
        sure.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    void Update ()
    {
        
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            Spawn();
            timer = 0;
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
        insanity = enemies.Count * 10;
        meterScale.transform.localScale = new Vector3(insanity / maxInsanty, 1, 1);
    }

    void Spawn()
    {
        randx1 = Random.Range(3f, 7f);
        randx2 = Random.Range(0, 2);
        randy = Random.Range(-3f, 2f);

        if (randx2 == 0)
        {
            spawnPos = new Vector2(randx1, randy);
        }
        else
        {
            spawnPos = new Vector2(-randx1, randy);
        }
        this.transform.position = new Vector3(spawnPos.x, spawnPos.y, 0);
        GameObject ghost = Instantiate(spirit, this.transform);
        ghost.transform.parent = null;
        enemies.Add(ghost);
        
        insanity = enemies.Count * 10;
        meterScale.transform.localScale = new Vector3(insanity / maxInsanty, 1, 1);
        score += 1;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreObj.GetComponent<HighScoreHolder>().highScore = highScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        if (insanity >= maxInsanty)
        {
            gameOverScreen.SetActive(true);
            finalScore.text = score.ToString();
            Time.timeScale = 0;
        }
    }

    public void MenuButton()
    {
        player.canShoot = false;
        sure.SetActive(true);
        Time.timeScale = 0;
    }
    public void YesButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void NoButton()
    {
        player.canShoot = true;
        sure.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
