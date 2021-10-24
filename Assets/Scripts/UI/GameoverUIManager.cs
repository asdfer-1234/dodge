using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private DataHolder dataHolder;
    private void Awake()
    {
        dataHolder = GameObject.FindWithTag("Data Holder").GetComponent<DataHolder>();
    }

    private void Start()
    {
        scoreText.text = dataHolder.score.ToString();
    }
}
