using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject shopBg;
    [SerializeField] private GameObject menu;
    //[Header("MenuButton")]
    //[SerializeField] private Button buyBtn;
    //[SerializeField] private Button howToPlayBtn;
    //[SerializeField] private Button collectionBtn;
    //[SerializeField] private Button rewardBtn;

    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject buy;
    [SerializeField] private GameObject collection;
    [SerializeField] private GameObject reward;
    [SerializeField] private GameObject showReward;
    [SerializeField] private GameObject openCard;
    [SerializeField] private GameObject option;
    [SerializeField] private Button[] optionChild;
    [SerializeField] private string[] optionChildName;
    [SerializeField] private GameObject currentPanel;

    [SerializeField] private TextMeshProUGUI wordCatText;
    // Start is called before the first frame update
    void Start()
    {
        currentPanel = null;
    }
    [ContextMenu("GetName")]
    public void GetName()
    {
        optionChildName = new string[optionChild.Length];
        for (int i = 0; i < optionChild.Length; i++)
        {
            optionChildName[i] = optionChild[i].name;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateDisplayOption();
    }

    public void UpdateDisplayOption()
    {
        //optionChildName = Home , Music,Close
        if (menu.activeInHierarchy)
        {
            foreach (Button go in optionChild)
            {
                if (go.gameObject.name != optionChildName[1])
                {
                    go.gameObject.SetActive(false);
                }
                else
                {
                    go.gameObject.SetActive(true);
                }
            }
        }
        if (howToPlay.activeInHierarchy || buy.activeInHierarchy || showReward.activeInHierarchy || reward.activeInHierarchy || collection.activeInHierarchy)
        {
            foreach (Button go in optionChild)
            {
                go.gameObject.SetActive(true);

            }
        }
        if (openCard.activeInHierarchy)
        {
            foreach (Button go in optionChild)
            {
                if (go.gameObject.name != optionChildName[2])
                {
                    go.gameObject.SetActive(true);
                }
                else
                {
                    go.gameObject.SetActive(false);
                }
            }
        }
        if (AnimationCardManager.instance.currentStep == AnimationCardManager.stepOpenCard.ShowCard)
        {
            menu.SetActive(false);
            shopBg.SetActive(false);
            wordCatText.text = "การ์ดที่ได้";
        }
    }
    
   
    public void ActivePanel(GameObject objActive)
    {
        objActive.SetActive(true);
        currentPanel = objActive;
        Debug.Log("Click");
    }
    public void CloseCurrentPanel()
    {
        currentPanel.SetActive(false);
        // currentPanel = null;
    }
}
