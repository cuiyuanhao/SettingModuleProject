using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingForm : MonoBehaviour
{
    public static SettingForm Instance = null;

    /// <summary>
    /// table 父物体
    /// </summary>
    public Transform bodyContent;
    /// <summary>
    /// 设置页父物体
    /// </summary>
    public Transform arrayContent;
    /// <summary>
    /// 确定按钮
    /// </summary>
    public Button sureBtn;
    /// <summary>
    /// 取消按钮
    /// </summary>
    public Button cancelBtn;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public Button closeBtn;

    public Text descriptionText;

    // private Button
    // Start is called before the first frame update

    public SettingTab res_SettingTab;
    public BooleanControl res_BooleanItem;
    public GameObject res_BreakItem;
    public ColorItem res_ColorItem;
    public GameObject res_DoubleItem;
    public EnumItem res_EnumItem;
    public FloatItem res_FloatItem;
    public IntegerItem res_IntegerItem;
    public LabelItem res_LabelItem;
    public StringItem res_StringItem;
    public GameObject res_TimeItem;

    /// <summary>
    /// 加载Arrays是否完成
    /// </summary>
    public bool isLoadFinish = false;

    public Dictionary<string, GameObject> allArraysGameObject = new Dictionary<string, GameObject>();
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        SettingStaticConfig.tempSettingData = (SettingsData)SettingStaticConfig.settingsData.DeepClone();
        Init();
    }
    void Start()
    {
        BindUI();
    }
    private void BindUI()
    {
        sureBtn.onClick.AddListener(() =>
        {
            //保存数据  删除子物体   关闭页面
            SettingStaticConfig.settingsData = (SettingsData)SettingStaticConfig.tempSettingData.DeepClone();
            XMLManager.SaveXmlData(SettingStaticConfig.settingsData);
            gameObject.SetActive(false);
        });
        cancelBtn.onClick.AddListener(() =>
        {
            OnHide();
        });
        closeBtn.onClick.AddListener((() =>
        {
            OnHide();
        }));
    }

    void OnHide()
    {
        SettingStaticConfig.tempSettingData = null;
        allArraysGameObject.Clear();
        gameObject.SetActive(false);
    }
    private void Init()
    {
        foreach (var arrays in SettingStaticConfig.tempSettingData.Arrays)
        {
            SettingTab settingTab = Instantiate(res_SettingTab, bodyContent);
            settingTab.Init(arrays);
            SettingStaticConfig.AllTabs.Add(settingTab);
        }
        SettingStaticConfig.AllTabs[0].thisToggle.isOn = true;
    }

    private void OnDisable()
    {
        DeleteChildren(bodyContent);
        DeleteChildren(arrayContent);
        SettingStaticConfig.AllTabs.Clear();
    }
    /// <summary>
    /// 清空子物体
    /// </summary>
    /// <param name="parent"></param>
    void DeleteChildren(Transform parent)
    {
        // 遍历所有子物体
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);

            // 销毁子物体
            Destroy(child.gameObject);
        }
    }
    public void LinksActive(List<string> links,bool isActive = true)
    {
        for (int i = 0; i < links.Count; i++)
        {
            if (allArraysGameObject.ContainsKey(links[i]))
            {
                allArraysGameObject[links[i]].SetActive(isActive);
            }
            else
            {
                Debug.LogError("集合中不包含"+links[i]);
            }
        }
    }

    public void CreateArrayBody(SettingsArrays settingsArrays)
    {
        // arrayContent.GetComponent<>()
        allArraysGameObject.Clear();
        isLoadFinish = false;
        DeleteChildren(arrayContent);
        descriptionText.text = settingsArrays.Name;
        foreach (var items in settingsArrays.Items)
        {
            allArraysGameObject.Add(items.Key,null);
            switch (items.Type)
            {
                case "bool":
                    BooleanControl booleanControl = Instantiate(res_BooleanItem, arrayContent);
                    booleanControl.Init(items);
                    allArraysGameObject[items.Key] = booleanControl.gameObject;
                    break;
                case "int":
                    IntegerItem integerItem = Instantiate(res_IntegerItem, arrayContent);
                    integerItem.Init(items);
                    allArraysGameObject[items.Key] = integerItem.gameObject;
                    break;
                case "float":
                    FloatItem floatItem = Instantiate(res_FloatItem, arrayContent);
                    floatItem.Init(items);
                    allArraysGameObject[items.Key] = floatItem.gameObject;
                    break;
                case "string":
                    StringItem stringItem = Instantiate(res_StringItem, arrayContent);
                    stringItem.Init(items);
                    allArraysGameObject[items.Key] = stringItem.gameObject;
                    break;
                case "enum":
                    EnumItem enumItem = Instantiate(res_EnumItem, arrayContent);
                    enumItem.Init(items);
                    allArraysGameObject[items.Key] = enumItem.gameObject;
                    break;
                case "label":
                    LabelItem labelItem = Instantiate(res_LabelItem, arrayContent);
                    labelItem.Init(items);
                    allArraysGameObject[items.Key] = labelItem.gameObject;
                    break;
                case "color":
                    ColorItem colorItem = Instantiate(res_ColorItem, arrayContent);
                    colorItem.Init(items);
                    allArraysGameObject[items.Key] = colorItem.gameObject;
                    break;
            }
        }
        isLoadFinish = true;
    }
}
