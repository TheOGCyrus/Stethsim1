using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField UsernameTextBox;
    public InputField PasswordTextBox;
    public Button LoginButton;
    public GameObject CreateAccount;
    public GameObject ForgotPassword;

    // Start is called before the first frame update

    void Start()
    {
        LoginButton.onClick.AddListener(LoginOnClick);
    }

    void LoginOnClick()
    {
        string username = UsernameTextBox.text;
        string password = PasswordTextBox.text;
        //int x = 1;
        //int y = 2;
        string progToRun = "LoginUtils.py";
        //char[] spliter = { '\r' };

        Process python = new Process();
        python.StartInfo.FileName = "python.exe";
        python.StartInfo.RedirectStandardOutput = true;
        python.StartInfo.UseShellExecute = false;

        // call hello.py to concatenate passed parameters
        python.StartInfo.Arguments = string.Concat(progToRun, " ", x.ToString(), " ", y.ToString());
        python.Start();

        StreamReader sReader = python.StandardOutput;
        string[] output = sReader.ReadToEnd().Split(splitter);

        foreach (string s in output)
            Console.WriteLine(s);

        python.WaitForExit();

        Console.ReadLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
