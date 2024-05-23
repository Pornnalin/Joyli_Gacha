using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Screen.autorotateToPortrait = false;

       // Screen.autorotateToPortraitUpsideDown = true;

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
