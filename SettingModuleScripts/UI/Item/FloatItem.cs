using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatItem : MonoBehaviour
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
            float temp = float.Parse(num);
            if (selfSettingItem.Min != null && selfSettingItem.Max != null)
            {
                if (temp >= float.Parse(selfSettingItem.Min) && temp <= float.Parse(selfSettingItem.Max))
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
        float num = float.Parse(InputField.text);
        if (selfSettingItem.Max != null)
        {
            if (num < float.Parse(selfSettingItem.Max))
            {
                num += float.Parse(selfSettingItem.Increment);
            }
        }
        else
        {
            num += float.Parse(selfSettingItem.Increment);
        }

        InputField.text = num.ToString("f2");
        selfSettingItem.ValueText = InputField.text;
    }

    /// <summary>
    /// 减少
    /// </summary>
    private void DecrementCount()
    {
        float num = float.Parse(InputField.text);
        if (selfSettingItem.Min != null)
        {
            if (num > float.Parse(selfSettingItem.Min))
            {
                num -= float.Parse(selfSettingItem.Increment);
            }
        }
        else
        {
            num -= float.Parse(selfSettingItem.Increment);
        }

        InputField.text = num.ToString("f2");
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
