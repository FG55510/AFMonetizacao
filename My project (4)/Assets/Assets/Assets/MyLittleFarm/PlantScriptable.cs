using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Farm/Plant")]
public class PlantScriptable : ScriptableObject
{
    public Sprite sprite;
    public int tempoDeCrescimento;

    public string NomeDoFruto;
    public int quantidade;
}
