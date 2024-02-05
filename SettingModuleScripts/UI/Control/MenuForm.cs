using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuForm : MonoBehaviour
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public Button systemSettingBtn;
    /// <summary>
    /// 设计模式
    /// </summary>
    public Button designModeBtn;
    /// <summary>
    /// 注册软件
    /// </summary>
    public Button registerSoftwareBtn;
    /// <summary>
    /// 退出按钮
    /// </summary>
    public Button exitBtn;

    public void Start()
    {
        systemSettingBtn.onClick.AddListener(SystemSettingsBtnClick);
        designModeBtn.onClick.AddListener(DesignModeBtnClick);
        registerSoftwareBtn.onClick.AddListener(RegisterSoftwareBtnClick);
        exitBtn.onClick.AddListener(ExitBtnClick);

    }

    public void OnEnable()
    {
        designModeBtn.gameObject.SetActive(UserConfig.DesginMode);
    }

    /// <summary>
    /// 打开设计模式
    /// </summary>
    private void DesignModeBtnClick()
    {
    }

    public void CloseSelf()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 打开设置按钮
    /// </summary>
    public void SystemSettingsBtnClick()
    {
        SettingParentPanel.Instance.settingForm.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 打开注册软件阿牛
    /// </summary>
    public void RegisterSoftwareBtnClick()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 退出程序
    /// </summary>
    public void ExitBtnClick()
    {
        Application.Quit();
    }
}