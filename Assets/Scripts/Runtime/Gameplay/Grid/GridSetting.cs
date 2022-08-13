using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridSettings", menuName ="Setting/Grid",order=0)]
public class GridSetting : ScriptableObject
{
    public int width, height;
}
