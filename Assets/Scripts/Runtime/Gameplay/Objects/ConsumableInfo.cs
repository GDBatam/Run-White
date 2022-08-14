using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableData", menuName = "Consumable/Data", order = 0)]
public class ConsumableInfo : ScriptableObject
{
    public ConsumableType type;
    public float increaseSpeed = 0.3f;
    public int extend;
}
