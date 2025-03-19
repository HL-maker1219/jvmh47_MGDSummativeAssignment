using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public static float difficulty;

    public void Easy() 
    {
        difficulty = 0;
    }

    public void Normal()
    {
        difficulty = 1;
    }

    public void Hard()
    {
        difficulty = 2;
    }
}
