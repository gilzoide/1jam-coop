using UnityEngine;

public class SpriteTint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    public void SetAlpha(float alpha)
    {
        var color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
