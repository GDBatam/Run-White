using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private SnakeController controller;

    //public List<GameObject> snakePart;
    //public Transform startingPosition;
    //public SnakeController controller;

    #endregion

    #region Properties

    public static GameManager Singleton { get; private set; }

    public Vector3Int Direction { get; private set; }

    #endregion

    #region Methods

    private void MoveSnake()
    {
        controller.CanMove = true;
        controller.CanUpdateInput = false;
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

    // Start is called before the first frame update
    private void Start()
    {
        // controller.snake.Add(Instantiate(snakePart[0], startingPosition));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && controller.CanUpdateInput)
        {
            // make sure the user doesn't move backwards
            if (Direction != Vector3Int.down)
            {
                Direction = Vector3Int.up;

                MoveSnake();
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && controller.CanUpdateInput)
        {
            // make sure the user doesn't move backwards
            if (Direction != Vector3Int.left)
            {
                Direction = Vector3Int.right;

                MoveSnake();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && controller.CanUpdateInput)
        {
            // make sure the user doesn't move backwards
            if (Direction != Vector3Int.up)
            {
                Direction = Vector3Int.down;

                MoveSnake();
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && controller.CanUpdateInput)
        {
            // make sure the user doesn't move backwards
            if (Direction != Vector3Int.right)
            {
                Direction = Vector3Int.left;

                MoveSnake();
            }
        }
    }

    #endregion
}
