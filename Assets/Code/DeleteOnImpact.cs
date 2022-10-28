using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
}
