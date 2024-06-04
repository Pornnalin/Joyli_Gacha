using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySystem : MonoBehaviour
{
    public int userCoin;
    public GameObject openCardPanel;
    public GameObject buyPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyCard()
    {
        userCoin -= 100;
        openCardPanel.SetActive(true);
        buyPanel.SetActive(false);
    }
}
