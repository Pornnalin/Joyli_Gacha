using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform frontCard;
    [SerializeField] private RectTransform backCard;
    [SerializeField] private GameObject cardGroup;
    public float timeBack;
    public float timeFront;
    public AnimationCurve animationCurveBack;
    public AnimationCurve animationCurveFront;
    [SerializeField] private RectTransform targetRect;
    //[SerializeField] private Vector2 sizeTarget;
    // Start is called before the first frame update
    void Start()
    {
        RotateCardOpen();
        //RotateCardOpenLoop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RotateCardOpenLoop()
    {
        LeanTween.rotateLocal(backCard.gameObject, new Vector3(0, 90, 0), timeBack)
           .setEase(animationCurveBack)
           .setOnComplete(() =>
           {

               LeanTween.rotateLocal(frontCard.gameObject, Vector3.zero, timeFront)
                   .setEase(animationCurveFront).setOnComplete(() =>
                   {

                       RotateCardClose();
                   });

           }).setDelay(1f);
    }
    public void RotateCardClose()
    {
        LeanTween.rotateLocal(frontCard.gameObject, new Vector3(0, 90, 0), timeFront)
           .setEase(animationCurveFront)
           .setOnComplete(() =>
           {

               LeanTween.rotateLocal(backCard.gameObject, Vector3.zero, timeBack)
                   .setEase(animationCurveBack).setOnComplete(() =>
                   {

                       RotateCardOpenLoop();
                   });

           }).setDelay(1f);
    }
    public void RotateCardOpen()
    {
        LeanTween.rotateLocal(backCard.gameObject, new Vector3(0, 90, 0), timeBack)
           .setEase(animationCurveBack)
           .setOnComplete(() =>
           {

               LeanTween.rotateLocal(frontCard.gameObject, Vector3.zero, timeFront)
                   .setEase(animationCurveFront).setOnComplete(() =>
                   {
                       MoveCardToSlot();
                   });

           }).setDelay(1f);
    }

    public void MoveCardToSlot()
    {
        LeanTween.move(cardGroup, targetRect.position, 1f)
           .setEase(LeanTweenType.easeInSine).setDelay(1f).setOnUpdate((float a) =>
           {
            //   LeanTween.alpha(frontCard, 0.3f, 0.1f).setEase(LeanTweenType.easeOutQuint);

           });

        LeanTween.size(frontCard, new Vector2(frontCard.rect.width / 3, frontCard.rect.height / 3), 1f).setEase(LeanTweenType.easeInSine).setDelay(1f).setOnComplete(() =>
              {
               //   LeanTween.alpha(frontCard, 1f, 1f).setEase(LeanTweenType.easeInSine);

              });




    }
    [ContextMenu("debug")]
    public void DebugSize()
    {
        Debug.Log(targetRect.sizeDelta.x);
        Debug.Log(targetRect.sizeDelta.y);
        Debug.Log(frontCard.sizeDelta);
    }
}
