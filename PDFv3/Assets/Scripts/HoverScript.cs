using UnityEngine;
using System.Collections;

public class HoverScript : MonoBehaviour
{
    public float scaleFactor = 1.2f; // The factor by which the object will scale
    public float duration = 0.12f; // Very short duration for a snappy grow effect
    private Vector3 originalScale;
    private Coroutine currentCoroutine; // To keep track of the current animation
    private int defaultLayer = 0; // To store the original layer
    private int popoutLayer = 6; // The layer to switch to when growing

    void Start()
    {
        originalScale = transform.localScale;
        gameObject.layer = defaultLayer; 
    }

    public void growP()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        gameObject.layer = popoutLayer; // Switch to Popout layer
        float rs = scaleFactor - 1;
        rs = (float)(rs / 5);
        rs += 1;
        //GetComponent<PageHighlighter>().GrowRect(rs, duration);
        currentCoroutine = StartCoroutine(ScaleOverTime(originalScale * scaleFactor, duration));
    }

    public void shrinkP()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        float d = (float)(duration * 1.5);
        //GetComponent<PageHighlighter>().ShrinkRect(d);
        gameObject.layer = defaultLayer; // Switch back to Default layer
        currentCoroutine = StartCoroutine(ScaleOverTime(originalScale, duration));
    }
    public void quickSP()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        gameObject.layer = defaultLayer;
        transform.localScale = originalScale;
        //GetComponent<PageHighlighter>().QuickShrinkRect();

    }

    IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        // Ensure the layer is set back to Default after growing
        if (targetScale == originalScale)
        {
            gameObject.layer = defaultLayer;
        }
    }
}
