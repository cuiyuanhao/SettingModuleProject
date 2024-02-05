using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using UnityEngine;

public class XMLParser : MonoBehaviour
{
    private SettingsData settingsData;
    void Awake()
    {
        XMLManager.filePath = Application.streamingAssetsPath + "/SettingConfig.xml";
        SettingStaticConfig.settingsData = XMLManager.ReadXmlData();
        // ReadXmlData(filePath);
    }
}