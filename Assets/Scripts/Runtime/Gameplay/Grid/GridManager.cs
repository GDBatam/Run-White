using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int x;

    public int y;

    public GameObject prefab;
}

public class GridManager : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private GridSetting setting;

    [SerializeField] 
    private GameObject prefabTile;

    private Tile[,] tiles;

    #endregion

    #region Properties

    public static GridManager Singleton { get; private set; }

    #endregion

    #region Methods

    public void GetPosition()
    {
        
    }

    private void GenerateGrid()
    {
        tiles = new Tile[setting.width, setting.height];

        for(int i=0;i < setting.width; i++)
        {
            for (int j = 0; j < setting.height; j++)
            {
                GameObject newTile = Instantiate<GameObject>(prefabTile);
                newTile.transform.position = new Vector3(i, j, 0);
                newTile.name = $"Tile {i}-{j}";

                tiles[i,j] = new Tile()
                {
                    x = i,
                    y = j,
                    prefab = newTile
                }; 
            }
        }
    }

    #endregion
    
    #region Build-in Methods
    
    private void Awake()
    {
        if (Singleton != this && Singleton != null)
        {
            Destroy(gameObject);
        }

        Singleton = this;
    }

    //// Start is called before the first frame update
    private void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    #endregion
}