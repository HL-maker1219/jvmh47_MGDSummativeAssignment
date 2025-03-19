using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public float coin = 0f; // Default starting coin value
    public const string coinKey = "coinNum"; // PlayerPrefs key for storing coins
    public static bool CafeArea = false;
    public static bool MCS001 = false;
    


    // Checks if the cooldown has passed

    void Start()
    {
        // Load the saved coin value or use 0 as the default
        coin = PlayerPrefs.GetFloat(coinKey, 200f);
        Debug.Log("Coins loaded: " + coin);
    }

    public void AddMoney()
    {
        // Add money to the current coin count
        coin += 100;

        // Save the updated coin value to PlayerPrefs
        PlayerPrefs.SetFloat(coinKey, coin);
        PlayerPrefs.Save();

        Debug.Log("Coins added! Current total: " + coin);
    }

    public void MonoLisa()
    {
        if (coin >= 200) 
        {
            coin -= 200;
            Debug.Log("Purchase success!");
            PlayerPrefs.SetFloat (coinKey, coin);
            PlayerPrefs.Save();
            CafeArea = true;

        }
    }

    public void TheLastBreakfast()
    {
        if (coin >= 1000) { 
            coin -= 1000;
            Debug.Log("Purchase success!");
            PlayerPrefs.SetFloat (coinKey, coin);
            PlayerPrefs.Save();
            MCS001 = true;
        }
    }


}
