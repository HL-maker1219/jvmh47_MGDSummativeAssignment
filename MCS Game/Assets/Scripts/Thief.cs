using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public Transform targetObject;
    public float speed;
    public float avoidForce;

    private Vector2 currentDirection;
    private bool reachedTar = false;

    
    private GameManager gameManage;

    public float coin = 0f; // Default starting coin value
    public const string coinKey = "coinNum"; // PlayerPrefs key for storing coins

    public Animator animator;


    void Start()
    {
        gameManage = FindAnyObjectByType<GameManager>();
        if (targetObject != null)
        {
            currentDirection = ((Vector2)(targetObject.position - transform.position)).normalized;
        }
    }


    void Update()
    {

        if (targetObject != null && !reachedTar)
        {
            transform.position += (Vector3)(currentDirection * speed * Time.deltaTime);
            Vector2 toTarget = ((Vector2)(targetObject.position - transform.position)).normalized;
            currentDirection = Vector2.Lerp(currentDirection, toTarget, Time.deltaTime).normalized;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Vector2 normal = collision.contacts[0].normal;
            currentDirection = Vector2.Reflect(currentDirection, normal).normalized;

            currentDirection += normal * avoidForce;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == targetObject)
        {
            reachedTar = true;
            Application.Quit();
        }
    }


    public void OnMouseDown()
    {
        if (gameManage != null)
        {
            if (gameManage.CanClick())
            {
                animator.SetBool("Die", true);
                Destroy(gameObject);
                gameManage.StartCooldown();
                coin += 10;

                // Save the updated coin value to PlayerPrefs
                PlayerPrefs.SetFloat(coinKey, coin);
                PlayerPrefs.Save();

                Debug.Log("Coins added! Current total: " + coin);
            }
            else {
                Debug.Log("Cooldown active");
            }
        }
    }
}
