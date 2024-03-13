using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class diceScene1 : MonoBehaviour
{
    public int numberToSend;

    public Button mainButton;

    private void Start()
    {
        mainButton.onClick.AddListener(onButtonClick);
    }
    public void onButtonClick()
    {
        staticGameData.noOfPlayers = numberToSend;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
