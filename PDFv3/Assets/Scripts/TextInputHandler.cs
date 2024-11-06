using TMPro;
using UnityEngine;

public class TextInputHandler : MonoBehaviour
{
    public TMP_InputField userIdInputField;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnButtonClick(string text)
    {
        if (text == "")
        {
            if (userIdInputField.text.Length > 0){
                userIdInputField.text = userIdInputField.text.Substring(0, userIdInputField.text.Length - 1);
            }
        }
        else{
            userIdInputField.text += text;
        }
    }

}
