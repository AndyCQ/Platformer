using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private PlayerCode player;
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCode>();
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate() {
        _animator.SetInteger("currHealth", player.currHealth);
    }
}
