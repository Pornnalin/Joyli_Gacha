
using JetBrains.Annotations;
using UnityEngine;


[System.Serializable]
public class UserClass
{
    public ReqUser user;

    public static UserClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<UserClass>(jsonString);
	}
}

[System.Serializable]
public class ReqRegister
{
	public ReqUser user;

	public static ReqRegister CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqRegister>(jsonString);
	}
}

[System.Serializable]
public class ResRegister
{
	public int status_code;
	public string message;
    public string token;

    public static ResRegister CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResRegister>(jsonString);
	}
}

[System.Serializable]
public class ResLogin
{
	public int status_code;
	public string message;
	public string token;

	public static ResLogin CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResLogin>(jsonString);
	}
}

[System.Serializable]
public class ResGuestLogin
{
    public int status_code;
    public string message;

    public static ResGuestLogin CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ResGuestLogin>(jsonString);
    }
}

[System.Serializable]
public class ReqNewUser
{
	public ReqUser user;
	//public ReqPet pet;

	public static ReqNewUser CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqNewUser>(jsonString);
	}
}


[System.Serializable]
public class ReqUser
{
	public string id;
	public string email;

	public static ReqUser CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqUser>(jsonString);
	}
}

[System.Serializable]
public class ResMainCreateUser
{
	public int status_code;
	public string message;
	public string token;

	public static ResMainCreateUser CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResMainCreateUser>(jsonString);
	}
}


[System.Serializable]
public class ResFaculties
{
	public Faculties[] facultieslists;

	public static ResFaculties CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResFaculties>(jsonString);
	}
}

[System.Serializable]
public class Faculties
{
	public int id;
	public string name;
}

[System.Serializable]
public class ResError
{
	public string status_code;
	public string message;

	public static ResError CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResError>(jsonString);
	}
}

[System.Serializable]
public class ResErrorSignUp
{
	public int code;
	public string message;

	public ResErrorSignUp1 error;

	public static ResErrorSignUp CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResErrorSignUp>(jsonString);
	}
}

[System.Serializable]
public class ResErrorSignUp1
{
	public string message;
	public string domain;
	public string reason;

}

[System.Serializable]
public class NewUserRegister
{
	public string email;
	public string password;
	public bool returnSecureToken;
}

[System.Serializable]
public class ResSetup
{
	public int status_code;
	public string message;

	public static ResSetup CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResSetup>(jsonString);
	}
}

[System.Serializable]
public class ResInfo
{
	public int status_code;
	public string message;
	public ResUserInfo user;

	public static ResInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResInfo>(jsonString);
	}
}

[System.Serializable]
public class ResProfile
{
	public int status_code;
	public string message;
	public ResUserProfile user;

	public static ResProfile CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResProfile>(jsonString);
	}
}


[System.Serializable]
public class ResActivityLikeAll
{
    public int status_code;
    public string message;
    public ResActivityLikeAllContent[] data;

    public static ResActivityLikeAll CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ResActivityLikeAll>(jsonString);
    }
}

[System.Serializable]
public class ResActivityLikeAllContent
{
    public int id;
    public string title;
	public string description;
    public string image_url;
    public int like;
}

[System.Serializable]
public class ReqActivityLike
{
    public ReqActivityLikeUser user;
    public ReqActivityLikeContent content;

    public static ReqActivityLike CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ReqActivityLike>(jsonString);
    }
}

[System.Serializable]
public class ReqActivityLikeUser
{
    public string id;
}

[System.Serializable]
public class ReqActivityLikeContent
{
    public int id;
    public bool like;
}

[System.Serializable]
public class ResActivityLike
{
    public int status_code;
    public string message;

    public ResActivityLikeUser user;

    public static ResActivityLike CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ResActivityLike>(jsonString);
    }
}

[System.Serializable]
public class ResActivityLikeUser
{
    public int content;
    public bool like;
}

[System.Serializable]
public class ResGetActivityLike
{
	public int status_code;
	public string message;

	public ResGetActivityLikeUser[] users;

	public static ResGetActivityLike CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetActivityLike>(jsonString);
	}
}

[System.Serializable]
public class ResGetActivityLikeUser
{
    public int contents;
    public bool like;
}

[System.Serializable]
public class ResGetActivitySlideShow1
{
    public int status_code;
    public string message;

	public ResGetActivitySlideShowImage1[] images;

	public static ResGetActivitySlideShow1 CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetActivitySlideShow1>(jsonString);
	}
}

