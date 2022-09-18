using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> itemPrefabs;
    [SerializeField] GridSetting setting;
    [SerializeField] private Transform transformX, transformY;
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
        float randomX = Random.Range(transformX.position.x, transformY.position.x);
        float randomY = Random.Range(transformX.position.y, transformY.position.y);

        return new Vector2(randomX, randomY);
    }
}
