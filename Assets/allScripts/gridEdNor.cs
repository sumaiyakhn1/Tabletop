using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gridEdNor : MonoBehaviour
{

    int currnet = 0;
    public gameManager gameM;
    public colorTypeMan colTypeManagerr;
    public Vector3 refCordInitial;
    Vector3 refCord;
    public Vector3 refScale;
    List<card> cards;
    public GameObject toInstForNowUseLess;

    public void create()
    {
        Debug.Log("create clicked");
        cards = gameM.cards;
        currnet = 0;
        refCord = refCordInitial;

        //  tile45MinePhoto();
        mySpiral();
        Debug.Log(currnet);
    }
    
    public void wierdDesignForNowMaybe()
    {
        gridSetPosAll(45, Vector3.right);

    }
    public void tile9MineNormal()
    {
        gridSetPosAll(3, Vector3.right);
        gridSetPosAll(1, Vector3.down);
        gridSetPosAll(2, Vector3.left);
        gridSetPosAll(1, Vector3.down);
        gridSetPosAll(2, Vector3.right);
    }

    public void tiles45Photo1()
    {
        gridSetPosAll(3, Vector3.down);
        gridSetPosAll(6, Vector3.right);
        gridSetPosAll(2, Vector3.down);
        gridSetPosAll(3, Vector3.left);
        gridSetPosAll(2, Vector3.down);
        gridSetPosAll(3, Vector3.right);

        gridSetPosAll(3, Vector3.down);

        gridSetPosAll(2, Vector3.left);

        gridSetPosAll(2, Vector3.up);

        gridSetPosAll(2, Vector3.left);

        gridSetPosAll(2, Vector3.up); // 30

        gridSetPosAll(2, Vector3.left);

        gridSetPosAll(3, Vector3.down);

        gridSetPosAll(2, Vector3.right);

        gridSetPosAll(2, Vector3.up);

        gridSetPosAll(2, Vector3.right);

        gridSetPosAll(2, Vector3.down);

        gridSetPosAll(2, Vector3.right);





    }

    public void tiles45Photo2()
    {
        gridSetPosAll(6, Vector3.down);
        gridSetPosAll(6, Vector3.right);//12
        gridSetPosAll(3, Vector3.down);
        gridSetPosAll(3, Vector3.left);
        gridSetPosAll(3, Vector3.down);
        gridSetPosAll(3, Vector3.right);//12

        gridSetPosAll(3, Vector3.down); 

        gridSetPosAll(3, Vector3.left);

        gridSetPosAll(2, Vector3.up); 

        gridSetPosAll(3, Vector3.left); // 11

        gridSetPosAll(3, Vector3.up);

        gridSetPosAll(3, Vector3.left);

        gridSetPosAll(4, Vector3.down);  // 10


    }

    public void tile45MinePhoto()
    {
        gridSetPosAll(5, Vector3.down);
        gridSetPosAll(14, Vector3.right);


        gridSetPosAll(2, Vector3.down);

        gridSetPosAll(14, Vector3.left);

        gridSetPosAll(2, Vector3.down);
        gridSetPosAll(14, Vector3.right);

    }

    public void mySpiral()
    {
        int i = 1;
        int[] _spiralNums = new int[10];
        _spiralNums[1] = 8;
        _spiralNums[2] = 9;
        _spiralNums[3] = _spiralNums[1]-1;
        _spiralNums[4] = 6;
        _spiralNums[5] = 5;
        _spiralNums[6] = 4;
        _spiralNums[7] = 3;
        _spiralNums[8] = 5;
        _spiralNums[9] = 3;



        _spiralNums[0] = 0;
        gridSetPosAll(_spiralNums[i], Vector3.down);
        i += 1;

        gridSetPosAll(_spiralNums[i], Vector3.right);
        i += 1;

        gridSetPosAll(_spiralNums[i], Vector3.up);
        i += 1;

        gridSetPosAll(_spiralNums[i], Vector3.left);
        i += 1;

        gridSetPosAll(_spiralNums[i], Vector3.down);
        i += 1;

        gridSetPosAll(_spiralNums[i], Vector3.right);
        i += 1;

        gridSetPosAll(_spiralNums[i], Vector3.up);
        i += 1;

        /*  gridSetPosAll(_spiralNums[i], Vector3.left);
          i += 1;


          gridSetPosAll(_spiralNums[i], Vector3.down);
          i += 1;*/
        gridSetPosAll(2,Vector3.left);
        gridSetPosAll(1,Vector3.down);


    }
    public void gridSetPosAll(int _cardNums,Vector3 _dir)
    {
       
        for (int i = 0; i < _cardNums; i++)
        {
            if(currnet+i>=cards.Count)
            {
                Debug.Log("we once reutruned while creating");
                return;
            }
            RectTransform _cardToEffect = cards[currnet+i].GetComponent<RectTransform>();
            Vector3 _v = refCord + Vector3.Scale( refScale,_dir)*(i+1);
            _cardToEffect.anchoredPosition = new Vector2(_v.x,_v.y);
        }

        refCord = refCord + Vector3.Scale(refScale,_dir)*_cardNums;
        currnet = currnet+ _cardNums;
    }




}
