using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{

    private PlayerCode player;
    public int knockbackPowerInEditor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCode>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            player.Damage(2);

            StartCoroutine(player.Knockback(0.02f, knockbackPowerInEditor, player.transform.position));
        }
    }
}
