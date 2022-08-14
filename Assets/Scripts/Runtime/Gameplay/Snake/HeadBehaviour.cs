using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Wall") )// || other.gameObject.CompareTag("Snake")
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
    }
}
