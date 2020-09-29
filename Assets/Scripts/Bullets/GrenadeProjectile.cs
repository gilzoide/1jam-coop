using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    public float timeForExplosion = 0.5f;
    public float linearVelocity = 5f;
    public Animator bulletAnimator;
    public GameObject explosionObject;
    public Collider2D projectileCollider;

    void Awake()
    {
        if (!bulletAnimator)
        {
            bulletAnimator = GetComponentInChildren<Animator>();
        }
        if (!projectileCollider)
        {
            projectileCollider = GetComponentInChildren<Collider2D>();
        }
    }

    void Start()
    {
        bulletAnimator.speed = bulletAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length / timeForExplosion;
    }

    void Update()
    {
        transform.localPosition += (transform.up * linearVelocity * Time.deltaTime);
    }

    public void ExplosionStarted()
    {
        explosionObject.gameObject.SetActive(true);
        bulletAnimator.gameObject.SetActive(false);
        linearVelocity = 0f;
        StartCoroutine(Explode());
    }

    public void ExplosionEnded()
    {
        Destroy(gameObject);
    }

    private IEnumerator Explode()
    {
        projectileCollider.enabled = true;
        yield return null;
        projectileCollider.enabled = false;
    }
}
