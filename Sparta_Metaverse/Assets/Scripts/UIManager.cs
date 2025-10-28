using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image panel;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.Log("scoreText is null");

        if (panel == null)
            Debug.Log("restartText is null");

        panel.gameObject.SetActive(false);
    }
    public void SetRestart()
    {
        panel.gameObject.SetActive(true);
    }
    public void InvokeSetRestart()
    {
        Invoke("SetRestart", 0.5f);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void SetScore(int currentScore, int bestScore)
    {
        currentScoreText.text = currentScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }
    // Update is called once per frame
}
