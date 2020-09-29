using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public ScoreInfo scoreInfo;
    public FormattedText scoreText;
    public FormattedText currencyText;

    void Start()
    {
        UpdateScore(scoreInfo.score);
        UpdateCurrency(scoreInfo.currency);
    }

    void UpdateScore(long score)
    {
        scoreText.SetWith(score);
    }

    void UpdateCurrency(long currency)
    {
        currencyText.SetWith(currency);
    }

    void OnEnable()
    {
        scoreInfo.onScoreChanged.AddListener(UpdateScore);
        scoreInfo.onCurrencyChanged.AddListener(UpdateCurrency);
    }

    void OnDisable()
    {
        scoreInfo.onScoreChanged.RemoveListener(UpdateScore);
        scoreInfo.onCurrencyChanged.RemoveListener(UpdateCurrency);
    }
}
