using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> itemPrefabs;
    [SerializeField] GridSetting setting;
    int maxPositionX, maxPositionY;


    private void Start() {
        maxPositionX = setting.width;
        maxPositionY = setting.height;
        for(int i = 0; i<10; i++)
        {
            GameObject item = itemPrefabs[Random.Range(0,itemPrefabs.Count)];
            Instantiate(item, (Vector3) GenerateRandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 GenerateRandomPosition()
    {

        return new Vector2(Random.Range(1, maxPositionX-1),Random.Range(1, maxPositionY-1));
    }
}
