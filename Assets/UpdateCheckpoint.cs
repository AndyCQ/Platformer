using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCheckpoint : MonoBehaviour
{
    public Sprite obtained;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            gameObject.GetComponent<SpriteRenderer>().sprite = obtained;
        }
    }
}
