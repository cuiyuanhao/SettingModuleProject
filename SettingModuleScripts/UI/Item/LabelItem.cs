using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelItem : MonoBehaviour
{
    public Text thisText;
    private SettingsItem selfSettingItem;
    public string tempText;
    public void Init(SettingsItem settingsItem)
    {
        selfSettingItem = settingsItem;
        thisText.text = selfSettingItem.Name;
    }
    void Update()
    {
        // 检查文本是否发生了变化
        if (thisText != null && thisText.text != tempText)
        {
            OnTextValueChanged(thisText.text);
            tempText = thisText.text;
        }
    }
    // 文本改变时调用的方法
    void OnTextValueChanged(string newText)
    {
        Debug.Log("文本改变了：" + newText);
        selfSettingItem.ValueText = newText;
        // 在这里可以执行你想要的操作
    }
}
