using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;
//using SimpleJSON;
//using Org.BouncyCastle.Asn1.Crmf;
//using Unity.Barracuda;
//using VoxelBusters.EssentialKit.GameServicesCore;
//using Photon.Pun.Demo.SlotRacer.Utils;
//using UnityEngine.SocialPlatforms.Impl;
using System.Text;
//using static Unity.Barracuda.Model;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UserManager : MonoBehaviour
{
    public const string PATH_MAIN = "https://fa-ecom.pams.ai/api/thebrain";//"http://192.168.1.16:8080";//

    public const string PATH_GET_PROFILE = PATH_MAIN + "/member/profile/";

    public const string PATH_REGISTER = PATH_MAIN + "/user/create/";
    public const string PATH_SCORE_ADD = PATH_MAIN + "/score/add";
    public const string PATH_SCORE_SPENT = PATH_MAIN + "/score/spent";

    public const string TOKEN_PRIVATE = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImZkYmJjNmU3LWQ5NmUtNGY0YS1iN2ZjLWFlZmY1MzBjYmUxMyIsInVzZXJfaWQiOiIyT3hNNWJIUXFNcFZzeW9YZVlJcVlwSDJDeXYiLCJleHAiOjE4NDMyMDE2MDV9.Qr954P7B3U3Ff8PWKXmTzGvWmFhpxeGvlz9IXprJaGc";

    public ResLogin ObjLoginClass;
    public ResRegister ObjRegisterClass;
    public ResInfo ObjResInfo;
    public ResUserProfile ObjResProfile;

    public static UserManager instance = null;
    public enum eStage
    {
        IDLE,
        WAITING,
        SUCCESS,
        ERROR
    };

    public enum eExportType
    {
        csv,
        json,
        xlsx
    };

    public enum eUserType
    {
        spu_student = 1,
        new_student,
        individual
    };

    public enum eGender
    {
        men = 1,
        women,
        NotSet
    }

    public enum eLoginMode 
    {
        NORMAL,
        GUEST,
        GOOGLE,
        FACEBOOK
    };

    public eStage Stage = eStage.IDLE;

    public eStage ChatStage = eStage.IDLE;

    public eLoginMode LoginMode;

    public string StrLastError = "";
    public ResError ObjResError;

    private void Awake()
    {
        vInit();
    }

    public void vInit()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //vGetProfile();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            
        }
		if (Input.GetKeyDown(KeyCode.P))
		{

        }
