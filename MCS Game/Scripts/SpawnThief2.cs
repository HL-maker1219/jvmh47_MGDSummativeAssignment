using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThief2 : MonoBehaviour
{
    public GameObject ThiefPrefab;
    public float spawnInterval = 0.5f;
    public Transform Target;
    private bool active = false;
    private bool CafeArea;
    private bool MCS001;

    void Start()
    {


    }

    void Update()
    {
        CafeArea = StoreManager.CafeArea;
        GameManager GameManager = FindObjectOfType<GameManager>();
        if (GameManager.gameStart == true && active == false && CafeArea == true)
        {
            InvokeRepeating(nameof(spawnThief), 0f, spawnInterval);
            active = true;
            Debug.Log(CafeArea);
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

