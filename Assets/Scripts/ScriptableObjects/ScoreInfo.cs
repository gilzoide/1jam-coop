using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreInfo", menuName = "ScriptableObjects/ScoreInfo")]
public class ScoreInfo : ScriptableObject
{
    public long score = 0;
    public UnityEvent<long> onScoreChanged;

    public void Reset()
    {
        score = 0;
    }

    public void Increment(long quantity)
    {
        score += quantity;
        onScoreChanged.Invoke(score);
    }
    public void Increment(EnemyInfo enemyInfo)
    {
        Increment(enemyInfo.scoreWorth);
    }

    public void Decrement(int quantity)
    {
        score -= quantity;
        onScoreChanged.Invoke(score);
    }
}
