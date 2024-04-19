using UnityEngine;

public class PageHighlighter : MonoBehaviour
{
    public int pNumber; // The value to check for
    public GameObject eReader; // The object with the PageHandler script
    public int thickness = 2;
    public Color outlineColor = Color.red;

    private int P; // The current value of P
    private Camera mainCamera;
    private bool showBorder = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        P = eReader.GetComponent<PageHandler>().p;
        showBorder = (P == pNumber);
    }

    void OnGUI()
    {
        if (showBorder)
        {
            // Convert the object's bounds to screen space
            Bounds bounds = GetComponent<Renderer>().bounds;
            Vector3 min = mainCamera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.center.z));
            Vector3 max = mainCamera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.center.z));

            // Draw a rectangle around the object
            GUI.color = outlineColor;
            Rect rect = new Rect(min.x, Screen.height - max.y, max.x - min.x, max.y - min.y);
            DrawBorder(rect, thickness); // Thickness of x pixels
        }
    }

    void DrawBorder(Rect rect, float thickness)
    {
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, rect.width, thickness), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, thickness, rect.height), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), Texture2D.whiteTexture);
    }
}
