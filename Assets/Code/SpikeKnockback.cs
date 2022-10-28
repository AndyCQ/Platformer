using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeKnockback : MonoBehaviour
{

    private PlayerCode player;
    public int knockbackPowerInEditor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCode>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
            player.Damage(1);

            StartCoroutine(player.Knockback(0.02f, knockbackPowerInEditor, player.transform.position));
        }
    }
}
