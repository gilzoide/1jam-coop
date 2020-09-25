using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public ScoreInfo scoreInfo;
    public FormattedText text;

    void Awake()
    {
        if (!text)
        {
            text = GetComponentInChildren<FormattedText>();
        }
    }

    void Start()
    {
        UpdateScore(scoreInfo.score);
    }

    void UpdateScore(long score)
    {
        text.SetWith(score);
    }

    void OnEnable()
    {
        scoreInfo.onScoreChanged.AddListener(UpdateScore);
    }

    void OnDisable()
    {
        scoreInfo.onScoreChanged.RemoveListener(UpdateScore);
    }
}
