using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorTypeMan : MonoBehaviour
{
    public Color myRed;
    public Color myGreen;
    public Color myBlue;



    public Color getColorFromType(colorType _colType)
    {
        if(_colType==colorType.red)
        {
            return myRed;
        }
        if (_colType == colorType.green)
        {
            return myGreen;
        }
        if(_colType==colorType.blue)
        {
            return myBlue;
        }
        if (_colType == colorType.specialRed)
        {
            return myRed;
        }

        return myRed;

    }

    public static int noAmt(colorType _colType)
    {
        if (_colType == colorType.red)
        {
            return 1;
        }
        if (_colType == colorType.green)
        {
            return 2;
        }
        if (_colType == colorType.blue)
        {
            return 3;
        }
        if (_colType == colorType.specialRed)
        {
            return 1;
        }

        return 1;
    }

    public static bool isCardTypeValid(colorType _colType)
    {
        if (_colType == colorType.red)
        {
            return true;
        }
        if (_colType == colorType.green)
        {
            return true;
        }
        if (_colType == colorType.blue)
        {
            return true;
        }
        if (_colType == colorType.specialRed)
        {
            return true;
        }

        return false;
    }
}
