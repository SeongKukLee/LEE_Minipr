using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public Button btn;
    public TMP_InputField inputField;
    public Toggle toggle;
    public Slider slider;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClkEvent()
    {
        print(inputField.text);
        print(toggle.onValueChanged);

        if (toggle.isOn)
        {
            // 시계 작동

        }
    }
}
