using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    private int time;

    public List<GameObject> targetPrefabs;

    private int score;
    public float spawnRate;
    public bool isGameActive;

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -2.5f; //  x value of the center of the left-most square
    private float minValueY = -2.5f; //  y value of the center of the bottom-most square

    public void StartGame(float difficulty)
    {
        spawnRate = difficulty;
        isGameActive = true;
        score = 0;
        time = 60;
        StartCoroutine(SpawnTarget());
        StartCoroutine(TimeUpdate());
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    IEnumerator TimeUpdate()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            UpdateTime();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares) - 1.25f;
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares) - 1.25f;

        Vector3 spawnPosition = new(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.SetText("Score: " + score);
    }

    public void UpdateTime()
    {
        time -= 1;
        timeText.SetText("Time: " + time);
        if (time == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
