using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StoreCardsSO", menuName = "ScriptableObjects/StoreCardsSO", order = 1)]
public class StoreCards : ScriptableObject
{
    public List<CardInfo> commonCards;
    public List<CardInfo> rareCards;
    public List<CardInfo> superRareCards;
    //  public Sprite sss;

    [ContextMenu("SortID")]
    public void SortID()
    {
        for (int i = 0; i < commonCards.Count; i++)
        {
            commonCards[i].id = i + 1;

            for (int j = 0; j < rareCards.Count; j++)
            {
                rareCards[j].id = i + j + 2;

                for (int k = 0; k < superRareCards.Count; k++)
                {
                    superRareCards[k].id = i + j + k + 3;
                }
            }
        }
    }
}
[System.Serializable]
public class CardInfo
{
    public int id;
    public Sprite cardSprite;
    public Material material;
}