[System.Serializable]
public class ResGetActivitySlideShowImage1
{
	public string image_url;
}

[System.Serializable]
public class ResGetActivitySlideShow2
{
    public int status_code;
    public string message;

    public ResGetActivitySlideShowImage2[] images;

    public static ResGetActivitySlideShow2 CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ResGetActivitySlideShow2>(jsonString);
    }
}

[System.Serializable]
public class ResGetActivitySlideShowImage2
{
    public string image_url;
}

[System.Serializable]
public class ResUserInfo
{
	public string name;
	public string image;
	public string model;
	public string birthdate;
	public string bio;
	public string sex;

	public static ResUserInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserInfo>(jsonString);
	}
}

[System.Serializable]
public class ResUserProfile
{
	public string firstname;
	public string lastname;
	public int coin;

	public static ResUserProfile CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserProfile>(jsonString);
	}
}

[System.Serializable]
public class ResUserGuest
{
    public int status_code;
	public string message;

	public Guest guest;

	public static ResUserGuest CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserGuest>(jsonString);
	}
}

[System.Serializable]
public class ResLoveAdd
{
	public int status_code;
	public string message;

	public Guest guest;

	public static ResLoveAdd CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResLoveAdd>(jsonString);
	}
}

[System.Serializable]
public class Guest
{
	public string id;
	public string love;

	public static Guest CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Guest>(jsonString);
	}
}

[System.Serializable]
public class Professor
{
	public int id;
	public string fullname;
	public string love;

	public static Professor CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Professor>(jsonString);
	}
}

[System.Serializable]
public class ReqGuestLoveSpent
{
	public GuestLoveSpent guest;
	public ProfessorLoveSpent professor;

	public static ReqGuestLoveSpent CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqGuestLoveSpent>(jsonString);
	}
}

[System.Serializable]
public class GuestLoveSpent
{
	public string id;

	public static GuestLoveSpent CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<GuestLoveSpent>(jsonString);
	}
}

[System.Serializable]
public class ProfessorLoveSpent
{
	public int id;

	public static ProfessorLoveSpent CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ProfessorLoveSpent>(jsonString);
	}
}

[System.Serializable]
public class ResGuestLoveSpent
{
	public int status_code;
	public string message;

	public Guest guest;
	public Professor professor;

	public static ResGuestLoveSpent CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGuestLoveSpent>(jsonString);
	}
}

[System.Serializable]
public class ResProfessorList
{
	public int status_code;
	public string message;

	public Professor[] professor;

	public static ResProfessorList CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResProfessorList>(jsonString);
	}
}

[System.Serializable]
public class ReqUpdateUserInfo
{
	public ReqUserInfo user;

	public static ReqUpdateUserInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqUpdateUserInfo>(jsonString);
	}
}

[System.Serializable]
public class ReqUserInfo
{
	public string id;
	public string playername;
	public string model;
}

[System.Serializable]
public class ReqGuestUpdateUserInfo
{
    public ReqGuestUserInfo user;

    public static ReqGuestUpdateUserInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ReqGuestUpdateUserInfo>(jsonString);
    }
}

[System.Serializable]
public class ReqGuestUserInfo
{
    public string playername;
}

[System.Serializable]
public class ResUpdateUserInfo
{
	public int status_code;
	public string message;

	public static ResUpdateUserInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUpdateUserInfo>(jsonString);
	}
}

[System.Serializable]
public class GetUpdateUserInfo
{
	public string user_id;
	public string birthdate;
	public string bio;
	public string model;

	public static GetUpdateUserInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<GetUpdateUserInfo>(jsonString);
	}
}


[System.Serializable]
public class ReqUpdateBio
{
	public ReqUserBio user;

	public static ReqUpdateBio CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqUpdateBio>(jsonString);
	}
}

[System.Serializable]
public class ReqUserBio
{
	public string id;
	public string bio;
}

[System.Serializable]
public class ResUserBio
{
	public int status_code;
	public string message;

	public static ResUserBio CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserBio>(jsonString);
	}
}

[System.Serializable]
public class GetUsereBio
{
	public string user_id;
	public string birthdate;
	public string bio;
	public string model;

	public static GetUsereBio CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<GetUsereBio>(jsonString);
	}
}

[System.Serializable]
public class ResGetBio
{
	public int status_code;
	public string message;

	public ResUserGetBio user;
	public static ResGetBio CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetBio>(jsonString);
	}
}

[System.Serializable]
public class ResUserGetBio
{
	public string bio;

