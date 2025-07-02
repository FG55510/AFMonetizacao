using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPrize : MonoBehaviour
{
    public int prizeID;
    public TMP_Text prizeNumber;
    public Image iconPrize;

    public void SetPrizeText(float prize)
    {
        prizeNumber.text = prize.ToString();
    }

    public void SetPrizeText(int newId, Sprite prize)
    {
        prizeID = newId;
        iconPrize.sprite = prize;
    }

}
