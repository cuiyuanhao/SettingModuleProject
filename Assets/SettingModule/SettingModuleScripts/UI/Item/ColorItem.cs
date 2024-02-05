using System;
using System.Collections;
using System.Collections.Generic;
using ColorUiTools;
using UnityEngine;
using UnityEngine.UI;

public class ColorItem : MonoBehaviour
{
    private SettingsItem selfSettingsItem;

    /// <summary>
    /// 标题
    /// </summary>
    public Text label;

    /// <summary>
    /// 颜色的Hex显示框
    /// </summary>
    public InputField colorInputField;

    /// <summary>
    /// 用来打开选择板的按钮
    /// </summary>
    public Button openColorPickBtn;

    /// <summary>
    /// 当前的颜色
    /// </summary>
    public RawImage CurrentColorImage;

    /// <summary>
    /// 备注
    /// </summary>
    public Text descriptionText;

    /// <summary>
    /// 选色板的取消按钮
    /// </summary>
    public Button cancelBtn;

    /// <summary>
    /// 选色板的确定按钮
    /// </summary>
    public Button sureBtn;

    /// <summary>
    /// 用来打开选色板
    /// </summary>
    public GameObject colorPickerParent;


    public ColorPicker _colorPicker;

    private void Start()
    {
        openColorPickBtn.onClick.AddListener(OpenColorPickAction);
        cancelBtn.onClick.AddListener(CloseColorPickAction);
        sureBtn.onClick.AddListener(SureColorPickAndCloseAction);
    }

    private void SureColorPickAndCloseAction()
    {
        CurrentColorImage.color = _colorPicker.Color;
        colorInputField.text = "#" + _colorPicker.HEXA;
        selfSettingsItem.ValueText = colorInputField.text;
        colorPickerParent.SetActive(false);
    }

    private void CloseColorPickAction()
    {
        colorPickerParent.SetActive(false);
        //CurrentColorImage.color = _colorPicker.Color;
    }

    private void OpenColorPickAction()
    {
        colorPickerParent.SetActive(true);
        //得等一下，等他初始化完成
        StartCoroutine(WairColorPickerInitFinish());
    }

    IEnumerator WairColorPickerInitFinish()
    {
        yield return _colorPicker.isInitFinish;
        _colorPicker.Init(CurrentColorImage.color);
    }

    public void Init(SettingsItem settingsItem)
    {
        selfSettingsItem = settingsItem;
        colorInputField.text = selfSettingsItem.Default;
        label.text = selfSettingsItem.Name;
        // 尝试解析十六进制颜色值
        Color color;

        if (selfSettingsItem.ValueText != null)
        {
            SetColorFromHex(selfSettingsItem.ValueText);
        }
        else if (selfSettingsItem.Default != null)
        {
            SetColorFromHex(selfSettingsItem.Default);
        }
    }

    void SetColorFromHex(string hexValue)
    {
        if (ColorUtility.TryParseHtmlString(hexValue, out Color color))
        {
            // 将解析后的颜色值赋给Image组件
            CurrentColorImage.color = color;
        }
        else
        {
            Debug.LogError("Failed to parse hex color");
        }
    }
}