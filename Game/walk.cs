using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public bool onGround; // На земле или нет

    private void OnCollisionEnter2D(Collision2D other)
    {
        onGround = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        onGround = false;
    }
}