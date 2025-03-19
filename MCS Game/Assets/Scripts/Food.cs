using UnityEngine;

public class Food : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Find and reference the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {
        DestroyFood();
    }

    private void DestroyFood()
    {
        Debug.Log("Food clicked and destroyed!");

        // Clear the cooldown in GameManager
        if (gameManager != null)
        {
            gameManager.ClearCooldown();
        }

        // Destroy this food object
        Destroy(gameObject);
    }
}
