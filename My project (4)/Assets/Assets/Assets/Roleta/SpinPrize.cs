using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPrize : MonoBehaviour
{
    public List<Prize> prizeList;
    public Roulete roulete;
    public RouletePrize rouletePrizes;
    public float prizeAngle;

    private void Awake()
    {
        prizeAngle = 360 / prizeList.Count;

        roulete.OnStopTurnig += VerifyPrize;

        rouletePrizes.ConfigUI(prizeList);
    }

    private void OnDestroy()
    {
        roulete.OnStopTurnig -= VerifyPrize;
    }

    public void VerifyPrize(float angle)
    {
        int prizeIndex =  Mathf.RoundToInt( angle / prizeAngle);

        if (angle / prizeAngle > prizeIndex) prizeIndex++;

        Debug.Log("PRIZE INDEX : " + prizeIndex + "O PREMIO FOI : " + prizeList[prizeIndex-1].name);
    }
}