
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    public float scaleFactor = 1.2f; // The factor by which the object will scale
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void growP()
    {
        transform.localScale = originalScale * scaleFactor;
    }

    public void shrinkP()
    {
        transform.localScale = originalScale;
    }
}
