using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public PlayerController playerController;
    private DataHolder dataHolder;
    public UIManager navigator;
    private void Awake()
    {
        dataHolder = GameObject.FindWithTag("Data Holder").GetComponent<DataHolder>();
    }

    private void Start()
    {
        UpdateScore();
    }

    public void Score(int Amount)
    {
        score += Amount;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (!playerController.isDying)
        {
            scoreText.text = score.ToString();
        }
    }

    public void Gameover()
    {
        navigator.LoadScene("Game Over");
        dataHolder.score = score;
    }
}
