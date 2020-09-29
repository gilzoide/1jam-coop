using UnityEngine;
using UnityEngine.Events;

public class GetNear : MonoBehaviour
{
    public float linearSpeed = 10f;
    public float nearDistance = 0f;
    public Transform target;

    public UnityEvent onNear;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        if (distance <= nearDistance)
        {
            onNear.Invoke();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, linearSpeed * Time.deltaTime);
        }
    }
}
