using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBehaviour : MonoBehaviour
{
    #region Fields

    [SerializeField] private LayerMask ratLayer;

    [SerializeField] private float _iterateTimer = 0.5f;

    private float _currentTimer = 0;

    private Vector2Int[] randomDirection =
    {
        Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down
    };

    private Vector2Int _gizmosDirection;

    private Vector2 _targetDirection;

    private Vector2 _previousDirection;

    private bool _canMove;

    #endregion

    #region Properties



    #endregion

    #region Methods

    private void RandomDirection()
    {
        int random = Random.Range(0, randomDirection.Length);
        _targetDirection = randomDirection[random];
    }

    private void ShuffleRandomDirection()
    {
        int count = randomDirection.Length;

        for(int i = 0; i < count; i++)
        {
            Vector2Int tmp = randomDirection[i];
            int randomInt = Random.Range(0, count);
            Vector2Int rand = randomDirection[randomInt];
            randomDirection[i] = rand;
            randomDirection[randomInt] = tmp;
            
        }
    }

    private Vector2Int CheckCollider()
    {
        for(int i = 0; i<4; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, randomDirection[i], 2);
            if(!hit.collider.CompareTag("Snake") || !hit.collider.CompareTag("Wall")) 
            {
                return randomDirection[i];
            }
        }
        return Vector2Int.zero; 
        
    }

    private void UpdatePosition2(Vector2Int _targetDirection)
    {
        if(_currentTimer > _iterateTimer)
        {
            transform.position += new Vector3(_targetDirection.x, _targetDirection.y, 0);
            _currentTimer = 0;
        }
    }

    private async void UpdatePosition()
    {
        if (_currentTimer >= _iterateTimer)
        {
            // apakah ambil state lama atau state baru.
            int randomState = Random.Range(0, 10);

            // 0 - 9
            // 0, 1, 2 ( pake state baru )
            // 3, 4, 5, 6, 7, 8, 9 ( pake state lama )

            if (randomState < 3)
            {
                // state baru

                // setelah kita dapatin random value-nya.
                int random = Random.Range(0, randomDirection.Length);

                _targetDirection = randomDirection[random];
                _gizmosDirection = randomDirection[random];
            }
            else
            {
                // using state lama.
                _targetDirection = _previousDirection;
            }

            Vector3 currentPosition = transform.position;

            RaycastHit2D hit = Physics2D.Raycast((Vector2)currentPosition, (Vector2)currentPosition + _targetDirection, 2, ~ratLayer);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Rat"))
                {
                    // ignore.
                    Debug.Log("hit rat.");
                }
                else
                {
                    // except rat
                    if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Snake"))
                    {
                        // balik badan.
                        //RandomDirection();
                        Debug.Log("Prev direction " + _targetDirection);

                        if (_targetDirection == Vector2.up)
                        {
                            _targetDirection = Vector2.down;
                        }

                        if (_targetDirection == Vector2.down)
                        {
                            _targetDirection = Vector2.up;
                        }

                        if (_targetDirection == Vector2.left)
                        {
                            _targetDirection = Vector2.right;
                        }

                        if (_targetDirection == Vector2.right)
                        {
                            _targetDirection = Vector2.left;
                        }

                        //_targetDirection = -_targetDirection;
                        // if (_targetDirection == Vector2.up)
                        // {
                        //     // x0,y1 = x0,y-1
                        // }
                        Debug.Log("Current direction " + _targetDirection);
                        Debug.Log("Hit wall or snake.");
                    }
                    else
                    {
                        // move
                        Debug.Log("hit apple or egg.");
                    }
                }
            }

            transform.position += new Vector3(_targetDirection.x, _targetDirection.y, 0);

            //RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, _targetDirection, 1);
            //if (hit.collider == null || hit.collider.gameObject.name == "Rat")
            //{
            //    // can move
            //    Debug.Log("move");
            //    transform.position += (Vector3)_targetDirection;
            //}
            //else
            //{
            //    // debug
            //    Debug.Log("hit object " + hit.collider.gameObject.name);
            //    if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Wall"))
            //    {
            //        int random = Random.Range(0, randomDirection.Length);
            //        _targetDirection = randomDirection[random];
            //        transform.position += (Vector3)_targetDirection;
            //    }
            //}

            _previousDirection = _targetDirection;

            // reset
            _currentTimer = 0f;
            _canMove = false;
        }
    }

    #endregion

    #region Build-in Methods

    private void Start()
    {
        // Vector2
        // x, y

        // Vector3
        // x, y, z

        // Vector4
        // x, y, z, w

        RandomDirection();
    }

    private void Update()
    {
        _currentTimer += Time.deltaTime;

        UpdatePosition();
        // ShuffleRandomDirection();
        // Vector2Int asd = CheckCollider();
        // UpdatePosition2(asd);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 direction = new Vector2(transform.position.x + _gizmosDirection.x, transform.position.y + _gizmosDirection.y);
        Gizmos.DrawRay(transform.position, direction);
    }

    #endregion
}
