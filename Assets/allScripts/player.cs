using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    public int currentPos = 0;
    public int playerNumber;
    public string playerName;
    public gameManager gameM;
    public Image mainColorImg;
     helper helperr;
     List<card> cards;
    private void Start()
    {
        cards = gameM.cards;
        helperr = gameM.helperr;
    }
    public Color playerColor()
    {
        return mainColorImg.color;
    }
    public void moveStep(int _toMove,UnityAction _onActualMove,UnityAction _onNoMove)
    {
        Debug.Log(" move step called");
        if (_toMove == 0)
        {
            Debug.Log("movement done didnt moved");
            if (_onNoMove != null)
            {
                _onNoMove();
            }
            return;
        }
        if ( currentPos+_toMove>cards.Count)
        {
            _toMove = 0;
            properMoveStep(_toMove, _onActualMove,_onNoMove);
            return;
        }

        if(currentPos+_toMove<=0)
        {
            _toMove = 1 - currentPos;
            properMoveStep(_toMove, _onActualMove, _onNoMove);
            return;
        }
        properMoveStep(_toMove, _onActualMove, _onNoMove);



    }

    public void properMoveStep(int _toMove, UnityAction _onActualMove, UnityAction _onNoMove)
    {
        if(_toMove==0)
        {
            Debug.Log("movement done didnt moved");
            if(_onNoMove!=null)
            {
                _onNoMove();
            }
            return;
        }
        if(currentPos!=0)
        {
            landCard().removePlayer(this);
            helperr.setPosForAll(landCard());
        }
        StartCoroutine( moveQuaran( _toMove, _onActualMove));
    }

    public IEnumerator moveQuaran(int _toMove, UnityAction _onActualMove)
    {

        int _dir = functions.sign(_toMove);
        Debug.Log("dir =" + _dir);
        while (true)
        {
            yield return new WaitForSeconds(gameM.aliveTime);

            FindObjectOfType<audiomanager>().alwaysplay("playerMove");
            Debug.Log("quaranIsRunning");

            currentPos += _dir;
            helperr.setNormalTransOnCard(transform, landCard().transform);
            _toMove -= _dir;
            if(_toMove==0)
            {
                Debug.Log("movement done did moved");
                landCard().addPlayer(this);
                helperr.setPosForAll(landCard());
                if(_onActualMove!=null)
                {
                    _onActualMove();
                }
                break;
            }
        }
      

    }

    public card landCard()
    {
        return cards[landCardIndex()];
    }
    public int landCardIndex()
    {
        int _r= currentPos - 1;
        return _r;
    }
    public void moveBasedOnNoAmt(UnityAction _onActualMove, UnityAction _onNoMove)
    {
        int _amtToMove = -landCard().noAmt();
        moveStep(_amtToMove, _onActualMove, _onNoMove);
    }

    public void removeFromLandCardAndUpdatePos()
    {
        card _landCard = landCard();
        _landCard.removePlayer(this);
        helperr.setPosForAll(_landCard);
    }
    
    public void actualDestroy()
    {
        Destroy(gameObject);
    }
    

}
