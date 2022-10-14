using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    // Update is called once per frame
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
