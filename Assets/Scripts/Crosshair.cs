using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float minAngle = 0;
    public float maxAngle = 0;
    public float initialAngle;
    public float angularSpeed = 30f;

    private float angle;

    void Awake()
    {
        angle = initialAngle;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void Rotate(float horizontalAxis)
    {
        if (Mathf.Abs(horizontalAxis) > 0.01)
        {
            angle -= horizontalAxis * angularSpeed * Time.deltaTime;
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    public void AimDirectional(float horizontalAxis, float verticalAxis)
    {
        if (Mathf.Abs(horizontalAxis) > 0.01 || Mathf.Abs(verticalAxis) > 0.01)
        {
            angle = Vector3.SignedAngle(Vector3.up, new Vector3(horizontalAxis, verticalAxis, 0), Vector3.forward);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    public void LookAt(Transform target)
    {
        angle = Vector3.SignedAngle(Vector3.up, target.position - transform.position, Vector3.forward);
        transform.eulerAngles = new Vector3(0, 0, angle);
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
