using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringItem : MonoBehaviour
{
    private SettingsItem selfSettingItem;

    public Text label;
    public InputField InputField;
    public Text description;


    private void Awake()
    {
        InputField.onEndEdit.AddListener((str) =>
        {
            selfSettingItem.ValueText = str;
        });
    }

    public void Init(SettingsItem settingsItem)
    {
        selfSettingItem = settingsItem;
        label.text = selfSettingItem.Name;
        InputField.text = selfSettingItem.ValueText;
        description.text = selfSettingItem.Description;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
