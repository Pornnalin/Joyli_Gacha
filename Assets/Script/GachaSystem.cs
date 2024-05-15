using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    public Rate rateSO;
    public StoreCards storeCardsSO;
    // [SerializeField] private Button randomCards;
    //[SerializeField] private Button cheap;
    //[SerializeField] private Button medium;
    //[SerializeField] private Button expensive;
  //  [SerializeField] private Image[] image;
    [SerializeField] private int amountCard;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform parent;
    public List<GameObject> cardList;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
       // randomCards.onClick.AddListener(PullGacha);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    for (int i = 0; i < amountCard; i++)
        //    {
        //        RandomNumber(i);
        //    }
        //}
    }
    public void PullGacha(int amount)
    {
        if (cardList.Count > 0)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                Destroy(cardList[i]);
            }
            cardList.Clear();
        }
        int result = amount * amountCard;
        for (int i = 0; i < result; i++)
        {
            RandomNumber(i);
        }
    }
    [ContextMenu("Rand")]
    public void RandomNumber(int i)
    {
        int totalWeight = rateSO.setRate.superRare + rateSO.setRate.rare + rateSO.setRate.common;
        int rand = Random.Range(0, totalWeight + 1);

        if (rand <= rateSO.setRate.superRare)
        {
            // Debug.Log(rand.ToString());
            //SpawnCard(superRareCards());
            Card3D(i);
            Debug.Log("Super_" + rand);

        }

        else if (rand > rateSO.setRate.superRare && rand <= rateSO.setRate.rare) 
        {
            //SpawnCard(rareCards());
            Card3D(i);
            Debug.Log("Rare_" + rand);

        }
        else
        {
            //image[i].sprite = storeCardsSO.commonCards[Random.Range(0, storeCardsSO.commonCards.Count)].cardSprite;
            //SpawnCard(commonCards());
            Card3D(i);
            Debug.Log("Common_" + rand);

        }


    }
    public void Card3D(int i)
    {
        var card = Instantiate(cardPrefab, new Vector3(0 + i, 0, 0), Quaternion.Euler(-90, -90, 90));
        //  card.transform.SetParent(parent, false);
        // card.GetComponent<Image>().sprite = cardInfo.cardSprite;
        cardList.Add(card);
    }
    private void SpawnCard(CardInfo cardInfo)
    {
        //image[i].sprite = storeCardsSO.superRareCards[Random.Range(0, storeCardsSO.superRareCards.Count)].cardSprite;
        var card = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        card.transform.SetParent(parent, false);
        card.GetComponent<Image>().sprite = cardInfo.cardSprite;
        cardList.Add(card);
    }

    private CardInfo superRareCards()
    {
        return storeCardsSO.superRareCards[Random.Range(0, storeCardsSO.superRareCards.Count)];
    }
    private CardInfo rareCards()
    {
        return storeCardsSO.rareCards[Random.Range(0, storeCardsSO.rareCards.Count)];
    }
    private CardInfo commonCards()
    {
        return storeCardsSO.commonCards[Random.Range(0, storeCardsSO.commonCards.Count)];
    }
}

