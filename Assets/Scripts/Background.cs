using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    private Vector2 startPos;

    void Awake()
    {
        startPos = new Vector2(0, -9.15f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;

        if (transform.position.y < -37.45f)
        {
            transform.position = startPos;
        }
    }
}
