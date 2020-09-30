using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    public EnergyHolder energyHolder;
    public SpriteRenderer energyBarSpriteRenterer;
    public Animator animator;
    public Collider2D enemyCollider;
    public AudioSource audioSource;
    public AudioClip explosionAudioClip;
    public UnityEvent<EnemyInfo> onEnemyDestroyed;
    public UnityEvent<Transform> onSetupWithTrain;
    
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

    public void SetupWithTrainAndAudioSource(Transform train, AudioSource audioSource)
    {
        this.audioSource = audioSource;
        onSetupWithTrain.Invoke(train);
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

    public void PlayDestroySound()
    {
        audioSource.PlayOneShot(explosionAudioClip);
    }

    public void DestroySelf()
    {
        animator.enabled = false;
        Destroy(gameObject);
    }
}
