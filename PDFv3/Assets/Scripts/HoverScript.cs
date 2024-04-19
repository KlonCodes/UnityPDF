using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverScript : MonoBehaviour
{
    public float scaleFactor = 1.5f; // The factor by which the object will scale
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnHoverEntered()
    {
        transform.localScale = originalScale * scaleFactor;
    }

    public void OnHoverExited()
    {
        transform.localScale = originalScale;
    }
}
