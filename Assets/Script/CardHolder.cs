using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    public enum stepOpenCard
    {
        None,
        tutorialMove,
        playerOpenCard,
        AnimationTopAndDown,
        End

    }
    public stepOpenCard currentStep;
    public Scrollbar scroll;
    public GameObject cardHolderTop;
    public GameObject cardHolderDown;
    public GameObject lightLine;

    private GameObject arrow;
    private GameObject hand;
    [Header("ArrowAndHand")]
    private bool isTutorialMoveStarted = false;
    [SerializeField] private GameObject arrowAndHand;
    [SerializeField] private RectTransform startArrow, targetArrow;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = stepOpenCard.tutorialMove;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(arrow.transform.position);
        switch (currentStep)
        {
            case stepOpenCard.None:

                break;
            case stepOpenCard.tutorialMove:
                if (!isTutorialMoveStarted)
                {
                    isTutorialMoveStarted = true;
                    TutorialMove();
                }
                break;
            case stepOpenCard.playerOpenCard:
                break;
            case stepOpenCard.AnimationTopAndDown:
                break;
            case stepOpenCard.End:
                break;
        }
    }
    void TutorialMove()
    {
        CanvasGroup canvasGroup = arrowAndHand.GetComponent<CanvasGroup>();
        LeanTween.moveLocalX(arrowAndHand, targetArrow.anchoredPosition.x, 1f).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(canvasGroup, 0f, 0.7f).setEase(LeanTweenType.linear);
            LeanTween.moveLocalX(arrowAndHand, startArrow.anchoredPosition.x, 0.5f).setDelay(1f).setOnComplete(() =>
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
            arrowAndHand.SetActive(false);
            cardHolderTop.SetActive(false);
            cardHolderDown.SetActive(false);
        }
    }
}
