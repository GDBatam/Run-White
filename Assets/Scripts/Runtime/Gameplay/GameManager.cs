using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> snakePart;
    public Transform startingPosition;
    public SnakeController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller.snake.Add(Instantiate(snakePart[0], startingPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}