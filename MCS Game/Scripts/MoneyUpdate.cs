using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUpdate : MonoBehaviour
{
    public TextMeshProUGUI moneyText; 
    public StoreManager storeManager;  

    void Update()
    {
       
        moneyText.text =  storeManager.coin.ToString();
    }


}
