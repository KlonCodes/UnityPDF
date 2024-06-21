using UnityEngine;
using MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class HoverScript3 : MonoBehaviour
{
    public GameObject Reader;

    private StatefulInteractable SI;
    private MRTKBaseInteractable MBI;

    private RawImage originalRawImage;
    private GameObject newGameObject;


    void Start()
    {
        SI = GetComponent<StatefulInteractable>();
        SI.OnClicked.AddListener(SendPage);

        MBI = GetComponent<MRTKBaseInteractable>();
        MBI.IsRayHovered.OnEntered.AddListener(toHovin);
        MBI.IsRayHovered.OnExited.AddListener(toHovout);

        originalRawImage = GetComponent<RawImage>();
    }

    private void toHovout(float arg0)
    {
        hovout();
    }

    private void toHovin(float arg0)
    {
        hovin();
    }



    public void hovin()
    {
        //reset image position
        originalRawImage = GetComponent<RawImage>();

        // Create the new GameObject
        newGameObject = new GameObject("NewCanvasWithImage");

        // Add a Canvas component to the new GameObject
        Canvas canvas = newGameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.sortingOrder = 100; // Ensure it renders on top
        CanvasScaler cs = newGameObject.AddComponent<CanvasScaler>();
        cs.scaleFactor = 10.0f;
        cs.dynamicPixelsPerUnit = 10f;
        GraphicRaycaster gr = newGameObject.AddComponent<GraphicRaycaster>();

        // Create a RawImage and make it a child of the Canvas
        RawImage newRawImage = newGameObject.AddComponent<RawImage>();
        newRawImage.texture = originalRawImage.texture; // Copy the texture from the original RawImage
        newRawImage.uvRect = originalRawImage.uvRect; // Copy the uvRect from the original RawImage

        // Add an AspectRatioFitter to maintain the aspect ratio
        AspectRatioFitter aspectRatioFitter = newGameObject.AddComponent<AspectRatioFitter>();
        aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
        aspectRatioFitter.aspectRatio = (float)originalRawImage.texture.width / originalRawImage.texture.height;

        // Set the local scale of the new GameObject (adjust as needed)
        newGameObject.transform.localScale = Vector3.one * 0.002f; // Example scale

        // Position the new GameObject in the same direction the object is facing
        newGameObject.transform.position = originalRawImage.transform.position;
        newGameObject.transform.rotation = originalRawImage.transform.rotation;

        // Optionally, adjust the position based on the object's forward direction
        newGameObject.transform.position += originalRawImage.transform.forward * 0.002f;
    }


    public void hovout()
    {
        // Destroy the hover canvas
        if (newGameObject != null)
        {
            Destroy(newGameObject);
        }
    }


    public void SendPage()
    {
        PageHandler pgs = Reader.GetComponent<PageHandler>();

        string pName = gameObject.name[2..];
        int pNum = int.Parse(pName);
        pNum -= 1;
        Debug.Log(pNum);
        pgs.SetImage(pNum);
        pgs.Toggler();


    }
}
