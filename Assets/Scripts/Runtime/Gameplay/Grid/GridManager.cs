using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    private GridSetting setting;

    [SerializeField] 
    private GameObject prefabTile;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateGrid()
    {
        for(int i=0;i < setting.width; i++)
        {
            for (int j = 0; j < setting.height; j++)
            {
                GameObject newTile = Instantiate<GameObject>(prefabTile);
                newTile.transform.position = new Vector3(i, j, 0);
            }
        }
    }
}
