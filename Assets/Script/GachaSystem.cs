using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    public Rate rateSO;
    public StoreCards storeCardsSO;   
    [SerializeField] private int amountCard;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform parent;
    public List<GameObject> cardList;
    public List<MyCollection> myCollectionList = new List<MyCollection>();
    public Dictionary<int, int> mydic= new Dictionary<int, int>();
    void Start()
    {
        MyCollertionLoop();
    }

    private void MyCollertionLoop()
    {
        //myCollectionList = new List<MyCollection>();

        for (int i = 0; i < storeCardsSO.totalCard; i++)
        {
            int index = i + 1;
            MyCollection myCollection = new MyCollection();
            myCollection.id = i + 1;
            myCollectionList.Add(myCollection);
            mydic.Add(index, 0);
        }
        foreach (var item in mydic)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        float totalWeight = rateSO.setRate.superRare + rateSO.setRate.rare + rateSO.setRate.common;
        float rand = Random.Range(0, totalWeight + 1);

        if (rand <= rateSO.setRate.superRare)
        {
            // Debug.Log(rand.ToString());
            SpawnCard(superRareCards(), i);
            //  Card3D(i);
            Debug.Log("Super_");

        }

        else if (rand > rateSO.setRate.superRare && rand <= rateSO.setRate.rare)
        {
            SpawnCard(rareCards(), i);
            //  Card3D(i);
            Debug.Log("Rare_");

        }
        else
        {
            //image[i].sprite = storeCardsSO.commonCards[Random.Range(0, storeCardsSO.commonCards.Count)].cardSprite;
            SpawnCard(commonCards(), i);
            // Card3D(i);
            Debug.Log("Common_");

        }


    }
    #region 3D
    public void Card3D(int i)
    {
        var card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        card.transform.localRotation = Quaternion.Euler(90, 90, 180); // Set the desired rotation
        Debug.Log(card.transform.eulerAngles);
     
        //  card.transform.SetParent(parent, false);
        // card.GetComponent<Image>().sprite = cardInfo.cardSprite;
        cardList.Add(card);
    }
    #endregion
    private void SpawnCard(CardInfo cardInfo, int i)
    {
        //image[i].sprite = storeCardsSO.superRareCards[Random.Range(0, storeCardsSO.superRareCards.Count)].cardSprite;
        var card = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        card.transform.SetParent(parent, false);
        card.GetComponent<Image>().sprite = cardInfo.cardSprite;
        cardList.Add(card);

        if (mydic.ContainsKey(cardInfo.id))
        {
            myCollectionList[cardInfo.id - 1].total += 1;
        }

    }

    private CardInfo superRareCards()
    {
        int index = Random.Range(0, storeCardsSO.superRareCards.Count);
        return storeCardsSO.superRareCards[index];
    }
    private CardInfo rareCards()
    {
        int index = Random.Range(0, storeCardsSO.rareCards.Count);
        return storeCardsSO.rareCards[index];
    }
    private CardInfo commonCards()
    {
        int index = Random.Range(0, storeCardsSO.commonCards.Count);
        return storeCardsSO.commonCards[index];
    }
 
}
[System.Serializable]
public class MyCollection
{
    public int id;
    public int total;
}

