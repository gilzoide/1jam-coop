using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreInfo", menuName = "ScriptableObjects/ScoreInfo")]
public class ScoreInfo : ScriptableObject
{
    public long score = 0;
    public long currency = 0;
    public UnityEvent<long> onScoreChanged;
    public UnityEvent<long> onCurrencyChanged;

    public void Reset()
    {
        currency = 0;
        score = 0;
    }

    public void Increment(long quantity)
    {
        score += quantity;
        currency += quantity;
        onScoreChanged.Invoke(score);
        onCurrencyChanged.Invoke(currency);
    }
    public void Increment(EnemyInfo enemyInfo)
    {
        Increment(enemyInfo.scoreWorth);
    }

    public void Decrement(int quantity)
    {
        currency -= quantity;
        onCurrencyChanged.Invoke(currency);
    }

    public bool CanBuyWeapon(WeaponInfo weaponInfo)
    {
        return currency >= weaponInfo.scoreWorth;
    }
}
