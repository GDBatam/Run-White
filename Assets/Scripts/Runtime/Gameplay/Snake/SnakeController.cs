using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public Transform position;

    public GameObject skin;
}


public class SnakeController : MonoBehaviour
{
    List<GameObject> targetGrid;
    public List<GameObject> snake;

    public List<Entity> snakes = new List<Entity>();

    public void SetVector2(Vector2 targetPosition)
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
