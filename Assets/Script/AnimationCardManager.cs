using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCardManager : MonoBehaviour
{
    public static AnimationCardManager instance;
    public enum stepOpenCard
    {
        None,
        tutorialMove,
        AnimationCardOutHolder,
        AnimationTopAndDown,
        End

    }
    public stepOpenCard currentStep;

    public CardAnimation cardAnimation;
    public CardHolder cardHolder;
    [SerializeField] private GameObject Card2dPrefab;
    [SerializeField] private RectTransform rectSpawn;
    public List<GameObject> allCard;
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
    public GameObject SpawnCard()
    {
        GameObject a = Instantiate(Card2dPrefab, rectSpawn.anchoredPosition, Quaternion.identity);
        a.transform.SetParent(rectSpawn.transform.parent, false);
        a.transform.SetSiblingIndex(rectSpawn.GetSiblingIndex());
        allCard.Add(a);
        return a;

    }
}
