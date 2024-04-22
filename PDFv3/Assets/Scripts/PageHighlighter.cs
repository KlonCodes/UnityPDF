using UnityEngine;
using System.Collections;
using Unity.VisualScripting.FullSerializer;

public class PageHighlighter : MonoBehaviour
{
    public int pNumber; // The value to check for
    public GameObject eReader;
    public int thickness = 2;
    public Color outlineColor = Color.red;

    private int P;
    private Camera mainCamera;
    private bool showBorder = false;

    private Rect staticRect;
    private Rect oRect;

    private Vector3 originalScale;
    public bool made = false;

    private Coroutine currentRectCoroutine;

    void Start()
    {
        mainCamera = Camera.main;
        originalScale = transform.localScale;
        if (made==false)
        {
            CalculateStaticRectangle();
            made = true;
        }
    }

    void Update()
    {
        P = eReader.GetComponent<PageHandler>().p;
        showBorder = (P == pNumber);
    }

    void CalculateStaticRectangle()
    {
        // Convert object's bounds to screen space
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 min = mainCamera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.center.z));
        Vector3 max = mainCamera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.center.z));

        // Establish dimensions
        staticRect = new Rect(min.x, Screen.height - max.y, max.x - min.x, max.y - min.y);
        oRect = new Rect(min.x, Screen.height - max.y, max.x - min.x, max.y - min.y);
    }

    public void GrowRect(float scaleFactor, float duration)
    {
        if (currentRectCoroutine != null)
        {
            StopCoroutine(currentRectCoroutine);
        }
        currentRectCoroutine = StartCoroutine(AdjustRectSizeOverTime(originalScale * (scaleFactor), duration));
    }

    public void ShrinkRect(float duration)
    {
        if (currentRectCoroutine != null)
        {
            StopCoroutine(currentRectCoroutine);
        }
        currentRectCoroutine = StartCoroutine(AdjustRectSizeOverTime(originalScale, duration));
        staticRect = oRect;
    }
    public void QuickShrinkRect()
    {
        AdjustRectangleSize(originalScale);
        staticRect = oRect;

    }

    private void AdjustRectangleSize(Vector3 scale)
    {
        float widthScaleFactor = (scale.x / originalScale.x);
        float heightScaleFactor = (scale.y / originalScale.y);

        // Convert object's bounds to screen space
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 min = mainCamera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.center.z));
        Vector3 max = mainCamera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.center.z));

        // Adjust the rectangle dimensions based on the object's current scale
        staticRect.width = (max.x - min.x) * widthScaleFactor;
        staticRect.height = (max.y - min.y) * heightScaleFactor;
        staticRect.x = min.x - (staticRect.width - (max.x - min.x)) / 2;
        staticRect.y = Screen.height - max.y - (staticRect.height - (max.y - min.y)) / 2;
    }


    void OnGUI()
    {
        if (showBorder)
        {
            DrawBorder(staticRect, thickness);
        }
    }

    void DrawBorder(Rect rect, float thickness)
    {
        // Draw the rectangle
        GUI.color = outlineColor;
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, rect.width, thickness), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, thickness, rect.height), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), Texture2D.whiteTexture);
    }

    IEnumerator AdjustRectSizeOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            Vector3 scale = Vector3.Lerp(startScale, targetScale, timeElapsed / duration);
            AdjustRectangleSize(scale);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        AdjustRectangleSize(targetScale);
    }
}