using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fromScene1Work : MonoBehaviour
{
    public gameManager gameM;
    public void Start()
    {
        setNoOfPlayersAtLeastOne(staticGameData.noOfPlayers);
    }
    public void setNoOfPlayersAtLeastOne(int _noOfPlayers)
    {

        if(_noOfPlayers<=0 || _noOfPlayers>6)
        {
            return;
        }

        int _loopCount = 6 - _noOfPlayers;
        for (int i = 0; i < _loopCount; i++)
        {
            int _playerIndexToDest = _noOfPlayers;

            player _playerToDest = gameM.players[_playerIndexToDest];
            gameM.players.Remove(_playerToDest);
            _playerToDest.actualDestroy();

        }
    }
}
