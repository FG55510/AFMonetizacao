using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SpinPrize/Prize")]
public class Prize: ScriptableObject
{
    public int prizeID;
    public float prizeNumber;
    public Sprite iconPrize;
}
