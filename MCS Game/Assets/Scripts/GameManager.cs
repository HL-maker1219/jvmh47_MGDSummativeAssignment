using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float clickCooldown = 1.0f; // Cooldown time in seconds
    private float nextAvailableClickTime = 0f; // Time until next valid click
    public bool gameStart = false;


    // Checks if the cooldown has passed
    public bool CanClick()
    {
        return Time.time >= nextAvailableClickTime;
    }

    public void StartCooldown()
    {
        nextAvailableClickTime = Time.time + clickCooldown;
    }

    public void ClearCooldown()
    {
        Debug.Log("Cooldown cleared!");
        nextAvailableClickTime = 0f;
    }

    public void StartPlay() { 
        gameStart = true;
    }
}
