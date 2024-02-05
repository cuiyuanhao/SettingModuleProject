using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingParentPanel : MonoBehaviour
{
    public static SettingParentPanel Instance = null;
    public MenuForm menuForm;
    public PasswordForm passwordForm;
    public SettingForm settingForm;
    public Button settingBtn;


    private float clickTime;
    private int clickCount = 0;
    public float timeBetweenClicks = 0.5f;
    private void Awake()
    {
        Instance = this;
        BuidUI();
    }
    private void BuidUI()
    {
        settingBtn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (Time.time - clickTime < timeBetweenClicks)
        {
            clickCount++;

            if (clickCount == 2)
            {
                OpenPanel();
            }
        }
        else
        {
            clickCount = 1;
        }

        clickTime = Time.time;
    }

    private void OpenPanel()
    {
        if (!UserConfig.UsePassword)
        {
            menuForm.gameObject.SetActive(true);
        }
        else
        {
            passwordForm.gameObject.SetActive(true);
        }
    }
}
