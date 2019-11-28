
using System;
using System.Text.RegularExpressions;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public GameObject LoginView;
    public InputField UsernameTextBox;
    public InputField PasswordTextBox;
    public Button LoginButton;
    public Button CreateAccount;
    public Button ForgotPassword;

    public InputField MiscTextBox1;
    public InputField MiscTextBox2;
    public Text ErrorText;
    public Button CancelButton;

    private String AssetPath;
    private String PageStatus;
    private Regex re_date = new Regex(@"\d\d\/\d\d\/\d\d\d\d");

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(LoginOnClick);
        CreateAccount.onClick.AddListener(CreateOnClick);
        ForgotPassword.onClick.AddListener(ForgotOnClick);
        CancelButton.onClick.AddListener(CancelOnClick);
        AssetPath = Application.dataPath;
        PageStatus = "L";
        Debug.Log("Start sequence finished ...");
        Debug.Log(AssetPath);
    }

    void LoginOnClick()
    {

        Debug.Log("Login Clicked ...");
        Debug.Log("Page Status " + PageStatus);

        if (PageStatus == "L")
        {
            string username = UsernameTextBox.text;
            string password = PasswordTextBox.text;
            String output = RunPython(username, password, PageStatus, "");

            if (output == "True")
            {
                LoginView.SetActive(false);
            }
            else
            {
                UsernameTextBox.text = "";
                PasswordTextBox.text = "";
                ErrorText.text = output;
            }
        }
        else if (PageStatus == "C")
        {
            String username = UsernameTextBox.text;
            String password = PasswordTextBox.text;
            String confirm = MiscTextBox1.text;
            String dob = MiscTextBox2.text;

            if (username.Length >= 8)
            {
                if (password == confirm)
                {
                    Match dob_match = re_date.Match(dob);
                    if (dob_match.Success)
                    {
                        String output = RunPython(username, password, PageStatus, dob);
                        if (output == "True")
                        {
                            LoginView.SetActive(false);
                        }
                        else
                        {
                            UsernameTextBox.text = "";
                            PasswordTextBox.text = "";
                            MiscTextBox1.text = "";
                            MiscTextBox2.text = "";
                            ErrorText.text = output;
                        }
                    }
                }
            }
        }
        else if (PageStatus == "F")
        {
            String username = UsernameTextBox.text;
            String password = PasswordTextBox.text;
            String confirm = MiscTextBox1.text;
            String dob = MiscTextBox2.text;

            Match dob_match = re_date.Match(dob);
            if (dob_match.Success)
            {
                if (password == confirm)
                {
                    String output = RunPython(username, password, PageStatus, dob);
                    if (output == "True")
                    {
                        LoginView.SetActive(false);
                    }
                    else
                    {
                        UsernameTextBox.text = "";
                        PasswordTextBox.text = "";
                        MiscTextBox1.text = "";
                        MiscTextBox2.text = "";
                        ErrorText.text = output;
                    }
                }
            }
        }

    } //end void LoginOnClick

    void CreateOnClick()
    {
        if (PageStatus != "C")
        {
            PageStatus = "C";
            StateChange();
        }

        Debug.Log("Create Clicked ...");
    }

    void ForgotOnClick()
    {
        if (PageStatus != "F")
        {
            PageStatus = "F";
            StateChange();
        }

        Debug.Log("Forgot Clicked ...");
    }

    void CancelOnClick()
    {
        PageStatus = "L";
        StateChange();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StateChange()
    {
        if (PageStatus == "L")
        {
            UsernameTextBox.gameObject.SetActive(true);
            UsernameTextBox.text = "";
            UsernameTextBox.placeholder.GetComponent<Text>().text = "Enter your username here ...";
            PasswordTextBox.gameObject.SetActive(true);
            PasswordTextBox.text = "";
            PasswordTextBox.placeholder.GetComponent<Text>().text = "Enter your password here ...";
            PasswordTextBox.contentType = InputField.ContentType.Password;

            Vector3 pos = LoginButton.GetComponent<RectTransform>().anchoredPosition;
            pos.y = -110;
            LoginButton.GetComponent<RectTransform>().anchoredPosition = pos;
            LoginButton.GetComponentInChildren<Text>().text = "Login";
            MiscTextBox1.gameObject.SetActive(false);
            MiscTextBox2.gameObject.SetActive(false);
            CreateAccount.gameObject.SetActive(true);
            ForgotPassword.gameObject.SetActive(true);
            CancelButton.gameObject.SetActive(false);
        }
        else if (PageStatus == "C")
        {
            UsernameTextBox.gameObject.SetActive(true);
            UsernameTextBox.text = "";
            UsernameTextBox.placeholder.GetComponent<Text>().text = "Enter your username here ...";
            PasswordTextBox.gameObject.SetActive(true);
            PasswordTextBox.text = "";
            PasswordTextBox.placeholder.GetComponent<Text>().text = "Enter your password here ...";
            PasswordTextBox.contentType = InputField.ContentType.Password;

            Vector3 pos = LoginButton.GetComponent<RectTransform>().anchoredPosition;
            pos.y = -190;
            LoginButton.GetComponent<RectTransform>().anchoredPosition = pos;
            LoginButton.GetComponentInChildren<Text>().text = "Create Account";
            MiscTextBox1.gameObject.SetActive(true);
            MiscTextBox1.text = "";
            MiscTextBox1.placeholder.GetComponent<Text>().text = "Confirm your password here ...";
            MiscTextBox1.contentType = InputField.ContentType.Password;
            MiscTextBox2.gameObject.SetActive(true);
            MiscTextBox2.text = "";
            MiscTextBox2.placeholder.GetComponent<Text>().text = "Enter your date of birth, eg. MM/DD/YYYY ...";
            CreateAccount.gameObject.SetActive(false);
            ForgotPassword.gameObject.SetActive(false);
            CancelButton.gameObject.SetActive(true);
        }
        else if (PageStatus == "F")
        {
            UsernameTextBox.gameObject.SetActive(true);
            UsernameTextBox.text = "";
            UsernameTextBox.placeholder.GetComponent<Text>().text = "Enter your username here ...";
            PasswordTextBox.gameObject.SetActive(true);
            PasswordTextBox.text = "";
            PasswordTextBox.placeholder.GetComponent<Text>().text = "Enter your new password here ...";
            PasswordTextBox.contentType = InputField.ContentType.Password;

            Vector3 pos = LoginButton.GetComponent<RectTransform>().anchoredPosition;
            pos.y = -190;
            LoginButton.GetComponent<RectTransform>().anchoredPosition = pos;
            LoginButton.GetComponentInChildren<Text>().text = "Reset Password";
            MiscTextBox1.gameObject.SetActive(true);
            MiscTextBox1.text = "";
            MiscTextBox1.placeholder.GetComponent<Text>().text = "Confirm your new password here ...";
            MiscTextBox1.contentType = InputField.ContentType.Password;
            MiscTextBox2.gameObject.SetActive(true);
            MiscTextBox2.text = "";
            MiscTextBox2.placeholder.GetComponent<Text>().text = "Enter your date of birth, eg. MM/DD/YYYY ...";
            CreateAccount.gameObject.SetActive(false);
            ForgotPassword.gameObject.SetActive(false);
            CancelButton.gameObject.SetActive(true);
        }
    }

    String RunPython(String username, String password, String action, String dob)
    {

        //TRY COMMAND LINE ARGUMENT LIKE PYTHON FILENAME ARGS WITH PYTHON AS THE FILENAME

        var process = new System.Diagnostics.Process();
        //process.StartInfo.FileName = "/Applications/Utilities/Terminal.app";
        //process.StartInfo.FileName = "/Applications/Google Chrome.app";
        //process.StartInfo.FileName = "/usr/bin/python";
        process.StartInfo.FileName = AssetPath + "/Resources/Python.app/Contents/MacOS/Python";
        //process.StartInfo.FileName = AssetPath + "/Resources/Python\\ Launcher";

        //process.StartInfo.FileName = "Chrome.app";
        //process.StartInfo.Arguments = "-a python";// /Users/jasonmerrick2/Desktop/NLTK/nltk_cfg_test.py";
        //process.StartInfo.Arguments = "http://www.google.com";
        //process.StartInfo.Arguments = "http://www.vcu.edu";

        //process.StartInfo.FileName = AssetPath + "/Scripts/LoginUtils.py";
        //process.StartInfo.Arguments = username + " " + password + " " + action + " " + dob;
        process.StartInfo.Arguments = "python " + AssetPath + "/LoginUtils.py " + username + " " + password + " " + action + " " + dob;
        Debug.Log(process.StartInfo.Arguments);
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        Debug.Log("Python Script Finished ...");
        Debug.Log(output);
        return output;
    }


}
