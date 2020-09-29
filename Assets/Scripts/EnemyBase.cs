using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    public EnergyHolder energyHolder;
    public SpriteRenderer energyBarSpriteRenterer;
    public Animator animator;
    public Collider2D enemyCollider;
    public UnityEvent<EnemyInfo> onEnemyDestroyed;
    
    void Awake()
    {
        if (!energyHolder)
        {
            energyHolder = GetComponent<EnergyHolder>();
        }
        if (!energyBarSpriteRenterer)
        {
            energyBarSpriteRenterer = GetComponentInChildren<SpriteRenderer>();
        }
        if (!animator)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    public void ResizeEnergyBar(float normalizedValue)
    {
        var size = energyBarSpriteRenterer.size;
        size.x = normalizedValue;
        energyBarSpriteRenterer.size = size;
    }

    public void StartDestroyingSelf()
    {
        enemyCollider.enabled = false;
        animator.SetBool("died", true);
        onEnemyDestroyed.Invoke(enemyInfo);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
