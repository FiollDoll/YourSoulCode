using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventsInNegativ: MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private GameObject platform;

    private void Start()
    {
        _anim = platform.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _anim.SetBool("move", true);
        }
    }
}
