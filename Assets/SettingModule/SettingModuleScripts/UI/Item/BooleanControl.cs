using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BooleanControl : MonoBehaviour
{
    private SettingsItem _settingsItem;
    public Toggle thisToggle;
    public Text lable;

    public List<string> activeLinks = new List<string>();
    public List<string> notActiveLinks = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        thisToggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    private void ToggleValueChanged(bool isOn)
    {
        Debug.LogError("选中"+isOn);
        _settingsItem.ValueText = isOn.ToString();
        LinksActive(isOn);
    }
    public void Init(SettingsItem settingsItem)
    {
        _settingsItem = settingsItem;
        lable.text = _settingsItem.Name;
        this.name = settingsItem.Key;
        thisToggle.isOn = bool.Parse(_settingsItem.ValueText);
        ProcessLink();
        //需要等待页面加载完成之后才可以隐藏
        StartCoroutine(WaitArraysLoadFinsh(thisToggle.isOn));
    }
    IEnumerator WaitArraysLoadFinsh(bool isSelect)
    {
        yield return SettingForm.Instance.isLoadFinish;
        LinksActive(isSelect);
    }
    /// <summary>
    /// 处理一下link数组，如果字符串以 '!' 开头，认为是 取反
    /// </summary>
    private void ProcessLink()
    {
            Debug.LogError("selfSettingItem.Link"+_settingsItem.Links);
        if (_settingsItem.Links!=null)
        {
            string[] splitLinks = _settingsItem.Links.Split(',');
            for (int i = 0; i < splitLinks.Length; i++)
            {
                bool isNegation = splitLinks[i].StartsWith("!");
                if (isNegation)
                {
                    notActiveLinks.Add(splitLinks[i].Substring(1));
                }
                else
                {
                    activeLinks.Add(splitLinks[i]);
                }
            }
        }
    }

    private void LinksActive(bool isSelect)
    {
        for (int i = 0; i < activeLinks.Count; i++)
        {
            SettingForm.Instance.LinksActive(activeLinks,isSelect);
        }
        for (int i = 0; i < notActiveLinks.Count; i++)
        {
            SettingForm.Instance.LinksActive(notActiveLinks,!isSelect);
        }
    }
}
