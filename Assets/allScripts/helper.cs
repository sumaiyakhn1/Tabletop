using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class helper : MonoBehaviour
{
    public gameManager gameM;
    public List<vecList> veclists;
    public List<float> sizes;
    public void setNormalTransOnCard(Transform _t, Transform cardTransForm)
    {

        setSinglePos(_t, cardTransForm);
        _t.SetAsLastSibling();
        _t.localScale = new Vector2(sizes[0],sizes[0]);
    }

    void setSinglePos(Transform _t, Transform cardTransForm)
    {
        _t.position = cardTransForm.position;
    }

/*    void setForBelow2(card _card)
    {
        Vector3 _v = new Vector3(1, 0, 0) * amt;

        Debug.Log("hahaa");
        _card.players[0].GetComponent<RectTransform>().position = _card.GetComponent<RectTransform>().position - _v;
        _card.players[1].GetComponent<RectTransform>().position = _card.GetComponent<RectTransform>().position + _v;




    }
    void setForBelow3(card _card)
    {
        Vector3 _v = new Vector3(1, 0, 0) * amt1;


        _card.players[0].GetComponent<RectTransform>().position = _card.GetComponent<RectTransform>().position - _v;
        _card.players[1].GetComponent<RectTransform>().position = _card.GetComponent<RectTransform>().position;
        _card.players[2].GetComponent<RectTransform>().position = _card.GetComponent<RectTransform>().position + _v;



    }*/


    void setSizes(card _card)
    {
        Vector3 _sizeToSet = new Vector3( sizes[_card.players.Count-1], sizes[_card.players.Count-1],1);
        for (int i = 0; i < _card.players.Count; i++)
        {
            Transform _current = _card.players[i].transform;

            _current.localScale = _sizeToSet;
            

        }
    }
    void setPoses(card _card)
    {
        List<Vector3> _listToFollow = veclists[_card.players.Count-1].vecs;
        for (int i = 0; i < _card.players.Count; i++)
        {
            RectTransform _current = _card.players[i].GetComponent<RectTransform>();

            _current.anchoredPosition = _card.GetComponent<RectTransform>().anchoredPosition + new Vector2( _listToFollow[i].x,_listToFollow[i].y);


        }
    }


    public void setPosForAll(card _card)
    {

        Debug.Log("setAL"+_card.players.Count);
        if(_card.players.Count==0)
        {
            return;
        }
        setSizes(_card);
        setPoses(_card);
/*       if(_card.players.Count==0)
        {
            return;
        }    

        if(_card.players.Count==1)
        {
            setSinglePos(_card.players[0].transform,_card.transform);
            return;
        }
        if(_card.players.Count==2)
        {
            setForBelow2(_card);
            return;
        }
        if (_card.players.Count == 3)
        {
            setForBelow3(_card);
            return;
        }*/
    }

 
}
