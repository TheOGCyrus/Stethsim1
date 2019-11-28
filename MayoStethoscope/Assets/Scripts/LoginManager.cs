
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
        if (PageStatus != "L")
        {
            PageStatus = "L";
            StateChange();
        }

        Debug.Log("Login Clicked ...");

        string username = UsernameTextBox.text;
        string password = PasswordTextBox.text;

        String output = RunPython(username, password, PageStatus, "06/04/1999");
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

    void CreateOnClick()
    {
        if (PageStatus != "C")
        {
            PageStatus = "C";
            StateChange();
        }

        Debug.Log("Create Clicked ...");

        while (true)
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
                        RunPython(username, password, "C", dob);
                        return;
                    }
                }
            }

        }
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
            MiscTextBox1.gameObject.SetActive(false);
            MiscTextBox2.gameObject.SetActive(false);
            CreateAccount.gameObject.SetActive(true);
            ForgotPassword.gameObject.SetActive(true);
            //LoginButton.transform.position.x = -110;
            //MiscTextBox1.SetActive(false);
            //MiscTextBox2.SetActive(false);
            //CreateAccount.SetActive(true);
            //ForgotPassword.SetActive(true);
            //LoginButton.transform.position.x = -110;
        }
        else if (PageStatus == "C")
        {
            MiscTextBox1.gameObject.SetActive(true);
            //MiscTextBox1.placeholder.text = "Reenter your password here ...";
            MiscTextBox2.gameObject.SetActive(true);
            //MiscTextBox2.placeholder.text = "Enter your date of birth, eg. MM/DD/YYYY ...";
            CreateAccount.gameObject.SetActive(false);
            ForgotPassword.gameObject.SetActive(false);
            //LoginButton.transform.position.x = -190;
            CancelButton.gameObject.SetActive(true);
            //MiscTextBox1.SetActive(true);
            //MiscTextBox1.placeholder.text = "Reenter your password here ...";
            //MiscTextBox2.SetActive(true);
            //MiscTextBox2.placeholder.text = "Enter your date of birth, eg. MM/DD/YYYY ...";
            //CreateAccount.SetActive(false);
            //ForgotPassword.SetActive(false);
            //LoginButton.transform.position.x = -190;
            //CancelButton.SetActive(true);
        }
        else if (PageStatus == "F")
        {
            //UsernameTextBox.placeholder.text = "Enter your date of birth, eg. MM/DD/YYYY ...";
            PasswordTextBox.gameObject.SetActive(false);
            CreateAccount.gameObject.SetActive(false);
            ForgotPassword.gameObject.SetActive(false);
            CancelButton.gameObject.SetActive(true);
            //UsernameTextBox.placeholder.text = "Enter your date of birth, eg. MM/DD/YYYY ...";
            //PasswordTextBox.SetActive(false);
            //CreateAccount.SetActive(false);
            //ForgotPassword.SetActive(false);
            //CancelButton.SetActive(true);
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
