using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField UsernameTextBox;
    public InputField PasswordTextBox;
    public Button LoginButton;
    public Button CreateAccount;
    public Button ForgotPassword;

    public InputField MiscTextBox1;
    public InputField MiscTextBox2;

    // Start is called before the first frame update

    void Start()
    {
        LoginButton.onClick.AddListener(LoginOnClick);
        CreateAccount.onClick.AddListener(CreateOnClick);
        ForgotPassword.onClick.AddListener(ForgotOnClick);
    }

    void LoginOnClick()
    {
        string username = UsernameTextBox.text;
        string password = PasswordTextBox.text;
        //int x = 1;
        //int y = 2;
        string progToRun = "LoginUtils.py";
        char[] splitter = { '\r' };

        Process python = new Process();
        //python.StartInfo.FileName = "python.exe";
        python.StartInfo.FileName = "/Library/Frameworks/Python.framework/Versions/3.7/bin/python3.7";
        python.StartInfo.RedirectStandardOutput = true;
        python.StartInfo.UseShellExecute = false;

        // call hello.py to concatenate passed parameters
        python.StartInfo.Arguments = string.Concat(progToRun, " ", username, " ", password, " ", "L");
        python.Start();
        Console.WriteLine("HERE");

        StreamReader sReader = python.StandardOutput;
        string[] output = sReader.ReadToEnd().Split(splitter);

        foreach (string s in output)
            Console.WriteLine(s);

        python.WaitForExit();

        Console.ReadLine();
    }

    void CreateOnClick()
    {

    }

    void ForgotOnClick()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
