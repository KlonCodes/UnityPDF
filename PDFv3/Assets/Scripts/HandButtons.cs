using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InputBar;
    public GameObject SlideBar;
    public GameObject SFTBar;
    public GameObject WrapBar;


    private GameObject ActiveBar;
    private Transform ABTransform;

    public GameObject Reader;

    public void closePanes()
    {
        PageHandler pgs = Reader.GetComponent<PageHandler>();
        pgs.Toggler();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ActInput()
    {
        GetActiveBar();
        closePanes();

        SlideBar.SetActive(false);
        SFTBar.SetActive(false);
        WrapBar.SetActive(false);
        InputBar.SetActive(true);

        InputBar.transform.position = ABTransform.position;
        InputBar.transform.rotation = ABTransform.rotation;
        InputBar.GetComponent<RadialView>().enabled = ActiveBar.GetComponent<RadialView>().enabled;

    }
    public void ActSlide()
    {
        GetActiveBar();
        closePanes();
        InputBar.SetActive(false);
        SFTBar.SetActive(false);
        WrapBar.SetActive(false);
        SlideBar.SetActive(true);

        SlideBar.transform.position = ABTransform.position;
        SlideBar.transform.rotation = ABTransform.rotation;
        SlideBar.GetComponent<RadialView>().enabled = ActiveBar.GetComponent<RadialView>().enabled;
    }
    public void ActSFT()
    {
        GetActiveBar();
        closePanes();
        InputBar.SetActive(false);
        SlideBar.SetActive(false);
        WrapBar.SetActive(false);
        SFTBar.SetActive(true);

        SFTBar.transform.position = ABTransform.position;
        SFTBar.transform.rotation = ABTransform.rotation;
        SFTBar.GetComponent<RadialView>().enabled = ActiveBar.GetComponent<RadialView>().enabled;
    }
    public void ActWrap()
    {
        GetActiveBar();
        closePanes();
        WrapBar.transform.position = ABTransform.position;
        WrapBar.transform.rotation = ABTransform.rotation;
        WrapBar.GetComponent<RadialView>().enabled = ActiveBar.GetComponent<RadialView>().enabled;

        InputBar.SetActive(false);
        SlideBar.SetActive(false);
        SFTBar.SetActive(false);
        WrapBar.SetActive(true);

    }

    public void GetActiveBar()
    {
        ActiveBar = CheckActiveBar();
        ABTransform = ActiveBar.transform;
    }
    // Call this method to check which bar is active
    public GameObject CheckActiveBar()
    {
        if (InputBar.activeSelf)
            return InputBar;
        else if (SlideBar.activeSelf)
            return SlideBar;
        else if (SFTBar.activeSelf)
            return SFTBar;
        else if (WrapBar.activeSelf)
            return WrapBar;
        else
            InputBar.SetActive(true);
        return InputBar;
    }
}

