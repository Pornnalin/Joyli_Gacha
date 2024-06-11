using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class CardHolder : MonoBehaviour, IDragHandler
{
   
    public Scrollbar scroll;
    public Image cardHolderTop;
    public Image cardHolderDown;
    public Image lightLine;
    public Image bg;
    public Vector2 topTargetPos;
    public float zRotTop;
    [Header("CardInside")]
    public GameObject cardInside;
    public float yPosCardInside;
    public Vector2 insideTargetPos;  
    [Header("ArrowAndHand")]  
    [SerializeField] private GameObject arrowAndHand;
    [SerializeField] private RectTransform startArrow, targetArrow;
   
    // Start is called before the first frame update
    void Start()
    {
        TutorialMove();
        AnimationCardManager.instance.currentStep = AnimationCardManager.stepOpenCard.tutorialMove;
        cardInside = AnimationCardManager.instance.SpawnCard();
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

    public void AnimationOpenCardHolder()
    {
        // cardHolderTop.SetActive(false);
        //   cardHolderDown.SetActive(false);
        CanvasGroup canvasGroup = arrowAndHand.GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEase(LeanTweenType.easeOutSine).setOnComplete(() =>
        {
            LeanTween.cancel(arrowAndHand);
            AnimationCardManager.instance.currentStep = AnimationCardManager.stepOpenCard.AnimationCardOutHolder;
            LeanTween.scale(lightLine.gameObject, new Vector2(1f, 1f), 0.1f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() =>
            {
                LeanTween.alpha(lightLine.rectTransform, 0, 0.7f).setEase(LeanTweenType.easeOutSine);
                AnimationTopCard();
            });
            arrowAndHand.SetActive(false);

        });
    }
    public void AnimationTopCard()
    {
        LeanTween.moveLocal(cardHolderTop.gameObject, topTargetPos, 0.8f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.rotateZ(cardHolderTop.gameObject, zRotTop, 0.8f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
        {
            LeanTween.alpha(cardHolderTop.rectTransform, 0, 1f).setEase(LeanTweenType.easeOutSine);
            LeanTween.alpha(cardHolderDown.rectTransform, 0, 0.7f).setEase(LeanTweenType.easeOutSine).setOnComplete(() =>
            {
                LeanTween.moveLocal(cardInside.gameObject, insideTargetPos, 0.7f).setEase(LeanTweenType.easeOutQuad);

            });
        });
        LeanTween.moveLocalY(cardInside, yPosCardInside, 0.7f).setEase(LeanTweenType.easeOutQuad); 
    }
}
