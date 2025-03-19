using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThief : MonoBehaviour
{
    public GameObject ThiefPrefab; 
    public float spawnInterval; 
    public Transform Target;
    private bool active = false;
    private bool CafeArea;
    private bool MCS001;

    void Start()
    {
        if (Difficulty.difficulty == 2) 
        {
            spawnInterval = 6;
        }
        if (Difficulty.difficulty == 1)
        {
            spawnInterval = 8;
        }

    }

    void Update()
    {
        MCS001 = StoreManager.MCS001;
        GameManager GameManager = FindObjectOfType<GameManager>();
        if (GameManager.gameStart == true && active == false && MCS001 == true)
        {
            InvokeRepeating(nameof(spawnThief), 0f, spawnInterval);
            active = true;
            Debug.Log(MCS001);
        }
    }

    private void spawnThief()
    {
        GameObject spawnedThief = Instantiate(ThiefPrefab, transform.position, transform.rotation);

        Thief thiefScript = spawnedThief.GetComponent<Thief>();
        if (thiefScript != null)
        {
            thiefScript.targetObject = Target;
        }
    }
}
