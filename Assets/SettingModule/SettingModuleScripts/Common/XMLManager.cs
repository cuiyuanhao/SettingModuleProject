using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class XMLManager
{
    private static SettingsData settingsData;
    public static string filePath;
    public static SettingsData ReadXmlData()
    {
        if (File.Exists(filePath))
        {
            string xmlData = File.ReadAllText(filePath);
            settingsData = DeserializeSettingsData(xmlData);
            PrintSettingsData(settingsData);
            return settingsData;
        }
        else
        {
            Debug.LogError("XML file not found in File folder.");
        }

        return null;
    }

    public static void SaveXmlData(SettingsData settingsData)
    {
        // 创建XML序列化器
        XmlSerializer serializer = new XmlSerializer(typeof(SettingsData));
        // 创建文件流
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            // 使用序列化器将数据写入文件
            serializer.Serialize(stream, settingsData);
        }

        PrintSettingsData(settingsData);
    }
    private static SettingsData DeserializeSettingsData(string xmlData)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SettingsData));
        using (StringReader reader = new StringReader(xmlData))
        {
            return (SettingsData)serializer.Deserialize(reader);
        }
    }

    private static void PrintSettingsData(SettingsData settingsData)
    {
        Debug.LogError(settingsData.Arrays.Count);
        foreach (var settingsArray in settingsData.Arrays)
        {
            foreach (var settingsItem in settingsArray.Items)
            {
                GetItemType(settingsItem);
                // if (settingsItem.Options != null)
                // {
                //     // foreach (var option in settingsItem.Options)
                //     // {
                //     //     //Debug.Log($"    Option Key: {option.Key}, Links: {option.Links}, Text: {option.Text}");
                //     // }
                // }
                // if (settingsItem.Links != null)
                // {
                //     foreach (var link in settingsItem.Links)
                //     {
                //         //Debug.Log($"    Link Key: {link}");
                //     }
                // }
            }
        }
    }

     private static void GetItemType(SettingsItem settingsItem)
    {
        switch (settingsItem.Type)
        {
            case "enum":
                break;
            default:
                // 要检查的静态类名
                string className = "UserConfig";
                // 要检查的静态字段名
                string value = settingsItem.Key;
                // 使用反射获取静态类的类型
                Type type = Type.GetType(className);
                if (type != null)
                {
                    // 使用 GetField 方法检查类中是否包含指定的静态字段
                    FieldInfo fieldInfo = type.GetField(value, BindingFlags.Public | BindingFlags.Static);

                    if (fieldInfo != null)
                    {
                        // 获取字段的类型
                        Type fieldType = fieldInfo.FieldType;

                        // 根据字段的类型处理赋值逻辑
                        // 给静态字段赋值
                        if (fieldType == typeof(string))
                        {
                            fieldInfo.SetValue(null, settingsItem.ValueText);
                        }
                        else if (fieldType == typeof(int))
                        {
                            fieldInfo.SetValue(null, int.Parse(settingsItem.ValueText));
                        }
                        else if (fieldType == typeof(float))
                        {
                            fieldInfo.SetValue(null, float.Parse(settingsItem.ValueText));
                        }
                        else if (fieldType == typeof(bool))
                        {
                            fieldInfo.SetValue(null, bool.Parse(settingsItem.ValueText));
                        }
                        Console.WriteLine($"成功给静态字段 {value} 赋值。新的值为: { settingsItem.ValueText}");
                    }
                    else
                    {
                        Console.WriteLine($"静态类 {className} 中不包含字段 {value}。");
                    }
                }
                else
                {
                    Console.WriteLine($"找不到静态类 {className}。");
                }
                break;
        }
    }
}
