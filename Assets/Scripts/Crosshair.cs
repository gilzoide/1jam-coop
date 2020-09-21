using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float minAngle = 0;
    public float maxAngle = 0;
    public float angularSpeed = 30f;
    public Transform projectileSpawnPoint;

    private float angle;

    void Awake()
    {
        angle = Mathf.Clamp(transform.eulerAngles.z, minAngle, maxAngle);
    }

    public void AimAt(float horizontalAxis, float verticalAxis)
    {
        if (Mathf.Abs(horizontalAxis) > 0.01)
        {
            angle -= horizontalAxis * angularSpeed * Time.deltaTime;
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    public void Shoot(GameObject projectilePrefab)
    {
        GameObject.Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
    }

    [ContextMenu("Set minAngle")]
    void SetMinAngle()
    {
        minAngle = transform.eulerAngles.z;
        if (minAngle > 180f)
        {
            minAngle -= 360f;
        }
    }
    [ContextMenu("Set maxAngle")]
    void SetMaxAngle()
    {
        maxAngle = transform.eulerAngles.z;
    }
}
