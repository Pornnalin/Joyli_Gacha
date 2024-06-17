using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserStatus
{
    //public string firstName;
    //public int coin;   
    //public string member_point;   
    //public string member_id;   
    //public string mobile;   

    //public int id;
    //public string email;
    //public string firstName;
    //public string lastName;
    public Data data;
    public Support support;
}
[System.Serializable]
public class Data
{
    public int id;
    public string email;
    public string first_name;
    public string last_name;

}
[System.Serializable]
public class Support
{
    public string url;
    public string text;
   
}

