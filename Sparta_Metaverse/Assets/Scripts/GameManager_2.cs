using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_2 : MonoBehaviour
{
    static GameManager_2 gameManager;
    public static GameManager_2 Instance { get { return gameManager; } }

    private int currentScore = 0;
    int bestScore = 0;
    public int BestScore {  get { return bestScore; } }
    private const string BestScoreKey = "BestScore";
    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }
    public void Start()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        if (bestScore < currentScore)
        {
            Debug.Log($"�ְ� ��� ����: {currentScore}");
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
        Debug.Log("���ӿ���");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("currentScore = " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
