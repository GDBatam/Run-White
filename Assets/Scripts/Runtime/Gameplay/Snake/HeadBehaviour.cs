using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Wall")
        || other.gameObject.CompareTag("Snake"))
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
    }
}
