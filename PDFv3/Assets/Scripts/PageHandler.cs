using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Slider = MixedReality.Toolkit.UX.Slider;

public class PageHandler : MonoBehaviour
{
    public Sprite[] pages;
    public Image imageContainer;
    public GameObject readingPane;
    public GameObject pageGrid;
    public int p = 0; //current page number

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
        readingPane.SetActive(!readingPane.activeSelf);
        pageGrid.SetActive(!pageGrid.activeSelf);
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
        else p = pages.Length-1;
        SetImage(p);
    }

    //[System.Obsolete]
    public void SetSlide(GameObject S)
    {
        Slider sliderScript = S.GetComponent<Slider>();
        float sliderValue = sliderScript.SliderValue;
        int s = (int)sliderValue;
        Debug.Log("Value is " + sliderValue);
        SetImage(s);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
