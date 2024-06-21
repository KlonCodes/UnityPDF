using UnityEngine;
using System.Collections;
using MixedReality.Toolkit;
using Unity.VisualScripting;

public class HoverScript : MonoBehaviour
{
    public float scaleFactor = 2f; // The factor by which the object will scale
    public float duration = 0.12f; // Very short duration for a snappy grow effect
    private Vector3 originalScale;
    private Coroutine currentCoroutine; // To keep track of the current animation
    public GameObject Reader;

    private Canvas canvas;
    private int originalSortingOrder;

    private StatefulInteractable SI;

    void Start()
    {
        originalScale = transform.localScale;
        canvas = GetComponent<Canvas>();
        canvas.sortingOrder = 0;
        originalSortingOrder = canvas.sortingOrder;

        SI = GetComponent<StatefulInteractable>();
        SI.OnClicked.AddListener(SendPage);

    }

    public void growP()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        float rs = scaleFactor - 1;
        rs = (float)(rs / 5);
        rs += 1;

        canvas.sortingOrder = originalSortingOrder + 1;

        currentCoroutine = StartCoroutine(ScaleOverTime(originalScale * scaleFactor, duration));
    }

    public void shrinkP()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        float d = (float)(duration * 1.5);

        canvas.sortingOrder = originalSortingOrder;

        currentCoroutine = StartCoroutine(ScaleOverTime(originalScale, duration));
    }
    public void quickSP()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        transform.localScale = originalScale;
        canvas.sortingOrder = originalSortingOrder;

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
    }

    public void SendPage()
    {

        PageHandler pgs = Reader.GetComponent<PageHandler>();

        string pName = gameObject.name[2..];
        int pNum = int.Parse(pName);
        pNum -= 1;
        Debug.Log(pNum);
        pgs.SetImage(pNum);
        quickSP();
        pgs.Toggler();


    }
}
