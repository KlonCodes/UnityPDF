using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using Slider = MixedReality.Toolkit.UX.Slider;

public class PageHandler : MonoBehaviour
{
    private Sprite[] pages;
    public Image imageContainer;
    public GameObject readingPane;
    public GameObject pageGrid;
    public GameObject pageWrap;

    public Camera mainCamera = Camera.main;

    public PageHandler(Camera mainCamera)
    {
        this.mainCamera = mainCamera;
    }

    Vector3 userPosition;
    Quaternion userRotation;
    public float planeD = 2.0f;
    public float wrapD = 2.0f;

    public int p = 0; //current page number

    private void Start()
    {
        pages = Resources.LoadAll<Sprite>("Sprites");

        pages = pages.OrderBy(
        s => int.Parse(s.name.Substring(s.name.LastIndexOf('_') + 1))
).ToArray();
    }
    void Update()
    {
        // Get the main camera's position and rotation
        userPosition = mainCamera.transform.position;
        userRotation = mainCamera.transform.rotation;
    }

    public void SetImage(int index)
    {
        // Check if the index is within the bounds of the array
        if (index >= 0 && index < pages.Length)
        {
            imageContainer.sprite = pages[index];
            p = index;
        }
        else
        {
            Debug.LogError("Invalid image index: " + index);
        }
    }

    public void GridToggle()
    {
        ViewToggle(pageGrid, planeD);
    }

    public void WrapToggle()
    {
        ViewToggle(pageWrap, wrapD);
    }

    public void ViewToggle(GameObject OTT, float D)
    {
        Vector3 positionInFront = userPosition + (mainCamera.transform.forward * D);
        OTT.transform.position = positionInFront;
        OTT.transform.LookAt(userPosition);
        OTT.transform.rotation = Quaternion.Euler(0.0f, OTT.transform.rotation.eulerAngles.y, 0.0f);
        OTT.transform.Rotate(0f, 180f, 0f);

        readingPane.SetActive(!readingPane.activeSelf);
        OTT.SetActive(!OTT.activeSelf);
    }

    public void NextPage()
    {
        if (p < pages.Length - 1) { p += 1; }
        else p = 0;
        SetImage(p);
    }

    public void LastPage()
    {
        if (p > 0) { p -= 1; }
        else p = pages.Length - 1;
        SetImage(p);
    }

    //[System.Obsolete]
    [Obsolete]
    public void SetSlide(GameObject S)
    {
        Slider sliderScript = S.GetComponent<Slider>();
        float sliderValue = sliderScript.SliderValue;
        int s = (int)sliderValue;
        Debug.Log("Value is " + sliderValue);
        SetImage(s);
    }

}
