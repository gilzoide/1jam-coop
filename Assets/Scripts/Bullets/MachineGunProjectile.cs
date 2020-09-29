using UnityEngine;

public class MachineGunProjectile : MonoBehaviour
{
    public float initialVelocity = 10f;
    
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.up * initialVelocity;
        rigidBody.WakeUp();
        GameObject.Destroy(gameObject, 3f);
    }
}
