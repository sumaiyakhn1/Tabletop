using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public popup goBackPopup;
    public Button goBackButton;
    private void Start()
    {
        goBackButton.onClick.AddListener(onButtonClick);
    }
    public void onButtonClick()
    {
        Debug.Log("main menu go back click");
        goBackButton.gameObject.SetActive(false);
        goBackPopup.open(onYesGoBackPopup,onNoGoBackPopup);
       
    }
    public void onYesGoBackPopup()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void onNoGoBackPopup()
    {
        goBackButton.gameObject.SetActive(true);

    }
}
