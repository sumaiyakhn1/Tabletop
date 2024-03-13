using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class functions : MonoBehaviour
{
    public static int sign(float x)
    {

        if (x < 0)
        {
            return -1;
        }
        if (x > 0)
        {
            return 1;
        }
        return 0;
    }
}


