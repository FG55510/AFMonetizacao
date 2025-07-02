using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public List<MemoryGameElementUI> memoryGameElementUIs;
    public List<MemorygameElement> memorygameElements;

    public int clickedCard = 0;

    private List<MemoryGameElementUI> elementUIsShow;
    private void Start()
    {
        elementUIsShow = new List<MemoryGameElementUI> ();

        HideAll();

        InitializeGame();
    }

    public void InitializeGame()
    {
        int j = 0;

        System.Random rng = new System.Random();
        memoryGameElementUIs = new List<MemoryGameElementUI>(memoryGameElementUIs.OrderBy(x => rng.Next()).ToList());

        for (int i = 0; i < memoryGameElementUIs.Count; i = i+2)
        {
            memoryGameElementUIs[i].Initialize(memorygameElements[j]);
            memoryGameElementUIs[i+1].Initialize(memorygameElements[j]);

            memoryGameElementUIs[i].OnClicked += CheckClickedCards;
            memoryGameElementUIs[i].OnOpen += OnTwoCardsShow;

            memoryGameElementUIs[i+1].OnClicked += CheckClickedCards;
            memoryGameElementUIs[i+1].OnOpen += OnTwoCardsShow;
            j++;
        }
    }

    public void HideAll()
    {
        memoryGameElementUIs.ForEach(x => x.HideIcon());
    }

    public void CheckClickedCards()
    {
        clickedCard++;
    }

    public void OnTwoCardsShow(MemoryGameElementUI elementUI)
    {
        elementUIsShow.Add(elementUI);

        if (clickedCard >= 2)
        {
            VerifyMatch();
            HideAll();
            clickedCard = 0;
        }
    }

    private void VerifyMatch()
    {
        if (elementUIsShow.Count > 1)
            if (elementUIsShow[0].id == elementUIsShow[1].id)
            {
                elementUIsShow[0].SetIsMath();
                elementUIsShow[1].SetIsMath();
            }
        elementUIsShow.Clear();
    }
}