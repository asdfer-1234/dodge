using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder dataHolder;

    void Awake ()
    {
        dataHolder = this;
    }

    public int score;
    //public int highScore;
}
