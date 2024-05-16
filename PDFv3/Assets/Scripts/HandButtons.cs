using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ButtonBar;
    public GameObject SlideBar;
    public GameObject SFTBar;
    public GameObject WrapBar;


    private GameObject ActiveBar;
    private Transform ABTransform;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ActButton()
    {
        GetActiveBar();

        SlideBar.SetActive(false);
        SFTBar.SetActive(false);
        WrapBar.SetActive(false);
        ButtonBar.SetActive(true);

        ButtonBar.transform.position = ABTransform.position;
        ButtonBar.transform.rotation = ABTransform.rotation;
        ButtonBar.GetComponent<RadialView>().enabled = ActiveBar.GetComponent<RadialView>().enabled;

    }
    public void ActSlide()
    {
        GetActiveBar();

        ButtonBar.SetActive(false);
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

        ButtonBar.SetActive(false);
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
        WrapBar.transform.position = ABTransform.position;
        WrapBar.transform.rotation = ABTransform.rotation;
        WrapBar.GetComponent<RadialView>().enabled = ActiveBar.GetComponent<RadialView>().enabled;

        ButtonBar.SetActive(false);
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
        if (ButtonBar.activeSelf)
            return ButtonBar;
        else if (SlideBar.activeSelf)
            return SlideBar;
        else if (SFTBar.activeSelf)
            return SFTBar;
        else if (WrapBar.activeSelf)
            return WrapBar;
        else
            ButtonBar.SetActive(true);
        return ButtonBar;
    }
}

