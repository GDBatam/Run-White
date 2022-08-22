using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _iterateTimer = 0.5f;

    [Header("snake")]
    [SerializeField] private GameObject _head;

    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private List<GameObject> _bodies = new List<GameObject>();

    [SerializeField] private GameObject _tail;

    private float _currentTimer = 0f;

    #endregion

    #region Properties

    public bool CanUpdateInput { get; set; } = true;

    public bool CanMove { get; set; }

    #endregion

    #region Methods

    public void ExtendBody(ConsumableInfo info)
    {
        GameObject tmp;
        for(int i = 0; i<info.extend; i++){
            tmp = Instantiate(_bodyPrefab,(Vector2) _head.transform.position, Quaternion.identity);
            _bodies.Add(tmp);
    
            UpdateSnakeFullBody();
        }

        _iterateTimer -= _iterateTimer * info.increaseSpeed;
    }

    private void UpdateSnakeFullBody()
    {
        // hold head previous position.
        Vector3 headPreviousPosition = _head.transform.position;

        // head
        Vector3 headPosition = _head.transform.position;
        Vector3 headTargetPosition = headPosition;
        _head.transform.position = headTargetPosition;

        Vector3 bodyNextPosition = headPreviousPosition;

        // bodies
        Vector3 bodyPreviousPosition;

        int count = _bodies.Count;
        for (int i = 0; i < count; i++)
        {
            bodyPreviousPosition = _bodies[i].transform.position;
            //update current body position
            _bodies[i].transform.position = bodyNextPosition;

            //update next body position
            bodyNextPosition = bodyPreviousPosition;

        }

        _tail.transform.position = bodyNextPosition;
    }

    private void UpdatePosition()
    {
        if (!CanMove)
        {
            return;
        }

        // CanMove is true, so snake can update position.
        if (_currentTimer >= _iterateTimer)
        {
            // hold head previous position.
            Vector3 headPreviousPosition = _head.transform.position;

            // head
            Vector3 headPosition = _head.transform.position;
            Vector3 headTargetPosition = headPosition + GameManager.Singleton.Direction;
            _head.transform.position = headTargetPosition;

            Vector3 bodyNextPosition = headPreviousPosition;

            // bodies
            Vector3 bodyPreviousPosition;

            int count = _bodies.Count;
            for (int i = 0; i < count; i++)
            {
                bodyPreviousPosition = _bodies[i].transform.position;
                //update current body position
                _bodies[i].transform.position = bodyNextPosition;

                //update next body position
                bodyNextPosition = bodyPreviousPosition;

            }

            _tail.transform.position = bodyNextPosition;

            CanUpdateInput = true;

            _currentTimer = 0f;
        }
    }

    #endregion

    #region Build-in Methods

    // Update is called once per frame
    private void Update()
    {
        _currentTimer += Time.deltaTime;

        UpdatePosition();
    }

    #endregion
}
