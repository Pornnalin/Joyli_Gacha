using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationCardManager : MonoBehaviour
{
    public static AnimationCardManager instance;
    public enum stepOpenCard
    {
        None,
        TutorialMove,
        AnimationCardOutHolder,
        AnimationTopAndDown,
        ShowBackCard,
        ShowFrontCard,
        End

    }
    public stepOpenCard currentStep;
    public CardAnimation cardAnimation;
    public CardHolder cardHolder;
    [SerializeField] private GameObject Card2dPrefab;  
    [SerializeField] private RectTransform rectSpawnFirst;
    public RectTransform rectSpawnSec;
    public List<GameObject> allCard;
    public Sprite[] allBg;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnCard()
    {
        GameObject one = Instantiate(Card2dPrefab, rectSpawnFirst.anchoredPosition, Quaternion.identity);
        one.transform.SetParent(rectSpawnFirst.transform.parent, false);
        one.transform.SetSiblingIndex(rectSpawnFirst.GetSiblingIndex());
        one.GetComponent<RectTransform>().localScale = new Vector2(2f, 2f);

        GameObject two = Instantiate(Card2dPrefab, rectSpawnSec.anchoredPosition, Quaternion.identity);
        two.transform.SetParent(rectSpawnSec.transform.parent, false);
        two.transform.SetSiblingIndex(rectSpawnSec.GetSiblingIndex());
        two.GetComponent<RectTransform>().localScale = new Vector2(1.7f, 1.7f);
        two.GetComponent<RectTransform>().localPosition = new Vector2(-1956f, -4f);
        two.transform.GetChild(2).gameObject.SetActive(true);
    //    b.SetActive(false);

        allCard.Add(one);
        allCard.Add(two);
        

    }
  
}
