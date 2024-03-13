using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class diceRoller : MonoBehaviour
{
    public Button rollDiceButton;
    public Image outLineImage;
    public float spriteChangeTime;
    public float spriteDuration;
    public gameManager gameM;
    public Image mainImage;
    public List<Sprite> diceImages;
    public bool followMine;
    public int mineNumber;
    public int diceNumber;
    public UnityAction rollButtonAction;

    private void Start()
    {
        rollButtonAction = initialAction;
        rollDiceButton.onClick.AddListener(  rollButtonClick  );
    }
    public void rollButtonClick()
    {
        if(rollButtonAction!=null)
        {
            Debug.Log("roll action  is clicked");
            rollButtonAction();
        }
    }


    
    public void initialAction()
    {
        rollButtonAction = null;
        gameM.onRollInitialClick();
        FindObjectOfType<audiomanager>().play("rollStart");
        outLineImage.enabled = false;
        StartCoroutine(quaranRoll(actualRoll));
    }

    public void actualRoll()
    {
        int _index = 0;
        if (followMine)
        {
            _index = mineNumber-1;
        }
        else
        {
            _index = Random.Range(0, 6);
        }
        Debug.Log("dice rolled " + _index);
        diceNumber = _index + 1;
        mainImage.sprite = diceImages[_index];
        gameM.diceRollComp();
    }
    public IEnumerator quaranRoll(UnityAction _onQuaranEnd)
    {
        float _timePassed = 0;
        while (true)
        {

            yield return new WaitForSeconds(spriteChangeTime);
            _timePassed += spriteChangeTime;
            if (_timePassed >= spriteDuration)
            {
                if(_onQuaranEnd!=null)
                {
                    _onQuaranEnd();
                }

                break;
            }
            else
            {
                int _index = Random.Range(0, 6);
                mainImage.sprite = diceImages[_index];

            }

        }
       

    }
    public void activateButton()
    {
        FindObjectOfType<audiomanager>().play("rollActive");
        rollButtonAction = initialAction;
        outLineImage.enabled = true;

    }
}
