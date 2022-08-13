using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public Transform position;

    public GameObject skin;
}

public class PartPosition
{
    public Vector3 currentPosition;

    public Vector3 targetPosition;
}


public class SnakeController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float iterateTimer = 0.5f;

    private float currentTimer = 0f;

    List<GameObject> targetGrid;

    public List<GameObject> snake;

    public List<Entity> snakes = new List<Entity>();

    public Vector2Int direction = new Vector2Int();

    public float speed = 1;

    private List<PartPosition> partsTargetPosition = new List<PartPosition>();

    #endregion

    #region Methods

    public void SetVector2(Vector2 targetPosition)
    {
        
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (direction != Vector2Int.down)
            {
                direction = Vector2Int.up;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (direction != Vector2Int.right)
            {
                direction = Vector2Int.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (direction != Vector2Int.up)
            {
                direction = Vector2Int.down;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (direction != Vector2Int.left)
            {
                direction = Vector2Int.right;
            }
        }
    }

    private void ProcessPosition()
    {
        if (currentTimer >= iterateTimer)
        {
            // head
            Vector3Int currentPosition = new Vector3Int((int) transform.position.x, (int) transform.position.y, (int) transform.position.z);
            Vector3Int targetPosition = currentPosition + (Vector3Int) direction;

            // head
            partsTargetPosition[0] = new PartPosition()
            {
                currentPosition = currentPosition,
                targetPosition = targetPosition
            };

            currentTimer = 0f;
        }
    }

    private void UpdatePosition()
    {
        // count = 1 ( head )
        for (int i = 0; i < partsTargetPosition.Count; i++)
        {
            transform.position = Vector3.Lerp(partsTargetPosition[i].currentPosition, partsTargetPosition[i].targetPosition, speed * Time.deltaTime);
        }
    }

    #endregion

    #region Build-in Methods

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        currentTimer += Time.deltaTime;

        DetectInput();
        ProcessPosition();
        UpdatePosition();
    }

    #endregion
}
