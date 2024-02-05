using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
/// <summary>
/// xml数据类
/// </summary>
[XmlRoot("settings")]
[Serializable]
public class SettingsData
{
    /// <summary>
    /// 左侧Table页
    /// </summary>
    [XmlElement("array")]
    public List<SettingsArrays> Arrays { get; set; }
    public object DeepClone()
    {
        using (Stream objectStream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream, this);
            objectStream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(objectStream) as SettingsData;
        }
    }
}
[Serializable]
public class SettingsArrays
{
    /// <summary>
    /// 左侧Table页名称
    /// </summary>
    [XmlAttribute("name")]
    public string Name { get; set; }
    /// <summary>
    ///UI名称  =-= 不能重命名
    /// </summary>
    [XmlAttribute("key")]
    public string Key { get; set; }
    /// <summary>
    /// 备注文本
    /// </summary>
    [XmlAttribute("description")]
    public string Description { get; set; }
    [XmlElement("item")]
    public List<SettingsItem> Items { get; set; }
}
[Serializable]
public class SettingsItem
{
    /// <summary>
    /// 设置的类型     int为数字输入框   enum为下拉菜单   bool为单选框   lable为大文本隔断   color为颜色选择器   string为文本输入框
    /// </summary>
    [XmlAttribute("type")]
    public string Type { get; set; }
    /// <summary>
    /// ui名称
    /// </summary>
    [XmlAttribute("key")]
    public string Key { get; set; }
    /// <summary>
    /// 中文文本用于显示在UI上的
    /// </summary>
    [XmlAttribute("name")]
    public string Name { get; set; }
    /// <summary>
    /// 备注文本
    /// </summary>
    [XmlAttribute("description")]
    public string Description { get; set; }
    /// <summary>
    /// 表示当前输入框输入类型
    /// </summary>
    [XmlAttribute("unit")]
    public string Unit { get; set; }
    /// <summary>
    /// 输入框的最小值
    /// </summary>
    [XmlAttribute("min")]
    public string Min { get; set; }
    /// <summary>
    /// 输入框的最大值
    /// </summary>
    [XmlAttribute("max")]
    public string Max { get; set; }
    /// <summary>
    ///输入框为数字时，每次增量的数值
    /// </summary>
    [XmlAttribute("increment")]
    public string Increment { get; set; }
    /// <summary>
    /// 颜色默认值
    /// </summary>
    [XmlAttribute("default")]
    public string Default { get; set; }
    /// <summary>
    ///下拉列表 当前值也为默认值
    /// </summary>
    [XmlAttribute("value")]
    public string Value { get; set; }
    /// <summary>
    /// UI是否关闭
    /// </summary>
    [XmlAttribute("hide")]
    public string Hide { get; set; }
    /// <summary>
    /// 值
    /// </summary>
    [XmlText]
    public string ValueText { get; set; }
    /// <summary>
    /// 字符串最大程度
    /// </summary>
    [XmlAttribute("maxlength")]
    public string MaxLength { get; set; }
    /// <summary>
    /// 下拉列表的数据
    /// </summary>
    [XmlElement("option")]
    public List<SettingsOption> Options { get; set; }
    /// <summary>
    /// 关联的UI名称  用于显隐
    /// </summary>
    [XmlAttribute("links")]
    public string Links { get; set; }
}
[Serializable]
public class SettingsOption
{
    /// <summary>
    /// ui名称
    /// </summary>
    [XmlAttribute("key")]
    public string Key { get; set; }
    /// <summary>
    /// 关联的UI名称    ‘，’分割
    /// </summary>
    [XmlAttribute("links")]
    public string Links { get; set; }
    /// <summary>
    /// 用于显示的文本
    /// </summary>
    [XmlText]
    public string Text { get; set; }
}
[Serializable]
public class SettingsLink
{
    /// <summary>
    /// ui名称
    /// </summary>
    [XmlAttribute("key")]
    public string Key { get; set; }
}