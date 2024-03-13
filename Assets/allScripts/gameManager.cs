using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public helper helperr;
    public List<card> cards;
    public List<player> players;
    public float aliveTime;
    int currentPlayerIndex=0;
    public diceRoller diceRollerr;
    public Text whoseTurnText;
    public GameObject winTextCont;
    public Text winingText;
    public popup popupp;

    private void Start()
    {
        updateTextTurn();
    }

    public void diceRollComp()
    {
        Debug.Log("roll comp");
        currentPlayer().moveStep(diceRollerr.diceNumber,onActualMove,onNoMove);
        void onActualMove()
        {
            popupp.open(popupYes,popupNo);
        }
        void onNoMove()
        {
            simpleNextTurn();
        }
    }
    public void updateTextTurn()
    {
        whoseTurnText.text ="Team "+currentPlayer().playerNumber.ToString()+" "+ currentPlayer().playerName + "'s turn";
        whoseTurnText.color = currentPlayer().playerColor();
    }
    public void updateTextWin()
    {
        winingText.text ="Team "+ currentPlayer().playerNumber + " "+ currentPlayer().playerName + " wins";
        winingText.color = currentPlayer().playerColor();
    }
    public void popupYes()
    {
        FindObjectOfType<audiomanager>().play("smallSuccess");
        if(currentPlayer().currentPos==cards.Count)
        {
            forWin();
            return;
        }
        simpleNextTurn();
    }


    public void forWin()
    {


       

        updateTextWin();
        winTextCont.SetActive(true);


        player _currentPlayer = currentPlayer();
        FindObjectOfType<audiomanager>().alwaysplay("win");
        _currentPlayer.removeFromLandCardAndUpdatePos();
        players.Remove(_currentPlayer);
        _currentPlayer.actualDestroy();


        if(players.Count==0)
        {
            Debug.Log("the game has ended");
            return;

        }

        if (currentPlayerIndex<players.Count)
        {
            // at such index something is present which is the next player so no index change
        }
        else
        {
            currentPlayerIndex = 0;
        }

        updateTextTurn();
        diceRollerr.activateButton();

    }

   public void onRollInitialClick()
    {

        winTextCont.SetActive(false);

    }

    public void popupNo()
    {
        FindObjectOfType<audiomanager>().play("fail");
        currentPlayer().moveBasedOnNoAmt(simpleNextTurn,simpleNextTurn);
    }
    void simpleNextTurn()
    {
   

        currentPlayerIndex += 1;
        if (currentPlayerIndex >= players.Count)
        {
            currentPlayerIndex = 0;

        }
        updateTextTurn();
        diceRollerr.activateButton();
    }

    public player currentPlayer()
    {
        return players[currentPlayerIndex];
    }
}
