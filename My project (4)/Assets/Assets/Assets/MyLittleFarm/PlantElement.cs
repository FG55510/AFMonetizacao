using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantElement : MonoBehaviour
{
    public Image plantImage;
    public Button button;
    public Slider countdownSlider;
    public TMP_Text countdownText;
    public CanvasGroup canvasGroup;

    private int tempoDeCrescimento = 0;

    public PlantScriptable plantScriptable;
    public Action<PlantScriptable> OnCollect;

    private void Start()
    {
        canvasGroup.alpha = 0;
    }

    public void Initialize(PlantScriptable plantScriptable)
    {
        button.onClick.RemoveAllListeners();
        this.plantScriptable = plantScriptable;
        plantImage.sprite = plantScriptable.sprite;
        tempoDeCrescimento = plantScriptable.tempoDeCrescimento;
        canvasGroup.alpha = 1;

        StartPlant();
    }

    public void StartPlant()
    {
        StartCoroutine(GrownPlant());
    }

    private IEnumerator GrownPlant()
    {
        float StartTime = Time.time;

        while (tempoDeCrescimento > Time.time - StartTime)
        {
            countdownSlider.value = (Time.time - StartTime) / tempoDeCrescimento;

            float tempoRestante = tempoDeCrescimento - (Time.time - StartTime);

            var timeSpam = TimeSpan.FromSeconds(tempoRestante);
            countdownText.text = $"{timeSpam.Minutes}:{timeSpam.Seconds}";
                
            yield return null;
        }
        button.onClick.AddListener(() => Collect());
    }

    public void Collect()
    {
        canvasGroup.alpha = 0;
        button.onClick.RemoveAllListeners();

        OnCollect?.Invoke(plantScriptable);
    }
}
