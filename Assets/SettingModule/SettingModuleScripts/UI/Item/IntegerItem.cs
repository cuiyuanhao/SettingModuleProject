using System;
using UnityEngine;
using UnityEngine.UI;

public class IntegerItem : MonoBehaviour
{
    private SettingsItem selfSettingItem;
    public Text label;
    public InputField InputField;

    /// <summary>
    /// 减少
    /// </summary>
    public Button decrementBtn;

    /// <summary>
    /// 增加
    /// </summary>
    public Button incrementBtn;

    public Text descriptionText;

    private void Awake()
    {
        decrementBtn.onClick.AddListener(DecrementCount);
        incrementBtn.onClick.AddListener(IncrementCount);
        InputField.onEndEdit.AddListener((num) =>
        {
            int temp = int.Parse(num);
            if (selfSettingItem.Min != null && selfSettingItem.Max != null)
            {
                if (temp >= int.Parse(selfSettingItem.Min) && temp <= int.Parse(selfSettingItem.Max))
                {
                    selfSettingItem.ValueText = temp.ToString();
                }
                selfSettingItem.ValueText = InputField.text;
            }
            else
            {
                InputField.text = selfSettingItem.ValueText;
            }
        });
    }

    /// <summary>
    /// 增加
    /// </summary>
    private void IncrementCount()
    {
        int num = int.Parse(InputField.text);
        if (selfSettingItem.Max != null)
        {
            if (num < int.Parse(selfSettingItem.Max))
            {
                num += int.Parse(selfSettingItem.Increment);
            }
        }
        else
        {
            num += int.Parse(selfSettingItem.Increment);
        }

        InputField.text = num.ToString();
        selfSettingItem.ValueText = InputField.text;
    }

    /// <summary>
    /// 减少
    /// </summary>
    private void DecrementCount()
    {
        int num = int.Parse(InputField.text);
        if (selfSettingItem.Min != null)
        {
            if (num > int.Parse(selfSettingItem.Min))
            {
                num -= int.Parse(selfSettingItem.Increment);
            }
        }
        else
        {
            num -= int.Parse(selfSettingItem.Increment);
        }
        InputField.text = num.ToString();
        selfSettingItem.ValueText = InputField.text;
    }
    public void Init(SettingsItem settingsItem)
    {
        selfSettingItem = settingsItem;
        label.text = selfSettingItem.Name;
        this.name = selfSettingItem.Key;
        descriptionText.text = selfSettingItem.Description;
        InputField.text = selfSettingItem.ValueText;
    }
}