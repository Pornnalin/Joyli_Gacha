using UnityEngine;


public class CardAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform frontCard;
    [SerializeField] private RectTransform backCard;
    [SerializeField] private GameObject cardGroup;
    public float timeBack;
    public float timeFront;
    [SerializeField] private RectTransform slotTarget;


    void Start()
    {       
       // RotateCardOpen();
        //RotateCardOpenLoop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //public void RotateCardOpenLoop()
    //{
    //    LeanTween.rotateLocal(backCard.gameObject, new Vector3(0, 90, 0), timeBack)
    //       .setEase(LeanTweenType.easeInOutSine)
    //       .setOnComplete(() =>
    //       {

    //           LeanTween.rotateLocal(frontCard.gameObject, Vector3.zero, timeFront)
    //               .setEase(LeanTweenType.easeInOutSine).setOnComplete(() =>
    //               {

    //                   RotateCardClose();
    //               });

    //       }).setDelay(1f);
    //}
    //public void RotateCardClose()
    //{
    //    LeanTween.rotateLocal(frontCard.gameObject, new Vector3(0, 90, 0), timeFront)
    //       .setEase(LeanTweenType.easeInOutSine)
    //       .setOnComplete(() =>
    //       {

    //           LeanTween.rotateLocal(backCard.gameObject, Vector3.zero, timeBack)
    //               .setEase(LeanTweenType.easeInOutSine).setOnComplete(() =>
    //               {

    //                   RotateCardOpenLoop();
    //               });

    //       }).setDelay(1f);
    //}

    public void RotateCardOpen()
    {
        //flip card 
        LeanTween.rotateLocal(backCard.gameObject, new Vector3(0, 90, 0), timeBack)
           .setEase(LeanTweenType.easeOutQuad)
           .setOnComplete(() =>
           {

               LeanTween.rotateLocal(frontCard.gameObject, Vector3.zero, timeFront)
                   .setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                   {
                       //move to slot
                       MoveCardToSlot();
                   });

           });
    }

    public void MoveCardToSlot()
    {
        if (slotTarget == null)
        {
            slotTarget = GameObject.Find("Frame").GetComponent<RectTransform>();
        }

        LeanTween.move(cardGroup, new Vector2(slotTarget.position.x, slotTarget.position.y - 0.06f), 0.3f).setEase(LeanTweenType.easeOutSine).setDelay(1f);

        LeanTween.size(frontCard, new Vector2(frontCard.rect.width / 3, frontCard.rect.height / 3), 0.8f).setEase(LeanTweenType.easeOutExpo).setDelay(1f);

    }
    [ContextMenu("debug")]
    public void DebugSize()
    {
        Debug.Log(slotTarget.sizeDelta.x);
        Debug.Log(slotTarget.sizeDelta.y);
        Debug.Log(frontCard.sizeDelta);
    }
}
