using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class ScLogin : MonoBehaviour
{
    UserManager usermanager;

    public string userid;
    public int m_coin;
    public Text txtname;
    public Text txtcoin;

    void Start()
    {
        usermanager =  GameObject.FindObjectOfType<UserManager>();

#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
#endif
    }

    void Update()
    {
        if(userid == null)
        {
            //userid = PlayerPrefs.GetString("User_ID", userid);
            userid = "2OxFie7l6GOiUQM3uhXjnH1y5Zz";
        }

        if (usermanager.ObjResProfile.firstname == null)
        {
            txtname.text = usermanager.ObjResProfile.firstname + " " + usermanager.ObjResProfile.lastname;
            m_coin = usermanager.ObjResProfile.coin;
            txtcoin.text = usermanager.ObjResProfile.coin.ToString();
        }
    }

    public void GetProfile()
    {
        usermanager.vGetProfile(userid);
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ShowMessage(string message);
#endif

    public InputField TextInput;
    public Text DisplayText;

    public void SendToJS()
    {
        string MessageToSend = TextInput.text;
        Debug.Log("Sending message to JavaScript: " + MessageToSend);
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowMessage(MessageToSend);
#endif
    }

    public void SendToUnity(string message)
    {
        DisplayText.text = message;
        userid = message;
    }
}