	public static ResUserGetBio CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserGetBio>(jsonString);
	}
}

[System.Serializable]
public class ReqScoreAdd
{
	public ReqUserScoreAdd user;

	public static ReqScoreAdd CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqScoreAdd>(jsonString);
	}
}

[System.Serializable]
public class ReqUserScoreAdd
{
	public string id;
	public int score;
	public int game;
}

[System.Serializable]
public class ResScoreAdd
{
	public int status_code;
	public string message;

	public ResUserScoreAdd[] users;

	public static ResScoreAdd CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResScoreAdd>(jsonString);
	}
}

[System.Serializable]
public class ResUserScoreAdd
{
	public int score;
}


[System.Serializable]
public class ReqScoreSpent
{
	public ReqUserScoreSpent user;
	public ReqRewardScoreSpent reward;

    public static ReqScoreSpent CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqScoreSpent>(jsonString);
	}
}

[System.Serializable]
public class ReqUserScoreSpent
{
	public string id;
}

[System.Serializable]
public class ReqRewardScoreSpent
{
    public int id;
}

[System.Serializable]
public class ResScoreSpent
{
	public int status_code;
	public string message;

	public ResUserScoreSpent user;

	public static ResScoreSpent CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResScoreSpent>(jsonString);
	}
}

[System.Serializable]
public class ResUserScoreSpent
{
	public int coin;
}

[System.Serializable]
public class ReqGarbageCollectAdd
{
	public ReqUserGarbageCollectAdd user;

	public static ReqGarbageCollectAdd CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqGarbageCollectAdd>(jsonString);
	}
}

[System.Serializable]
public class ReqUserGarbageCollectAdd
{
	public string id;
	public string garbage;
}


[System.Serializable]
public class ResGarbageCollectAdd
{
	public int status_code;
	public string message;

	public static ResGarbageCollectAdd CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGarbageCollectAdd>(jsonString);
	}
}

[System.Serializable]
public class ResGetGarbageCollect
{
	public int status_code;
	public string message;

	public ResUserGetGarbageCollect user;
	public static ResGetGarbageCollect CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetGarbageCollect>(jsonString);
	}
}

[System.Serializable]
public class ResUserGetGarbageCollect
{
	public string garbage;

	public static ResUserGetBio CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserGetBio>(jsonString);
	}
}


[System.Serializable]
public class ResGetScoreLeaderBoard
{
	public int status_code;
	public string message;

	public ResUserScoreLeaderBoard[] users;
	public static ResGetScoreLeaderBoard CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetScoreLeaderBoard>(jsonString);
	}
}

[System.Serializable]
public class ResUserScoreLeaderBoard
{
    public string id;
    public string playername;
	public string score;
}

[System.Serializable]
public class ReqGetScoreLeaderBoardGame
{
    public ReqUserGetScoreLeaderBoardGame user;
	public int game;
    public static ReqGetScoreLeaderBoardGame CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ReqGetScoreLeaderBoardGame>(jsonString);
    }
}

[System.Serializable]
public class ReqUserGetScoreLeaderBoardGame
{
    public string id;
}

[System.Serializable]
public class ResGetScoreLeaderBoardGame
{
    public int status_code;
    public string message;
    public int game;

    public ResUserGetScoreLeaderBoardGame[] users;
    
    public static ResGetScoreLeaderBoardGame CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ResGetScoreLeaderBoardGame>(jsonString);
    }
}

[System.Serializable]
public class ResUserGetScoreLeaderBoardGame
{
    //public string id;
    public string playername;
    public int score;
    public int ranking;
}

[System.Serializable]
public class ResGetScoreLimit
{
	public int status_code;
	public string message;

	public ResUserScoreLimit user;
	public static ResGetScoreLimit CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetScoreLimit>(jsonString);
	}
}

[System.Serializable]
public class ResUserScoreLimit
{
	public int score;
	public int limit;
}


[System.Serializable]
public class ReqMessageCheck
{
	public ReqMessage message;

	public static ReqMessageCheck CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqMessageCheck>(jsonString);
	}
}

[System.Serializable]
public class ResMessageCheck
{
	public int status_code;
	public ResMessage message;

	public static ResMessageCheck CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResMessageCheck>(jsonString);
	}
}

[System.Serializable]
public class ReqMessage
{
	public string text;

	public static ReqMessage CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqMessage>(jsonString);
	}
}

[System.Serializable]
public class ResMessage
{
	public string text;

	public static ResMessage CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResMessage>(jsonString);
	}
}


