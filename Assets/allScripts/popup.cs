using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class popup : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public UnityAction onYes;
    public UnityAction onNo;
    private void Start()
    {
        Debug.Log("popup start");
        yesButton.onClick.AddListener(yesListerner);   
        noButton.onClick.AddListener(noListener);
    }
    public void open(UnityAction _onYes,UnityAction _onNo)
    {
        onYes = _onYes;
        onNo = _onNo;
        FindObjectOfType<audiomanager>().play("popup");
        gameObject.SetActive(true);
        
    }
    public void yesListerner()
    {
        if(onYes!=null)
        {
            onYes();
        }
        close();
    }
    public void noListener()
    {
        if (onNo != null)
        {
            onNo();
        }
        close();
    }
    public void close()
    {
        gameObject.SetActive(false);

    }

}

