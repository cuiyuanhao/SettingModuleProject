using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTab : MonoBehaviour
{
    public Toggle thisToggle;
    public Text thisText;
    private SettingsArrays selfSettingsArrays;
    private void Awake()
    {
        thisToggle.group = SettingForm.Instance.bodyContent.GetComponent<ToggleGroup>();
        thisToggle.onValueChanged.AddListener(ChangeTabState);
    }

    private void ChangeTabState(bool isOn)
    {
        if (isOn)
        {
            thisText.color = Color.white;
            SettingForm.Instance.CreateArrayBody(selfSettingsArrays);
        }
        else
        {
            thisText.color = Color.black;
        }


    }

    public void Init(SettingsArrays settingsArrays)
    {
        selfSettingsArrays = settingsArrays;
        gameObject.name = settingsArrays.Key;
        thisText.text = selfSettingsArrays.Name;
        // thisToggle.isOn = bool.Parse(_settingsItem.ValueText);
    }

}
