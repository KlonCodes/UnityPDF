using UnityEngine;

public class PageHighlighter : MonoBehaviour
{
    public int pNumber; // The value to check for
    public GameObject eReader; // The object with the PageHandler script
    public int thickness = 2; // Thickness of the border
    public Color outlineColor = Color.red; // Color of the border

    private int P; // The current value of P
    private Camera mainCamera;
    private bool showBorder = false;
    private Rect fixedRect; // Fixed rectangle for the border

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        P = eReader.GetComponent<PageHandler>().p;
        showBorder = (P == pNumber);

        if (showBorder)
        {
            // Recalculate the bounds and update the fixed rectangle
            CalculateFixedRectangle();
        }
    }

    void CalculateFixedRectangle()
    {
        // Convert the object's bounds to screen space
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 min = mainCamera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.center.z));
        Vector3 max = mainCamera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.center.z));

        // Update the fixed rectangle
        fixedRect = new Rect(min.x, Screen.height - max.y, max.x - min.x, max.y - min.y);
    }

    void OnGUI()
    {
        if (showBorder)
        {
            // Draw the border using the fixed rectangle
            DrawBorder(fixedRect, thickness);
        }
    }

    void DrawBorder(Rect rect, float thickness)
    {
        // Draw the border around the rectangle
        GUI.color = outlineColor;
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, rect.width, thickness), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, thickness, rect.height), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), Texture2D.whiteTexture);
    }
}
