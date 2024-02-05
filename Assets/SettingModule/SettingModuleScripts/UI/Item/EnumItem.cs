using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class EnumItem : MonoBehaviour
{
    private SettingsItem selfSettingItem;

    public Text label;
    public Dropdown dropDown;
    public Text description;
    /// <summary>
    /// 存放key值
    /// </summary>
    private List<string> keys = new List<string>();
    /// <summary>
    /// 存放显隐的数据名称
    /// </summary>
    private Dictionary<string, List<string>> links = new Dictionary<string, List<string>>();
    private int currentSelectIndex = 0;
    public void Start()
    {
        dropDown.onValueChanged.AddListener((index) =>
        {
            if (index != currentSelectIndex)
            {
                selfSettingItem.Value = keys[index];
                LinkActive(keys[currentSelectIndex],false);
                currentSelectIndex = index;
                LinkActive(keys[currentSelectIndex]);
            }
        });
    }
    void LinkActive(string keyName,bool isActive = true)
    {
        if (links.ContainsKey(keyName))
        {
            SettingForm.Instance.LinksActive(links[keyName],isActive);
        }
    }
    public void Init(SettingsItem settingsItem)
    {
        selfSettingItem = settingsItem;
        label.text = selfSettingItem.Name;
        this.name = selfSettingItem.Key;
        description.text = selfSettingItem.Description;

        List<string> lstStr_Name = new List<string>();//存储
        for (int i = 0; i < selfSettingItem.Options.Count; i++)
        {
            lstStr_Name.Add(selfSettingItem.Options[i].Text);
            keys.Add(selfSettingItem.Options[i].Key);
            if (selfSettingItem.Options[i].Links!=null)
            {
                string[] splitLinks = selfSettingItem.Options[i].Links.Split(',');
                links.Add(selfSettingItem.Options[i].Key,splitLinks.ToList());
            }
        }
        //添加下拉数据
        dropDown.AddOptions(lstStr_Name);
        //设置初始下拉数据
        currentSelectIndex = keys.FindIndex(obj => obj == selfSettingItem.Value);
        //设置初始值
        dropDown.SetValueWithoutNotify(currentSelectIndex);
        //需要等待页面加载完成之后才可以隐藏
        StartCoroutine(WaitArraysLoadFinsh());
    }
    IEnumerator WaitArraysLoadFinsh()
    {
        yield return SettingForm.Instance.isLoadFinish;
        //先把所有的link 给隐藏掉
        foreach (var link in links)
        {
            LinkActive(link.Key,false);
        }
        //再把当前选中的link给显示出来
        LinkActive(keys[currentSelectIndex]);
    }
}
