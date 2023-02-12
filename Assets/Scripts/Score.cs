using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text ScoreText;
    int ScoreInt = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ScoreText.text = ScoreInt.ToString() + " POINTS";
    }
    public void AddPoint()
    {
        ScoreInt += 1;
        ScoreText.text = ScoreInt.ToString() + " POINTS";
    }
}
