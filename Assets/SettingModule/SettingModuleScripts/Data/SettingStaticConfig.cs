using System.Collections.Generic;

public class SettingStaticConfig
{
    /// <summary>
    /// 数据正房
    /// </summary>
    public static SettingsData settingsData;
    /// <summary>
    /// 临时存放数据的地方。  如果在设置界面点确定的话 就赋值给正房。  点取消或者关闭的话就不要了
    /// </summary>
    public static SettingsData tempSettingData;
    /// <summary>
    /// 存放标签
    /// </summary>
    public static List<SettingTab> AllTabs = new List<SettingTab>();

}
