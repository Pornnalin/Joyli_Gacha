using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class CardHolder : MonoBehaviour, IDragHandler
{   
    [SerializeField] private Scrollbar scroll;
    [SerializeField] private Image cardHolderTop;
    [SerializeField] private Image cardHolderDown;
    [SerializeField] private Image lightLine;
    [SerializeField] private Vector2 topTargetPos;
    [SerializeField] private float zRotTop;
    [Header("BG")]
    public Image bgFirst;
    [SerializeField] private Image bgSec;   
    //[Header("CardInside")]
   // public GameObject cardInside;
    [SerializeField] private float yPosCardInside;
    [SerializeField] private Vector2 insideTargetPos;  
    [Header("ArrowAndHand")]  
    [SerializeField] private GameObject arrowAndHand;
    [SerializeField] private RectTransform startArrow, targetArrow;
    [Space]
    [SerializeField] private Image lightBG;
    [SerializeField] private GameObject framePanel;
    
     // Start is called before the first frame update
     void Start()
    {
        TutorialMove();
        AnimationCardManager.instance.currentStep = AnimationCardManager.stepOpenCard.tutorialMove;
        AnimationCardManager.instance.SpawnCard();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(arrow.transform.position);
        
    }
    void TutorialMove()
    {
        CanvasGroup canvasGroup = arrowAndHand.GetComponent<CanvasGroup>();
        LeanTween.moveLocalX(arrowAndHand, targetArrow.anchoredPosition.x, 1f).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(canvasGroup, 0f, 0.7f).setEase(LeanTweenType.linear);
            LeanTween.moveLocalX(arrowAndHand, startArrow.anchoredPosition.x, 0.5f).setDelay(0.7f).setOnComplete(() =>
            {
                LeanTween.alphaCanvas(canvasGroup, 1f, 0.7f).setEase(LeanTweenType.linear).setOnComplete(() =>
                {
                    TutorialMove();

                });
            });
        });


    }
    public void CloseHand()
    {
        if (scroll.value >= 1)
        {
            AnimationOpenCardHolder();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        scroll.OnDrag(eventData);
    }

    private void AnimationOpenCardHolder()
    {        
        CanvasGroup canvasGroup = arrowAndHand.GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEase(LeanTweenType.easeOutSine).setOnComplete(() =>
        {
            LeanTween.cancel(arrowAndHand);

            AnimationCardManager.instance.currentStep = AnimationCardManager.stepOpenCard.AnimationCardOutHolder;
            LeanTween.scale(lightLine.gameObject, new Vector2(1f, 1f), 0.1f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() =>
            {
                LeanTween.alpha(lightLine.rectTransform, 0, 1f).setEase(LeanTweenType.easeOutSine).setOnComplete(() =>
                {
                    LeanTween.cancel(lightLine.gameObject);
                    lightLine.gameObject.SetActive(false);

                });

                AnimationTopCard();
            });
            arrowAndHand.SetActive(false);

        });
    }
    private void AnimationTopCard()
    {
        GameObject cardInside = AnimationCardManager.instance.allCard[0];
        AnimationCardManager.instance.currentStep = AnimationCardManager.stepOpenCard.AnimationTopAndDown;

        LeanTween.moveLocal(cardHolderTop.gameObject, topTargetPos, 0.8f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.rotateZ(cardHolderTop.gameObject, zRotTop, 0.8f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
        {
            LeanTween.alpha(cardHolderTop.rectTransform, 0, 1f).setEase(LeanTweenType.easeOutSine);
            LeanTween.alpha(cardHolderDown.rectTransform, 0, 0.7f).setEase(LeanTweenType.easeOutSine).setOnComplete(() =>
            {
                LeanTween.moveLocal(cardInside.gameObject, insideTargetPos, 0.7f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                {
                    LeanTween.scale(cardInside.gameObject, new Vector3(3, 3, 3), 0.7f).setEase(LeanTweenType.easeOutSine);
                    AnimationTwoBG();
                });

            });
        });

        LeanTween.moveLocalY(cardInside, yPosCardInside, 0.7f).setEase(LeanTweenType.easeOutQuad);
    }
    private void AnimationTwoBG()
    {
        GameObject cardInside = AnimationCardManager.instance.allCard[1];
        AnimationCardManager.instance.currentStep = AnimationCardManager.stepOpenCard.ShowCard;
        //two bg lerp
        LeanTween.alpha(bgFirst.rectTransform, 0, 0.6f).setEase(LeanTweenType.easeOutSine);
        LeanTween.alpha(bgSec.rectTransform, 1, 0.3f).setEase(LeanTweenType.easeOutSine).setOnComplete(() =>
        {
            LeanTween.alpha(lightBG.rectTransform, 0.7f, 0.4f);
            LeanTween.rotateAround(lightBG.gameObject, Vector3.forward, -360f,10f).setLoopClamp();
            LeanTween.moveLocalX(cardInside, AnimationCardManager.instance.rectSpawnSec.anchoredPosition.x, 0.7f).setEase(LeanTweenType.easeOutSine);
            framePanel.SetActive(true);
        });
        SelectBG(1);
    }
    private void SelectBG(int index)
    {
        bgSec.sprite = AnimationCardManager.instance.allBg[index];
    }

}
