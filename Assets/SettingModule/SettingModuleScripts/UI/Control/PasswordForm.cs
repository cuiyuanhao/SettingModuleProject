using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordForm : MonoBehaviour
{
    /// <summary>
    /// 密码输入框
    /// </summary>
    private InputField passwordInputField;
    /// <summary>
    /// 按钮父物体
    /// </summary>
    private GameObject btnParent;
    /// <summary>
    /// 动画
    /// </summary>
    private Animator anim;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    private Button closeBtn;
    /// <summary>
    /// 密码临时框
    /// </summary>
    private string passWordText;
    // Start is called before the first frame update
    void Start()
    {
        BuidUI();
    }

    private void OnClick(Button btnTemp)
    {
        switch (btnTemp.name)
        {
            case "清除":
                PassWordClear();
                break;
            case "关闭":
                OnHide();
                break;
            default:
                CheckInput(btnTemp.name);
                break;
        }
    }
    private void OnHide()
    {
        passwordInputField.placeholder.GetComponent<Text>().text = "请输入4位数密码";
        PassWordClear();
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 清空输入框
    /// </summary>
    private void PassWordClear()
    {
        passwordInputField.text = "";
        passWordText = "";
    }
    /// <summary>
    /// 绑定UI
    /// </summary>
    private void BuidUI()
    {
        passwordInputField = transform.Find("Frame/Body/InputField").GetComponent<InputField>();
        btnParent = transform.Find("Frame/Body/Grid").gameObject;
        closeBtn = transform.Find("Frame/Title/Close").GetComponent<Button>();
        closeBtn.onClick.AddListener(OnHide);
        Button[] btns = btnParent.GetComponentsInChildren<Button>();
        for (int i = 0; i < btns.Length; i++)
        {
            var btnTemp = btns[i];
            btns[i].onClick.AddListener(() =>
            {
                OnClick(btnTemp);
            });
        }
    }
    /// <summary>
    /// 检查输入
    /// </summary>
    /// <param name="input"></param>
    void CheckInput(string input)
    {
        passWordText += input;
        passwordInputField.text = passWordText;
        if (passWordText.Length == 4 && passWordText != UserConfig.PassWord)
        {
            passwordInputField.placeholder.GetComponent<Text>().text = "密码错误，请重新输入";
            PassWordClear();
        }
        else
        {
            if (passWordText == UserConfig.PassWord)
            {
                SettingParentPanel.Instance.menuForm.gameObject.SetActive(true);
                OnHide();
            }
        }



    }
    void Update()
    {
        // 检查主键盘上的数字键
        CheckNumberInput(KeyCode.Alpha0, KeyCode.Alpha9);
        // 检查小键盘上的数字键
        CheckNumberInput(KeyCode.Keypad0, KeyCode.Keypad9);
    }
    /// <summary>
    /// 最小键  最大键
    /// </summary>
    /// <param name="minKey"></param>
    /// <param name="maxKey"></param>
    void CheckNumberInput(KeyCode minKey, KeyCode maxKey)
    {
        for (KeyCode key = minKey; key <= maxKey; key++)
        {
            if (Input.GetKeyDown(key))
            {
                // 获取键码对应的数字字符并添加到输入字符串中
                char digit = key.ToString()[key.ToString().Length - 1];
                CheckInput(digit.ToString());
                // 在这里你可以进行其他操作，比如显示输入的数字
                Debug.Log("Input Text: " +  passwordInputField.text);
                break; // 可选，如果你只想捕捉一个数字键
            }
        }
    }
}
