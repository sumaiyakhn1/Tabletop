using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class card : MonoBehaviour
{

    public Image MainColImage;
    public Text TextNumShow;
    public colorType cardType;

    public List<player> players=new List<player>();


    private void Start()
    {
        cardTypeValidCheck();
    }
    public void cardTypeValidCheck()
    {
        if(isCardTypeValid())
        {
            return;
        }
        Debug.LogWarning("hey card type is not valid",gameObject);
    }

    public void removePlayer(player _pl)
    {
        if(players.Contains(_pl))
        {
            players.Remove(_pl);
        }
    }
    public void addPlayer(player _pl)
    {
        Debug.Log("pasdasdasd");
      
        players.Add(_pl);
    }


 

    public int noAmt()
    {
        return colorTypeMan.noAmt(cardType);
    }

    public bool isCardTypeValid()
    {
        return colorTypeMan.isCardTypeValid(cardType);
    }

}
