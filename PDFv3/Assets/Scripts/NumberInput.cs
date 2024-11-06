using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi; // Make sure to include the TextMeshPro namespace

public class NumberInput : MonoBehaviour
{
    public TMP_Text nd; // Assign your TextMeshProUGUI component here
    private string currentNumber = "";
    private int maxPage = 90;

    public GameObject Reader;

    public void AddNumber(string number)
    {
        if (currentNumber.Length >= 3)
        {
            currentNumber = currentNumber.Substring(1) + number;
        }
        else
        {
            currentNumber += number;
        }
        nd.text = currentNumber;
        nd.ForceMeshUpdate(); // Force the TMP text to update
    }
    public void nextPage()
    {
        int cn = int.Parse(currentNumber);
        if (cn >= maxPage)
        {
            currentNumber = "0";
        }
        else
        {
            cn += 1;
            currentNumber = cn.ToString();
        }
        nd.text = currentNumber;
        nd.ForceMeshUpdate(); // Force the TMP text to update
    }
    public void backPage()
    {
        int cn = int.Parse(currentNumber);
        if (cn <= 0)
        {
            currentNumber = maxPage.ToString();
        }
        else if (cn > maxPage)
        {
            currentNumber = maxPage.ToString();
        }
        else
        {
            cn -= 1;
            currentNumber = cn.ToString();
        }
        nd.text = currentNumber;
        nd.ForceMeshUpdate(); // Force the TMP text to update
    }
    public void send()
    {
        if (currentNumber.Length > 1)
        {
            currentNumber = currentNumber.TrimStart('0');
        }
        int cn = int.Parse(currentNumber);

        PageHandler pgs = Reader.GetComponent<PageHandler>();

        if (cn >= maxPage)
        {
            cn = maxPage-1;
        }
        else
        {
            cn = cn;
        }

        Debug.Log(cn);
        pgs.SetImage(cn);
        ClearNumber();
        nd.ForceMeshUpdate(); // Force the TMP text to update
        pgs.InputToggle();


    }
        public void ClearNumber()
    {
        currentNumber = "";
        nd.text = currentNumber;
    }
}
