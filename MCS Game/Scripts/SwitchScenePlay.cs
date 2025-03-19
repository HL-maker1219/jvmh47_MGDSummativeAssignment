using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenePlay : MonoBehaviour
{
    [SerializeField] private string Play;

    public void StartGame() { 
        SceneManager.LoadScene(Play);
        PlayerPrefs.DeleteAll();
    }
}
