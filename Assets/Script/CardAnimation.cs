using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform frontCard;
    [SerializeField] private RectTransform backCard;
    public float timeBack;
    public float timeFront;
    public AnimationCurve animationCurveBack;
    public AnimationCurve animationCurveFront;
    // Start is called before the first frame update
    void Start()
    {

        RotateCardOpen();
    }

    // Update is called once per frame
    void Update()
    {

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

                       RotateCardOpen();
                   });

           }).setDelay(1f);
    }
}
