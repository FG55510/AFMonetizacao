using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    public int plantIndex;

    public List<PlantScriptable> plantScriptables;
    public PlantElement plantElement;

    private void Start()
    {
        plantElement.OnCollect += OnCollectPlant;
    }

    [ContextMenu("plantar")]
    public void Plant()
    {
        plantElement.Initialize(plantScriptables[plantIndex]);
    }

    public void OnCollectPlant(PlantScriptable plantScriptable)
    {
        Debug.Log($"Você coletou {plantScriptable.quantidade} {plantScriptable.NomeDoFruto}s");
    }
}