#endif
    }

    public void vGetProfile(string id)
    {
        //string id = PlayerPrefs.GetString("User_ID", DEFAULT_USER_ID);

        string path = PATH_GET_PROFILE + id;

        StartCoroutine(GetRequest(path,"","","", id));
    }

    public void vScoreAdd(int score, int game,string id = "")
    {

        ReqScoreAdd user = new ReqScoreAdd();
        user.user = new ReqUserScoreAdd();

        user.user.id = id;
        user.user.score = score;
        user.user.game = game;

        WWWForm form = new WWWForm();

        string json = JsonUtility.ToJson(user);

        Debug.Log("json = "+ json);

        //form.AddField("token", JWT.GetJwtUserClass(JsonUtility.ToJson(user)));

        StartCoroutine(PostRequest(PATH_SCORE_ADD, form, UserManager.instance.ObjLoginClass.token, json));
    }

    public void vScoreSpent(int reward_id)
    {

        ReqScoreSpent user = new ReqScoreSpent();
        user.user = new ReqUserScoreSpent();
        user.reward = new ReqRewardScoreSpent();

        user.reward.id = reward_id;

        WWWForm form = new WWWForm();

        //form.AddField("token", JWT.GetJwtUserClass(JsonUtility.ToJson(user)));

        string json = JsonUtility.ToJson(user);

        Debug.Log("json = "+json);

        StartCoroutine(PostRequest(PATH_SCORE_SPENT, form, UserManager.instance.ObjLoginClass.token, json));
    }


    IEnumerator GetRequest(string uri, string bearer = "", string json = "", string authHeader = "", string user_id = "")
    {
        Debug.Log("GetRequest, " + uri);

        Stage = eStage.WAITING;

        StrLastError = "";

        string urlWithParameters = $"{uri}?json={UnityWebRequest.EscapeURL(json)}";

        UnityWebRequest www = UnityWebRequest.Get(uri);//json.Length < 1 ? uri : urlWithParameters);

        if (user_id.Length > 1)
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Access-Control-Allow-Origin", "*");
            www.SetRequestHeader("Authorization", TOKEN_PRIVATE);
            www.SetRequestHeader("x-timestamp", "2020-04-15 07:00:00");
            www.SetRequestHeader("Content-Type", "application/json");
        }

    //if (authHeader.Length > 1)
    //{
    //    www.SetRequestHeader("Authorization", authHeader);
    //}

    //if (bearer.Length > 1)
    //{
    //    www.SetRequestHeader("Authorization", "Bearer " + bearer);
    //}

    yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(uri + " = " + www.error + "," + www.downloadHandler.text);
            Stage = eStage.ERROR;
            if (www.error.Contains("Not Found") ||
                www.error.Contains("Timeout") ||
                www.error.Contains("Bad Request") ||
                www.error.Contains("Unknown Error") ||
                www.error.Contains("Unknown HTTP") ||
                www.error.Contains("SSL CA") ||
                www.error.Contains("Request timeout") || 
                www.error.Contains("Cannot resolve"))
                StrLastError = www.error;
            else if (www.error.Contains("Forbidden") ||
                www.error.Contains("Unauthorized"))
            {
                StrLastError = www.downloadHandler.text;
            }
            else 
            {
                ObjResError = ResError.CreateFromJSON(www.downloadHandler.text);
                if (ObjResError.message != null)
                    StrLastError = ObjResError.message;
                else
                    StrLastError = www.downloadHandler.text;
            }
            //StrLastError = uri + " = " + www.error+","+ www.isNetworkError+","+www.isHttpError;
        }
        else
        {
            string jsonData = www.downloadHandler.text;

            if (www.responseCode == 200)
            {
                Stage = eStage.SUCCESS;

                Debug.Log("done, " + uri + " = " + jsonData);

                Debug.Log(jsonData);

                if(uri.Contains(PATH_GET_PROFILE))
                {
                    ObjResProfile = ResUserProfile.CreateFromJSON(jsonData);

                    if (ObjResInfo.status_code != 200 && ObjResInfo.status_code != 401 && ObjResInfo.status_code != 402)
                    {
                        Stage = eStage.ERROR;
                        StrLastError = ObjResInfo.message;
                    }
                }
            }
            else
            {
                Stage = eStage.ERROR;
                StrLastError = jsonData;
            }

            Debug.Log("done, " + uri + " = " + jsonData);
        }
    }

    IEnumerator PostRequest(string uri, WWWForm form, string bearer = "", string json = "", string authHeader = "")
    {
        Debug.Log("PostRequest = " + uri);

        Stage = eStage.WAITING;

        StrLastError = "";

        UnityWebRequest www;// = UnityWebRequest.Post(uri, form);

        if (json == "")
            www = UnityWebRequest.Post(uri, form);
        else
            www = new UnityWebRequest(uri, "POST");

        www.SetRequestHeader("Access-Control-Allow-Origin", "*");

        if (json.Length > 1)
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
        }

        //if (authHeader.Length > 1)
        //{
        //    www.SetRequestHeader("Authorization", authHeader);
        //}

        //if (bearer.Length > 1)
        //{
        //    www.SetRequestHeader("Authorization", "Bearer " + bearer);
        //}

        yield return www.SendWebRequest();
        
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("error, "+uri + " = " +www.error+","+ www.downloadHandler.text);
            Stage = eStage.ERROR;

            if (www.error.Contains("Not Found") || 
                www.error.Contains("Timeout") ||
                www.error.Contains("Bad Request") || 
                www.error.Contains("Unknown") ||
                www.error.Contains("Request timeout") ||
                www.error.Contains("verification failed") ||
                www.error.Contains("Unauthorized"))
                StrLastError = www.error;
            else
            {
                ObjResError = ResError.CreateFromJSON(www.downloadHandler.text);
                StrLastError = ObjResError.message;
            }
        }
        else
        {
            string jsonData = www.downloadHandler.text;

            Debug.Log("done 1, " + uri + " = " + www.downloadHandler.text);

            if (www.responseCode == 200)
            {
                Stage = eStage.SUCCESS;

                if (uri.Contains(PATH_REGISTER))
                {
                    Debug.Log(" = " + jsonData);

                    ObjRegisterClass = ResRegister.CreateFromJSON(jsonData);

                    if (ObjRegisterClass.status_code != 200)
                    {
                        Stage = eStage.ERROR;
                        StrLastError = ObjRegisterClass.message;
                    }
                }
            }
            else
                Stage = eStage.ERROR;

            Debug.Log("done, "+uri+" = " + www.downloadHandler.text);
        }
    }

    IEnumerator PutRequest(string uri, string strData, byte[] byteData = null)
    {
        Debug.Log("PutRequest = " + uri+","+ strData);

        StrLastError = "";

        Stage = eStage.WAITING;

        UnityWebRequest www = null;
        if(strData.Length > 0)
            www = UnityWebRequest.Put(uri, strData);
        else
            www = UnityWebRequest.Put(uri, byteData);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("error, " + uri + " = " + www.error + "," + www.downloadHandler.text+","+ www.url);
            Stage = eStage.ERROR;
            if (www.error.Contains("Timeout") || www.error.Contains("Not Found"))
                StrLastError = www.error;
            else
            {
                ObjResError = ResError.CreateFromJSON(www.downloadHandler.text);
                StrLastError = ObjResError.message;
            }
        }
        else
        {
            string jsonData = www.downloadHandler.text;

            Debug.Log("done 1, " + uri + " = " + www.downloadHandler.text);

            if (www.responseCode == 200)
            {
                Stage = eStage.SUCCESS;
            }
            else
                Stage = eStage.ERROR;

            Debug.Log("done, " + uri + " = " + www.downloadHandler.text);
        }
    }
}
