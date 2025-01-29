using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCount : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.HasKey("Wins"))
        {
            PlayerPrefs.SetInt("Wins", 0);
        }
    }
}
