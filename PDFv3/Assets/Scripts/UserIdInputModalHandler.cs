using System;
using TMPro;
using UnityEngine;

public class UserIdInputModalHandler : MonoBehaviour

{
    public Action<int> OnSubmit;
    public TMP_InputField userIdInputField;

    public void OnSubmitClick()
    {
        if (userIdInputField != null && userIdInputField.text != "")
        {
            string userId = userIdInputField.text;
            OnSubmit(Int32.Parse(userId));
        }
    }
}
