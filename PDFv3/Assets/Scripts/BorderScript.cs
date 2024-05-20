using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    private int pNum; // The value to check for
    private int P;
    public GameObject reader;
    private GameObject border;
    private bool showBorder = false;

    // Start is called before the first frame update
    void Start()
    {
        string pName = gameObject.name[2..];
        pNum = int.Parse(pName) - 1;

        border = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        P = reader.GetComponent<PageHandler>().p;
        showBorder = (P == pNum);
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
