using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text text;
    public ScoreInfo scoreInfo;
    public string format = "${0}";

    void Awake()
    {
        if (!text)
        {
            text = GetComponentInChildren<Text>();
        }
    }

    void Start()
    {
        SetScore(scoreInfo.score);
    }

    public void SetScore(long score)
    {
        text.text = string.Format(format, score);
    }

    void OnEnable()
    {
        scoreInfo.onScoreChanged.AddListener(SetScore);
    }

    void OnDisable()
    {
        scoreInfo.onScoreChanged.RemoveListener(SetScore);
    }
}
