using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GetApiData : MonoBehaviour
{
    // Start is called before the first frame update
    public string url = "https://reqres.in/api/users/2";
    public TextMeshProUGUI id;
    public TextMeshProUGUI email;
    public TextMeshProUGUI firstName;
    public TextMeshProUGUI lastName;

    [ContextMenu("Get")]
    public void GetData()
    {
        // A correct website page.
        StartCoroutine(GetRequest(url));

        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.responseCode == 200)
            {
                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                        string jsonString = webRequest.downloadHandler.text;
                        UserStatus userStatus = JsonUtility.FromJson<UserStatus>(jsonString);
                        Debug.Log(userStatus.data.first_name);

                        email.text = userStatus.data.email;
                        firstName.text = userStatus.data.first_name;
                        lastName.text = userStatus.data.last_name;
                        id.text = userStatus.data.id.ToString();

                        break;
                }

            }
        }

    }
}
