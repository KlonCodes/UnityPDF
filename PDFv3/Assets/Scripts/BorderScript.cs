using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public int pNumber; // The value to check for
    private int P;
    public GameObject eReader;
    private GameObject border;
    private bool showBorder = false;

    // Start is called before the first frame update
    void Start()
    {
        border = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        P = eReader.GetComponent<PageHandler>().p;
        showBorder = (P == pNumber);
    }

    void OnGUI()
    {
        if (showBorder)
        {
            border.SetActive(true);
        }
        else { border.SetActive(false); }
    }
}
