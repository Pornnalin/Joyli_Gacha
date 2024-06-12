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
        tutorialMove,
        AnimationCardOutHolder,
        AnimationTopAndDown,
        ShowCard,
        FlipCard,
        End

    }
    public stepOpenCard currentStep;
    public CardAnimation cardAnimation;
    public CardHolder cardHolder;
    [SerializeField] private GameObject Card2dPrefab;
    [SerializeField] private GameObject Card2dCloseXPrefab;
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
        GameObject a = Instantiate(Card2dPrefab, rectSpawnFirst.anchoredPosition, Quaternion.identity);
        a.transform.SetParent(rectSpawnFirst.transform.parent, false);
        a.transform.SetSiblingIndex(rectSpawnFirst.GetSiblingIndex());
        a.GetComponent<RectTransform>().localScale = new Vector2(2f, 2f);

        GameObject b = Instantiate(Card2dCloseXPrefab, rectSpawnSec.anchoredPosition, Quaternion.identity);
        b.transform.SetParent(rectSpawnSec.transform.parent, false);
        b.transform.SetSiblingIndex(rectSpawnSec.GetSiblingIndex());
        b.GetComponent<RectTransform>().localScale = new Vector2(1.7f, 1.7f);
        b.GetComponent<RectTransform>().localPosition = new Vector2(-1956f, -4f);
    //    b.SetActive(false);

        allCard.Add(a);
        allCard.Add(b);
        

    }
  
}