[System.Serializable]
public class ReqNewpet
{
	public NewpetUser user;
	public NewpetPet pet;

	public static GetUpdateUserInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<GetUpdateUserInfo>(jsonString);
	}
}

[System.Serializable]
public class NewpetUser
{
	public string id;
}

[System.Serializable]
public class NewpetPet
{
	public string name;
	public string birthdate;
	public string model;
    public string breed;
	public string sex;
}

[System.Serializable]
public class ResNewpet
{
	public int status_code;
	public string message;

	public static ResNewpet CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResNewpet>(jsonString);
	}
}

[System.Serializable]
public class ReqUpdatePet
{
	public ReqUpdatePetUser user;
	public ReqUpdatePetPet pet;

	public static ReqUpdatePet CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqUpdatePet>(jsonString);
	}
}

[System.Serializable]
public class ReqUpdatePetUser
{
	public string id;
}

[System.Serializable]
public class ReqUpdatePetPet
{
	public int id;
	public string name;
	public string birthdate;
	public string model;
	public string sex;
}

[System.Serializable]
public class ResUpdatePet
{
	public int status_code;
	public string message;

	public static ResUpdatePet CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUpdatePet>(jsonString);
	}
}

//pet set default

[System.Serializable]
public class ReqPetSetDefault
{
	public ReqPetSetDefaultUser user;
	public ReqPetSetDefaultPet pet;

	public static ReqPetSetDefault CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqPetSetDefault>(jsonString);
	}
}

[System.Serializable]
public class ReqPetSetDefaultUser
{
	public string id;
}

[System.Serializable]
public class ReqPetSetDefaultPet
{
	public int id;
}

[System.Serializable]
public class ResPetSetDefaultPet
{
	public int status_code;
	public string message;

	public static ResPetSetDefaultPet CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResPetSetDefaultPet>(jsonString);
	}
}

//Get pet info

[System.Serializable]
public class ReqGetPetInfo
{
	public ReqGetPetInfoPet pet;

	public static ReqGetPetInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqGetPetInfo>(jsonString);
	}
}

[System.Serializable]
public class ReqGetPetInfoPet
{
	public string name;
	public string birthdate;
	public string model;
	public string sex;
}

[System.Serializable]
public class ResGetPetInfo
{
	public int status_code;
	public string message;

	public static ResGetPetInfo CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetPetInfo>(jsonString);
	}
}

[System.Serializable]
public class ReqModelAdd
{
	public ReqUserModel user;

	public static ReqModelAdd CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqModelAdd>(jsonString);
	}
}

[System.Serializable]
public class ReqUserModel
{
	public string id;
	public string model;
	public string playername;
	public static ReqUserModel CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ReqUserModel>(jsonString);
	}
}

[System.Serializable]
public class ResUserModel
{
	public int status_code;
	public string message;

	public ResUserModel user;
	public static ResUserModel CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserModel>(jsonString);
	}
}

[System.Serializable]
public class ResGetModel
{
	public int status_code;
	public string message;

	public ResUserGetModel user;
	public static ResGetModel CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResGetModel>(jsonString);
	}
}

[System.Serializable]
public class ResUserGetModel
{
	public string playername;
	public int coin;
	public string model;
	
	public static ResUserGetModel CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResUserGetModel>(jsonString);
	}
}

//------------------------------------------------------------------

/*[System.Serializable]
public class GetCoinClass
{
	public int status_code;
	public int coin;
	public string authen_code;

	public static GetCoinClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<GetCoinClass>(jsonString);
	}
}*/
/*[System.Serializable]
public class AddCoinClass
{
	public int status_code;
	public int coin;

	public static AddCoinClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<AddCoinClass>(jsonString);
	}
}*/

/*[System.Serializable]
public class ResetCoinClass
{
	public int status_code;
	public int coin;

	public static ResetCoinClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResetCoinClass>(jsonString);
	}
}*/

/*[System.Serializable]
public class NFTClass
{
	public int status_code;
	public int chance;
	public string message;

	public static NFTClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<NFTClass>(jsonString);
	}
}*/

/*[System.Serializable]
public class RewordClass
{
	public int status_code;
	public int chance;
	public string message;

	public static RewordClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<RewordClass>(jsonString);
	}
}*/

[System.Serializable]
public class ResForgetClass
{
	public int status_code;
	public string message;
	public string message_id;

	public static ResForgetClass CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<ResForgetClass>(jsonString);
	}
}


