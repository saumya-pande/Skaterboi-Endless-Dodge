using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timebetweenSpawns = 3f;
    public float speedMultiplier;
    public TMP_Text DistanceUI;
    public TMP_Text HighScoreUI;

    private float distance;
    private float highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Load high score
        HighScoreUI.text = "High Score: " + highScore.ToString("F2");
    }

    void Update()
    { 
        distance += Time.deltaTime * 0.8f;
        DistanceUI.text = "Distance: " + distance.ToString("F2");

        if(distance > highScore)
        {
            highScore = distance;
            HighScoreUI.text = "High Score: " + highScore.ToString("F2");
            PlayerPrefs.SetFloat("HighScore", highScore); // Save high score
        }

        speedMultiplier += Time.deltaTime * 0.1f;
        timer += Time.deltaTime;

        if(timer > timebetweenSpawns)
        {
            timer = 0;
            int randomNum = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPos = spawnPoints[randomNum].transform.position;
            spawnPos.z = 0f;
            Instantiate(spawnObject, spawnPos, Quaternion.identity);
        }
    }
}
