using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletePrize : MonoBehaviour
{
    public List<UIPrize> rouletePrizes;

    public void ConfigUI(List<Prize> prizes)
    {
        for (int i = 0; i < rouletePrizes.Count; i++)
        {
            rouletePrizes[i].SetPrizeText(prizes[i].prizeNumber);
        }
    }
}
