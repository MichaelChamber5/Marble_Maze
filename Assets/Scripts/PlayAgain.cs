using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayAgain : MonoBehaviour
{

    [SerializeField] TMP_Text winCountText;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Wins"))
        {
            PlayerPrefs.SetInt("Wins", PlayerPrefs.GetInt("Wins") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Wins", 1);
        }
        winCountText.text = "Puzzles Solved: " + PlayerPrefs.GetInt("Wins");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    void OnResetCount()
    {
        PlayerPrefs.SetInt("Wins", 0);
        winCountText.text = "Puzzles Solved: " + PlayerPrefs.GetInt("Wins");
    }
}
