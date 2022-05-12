using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] private Transform _teleportEnd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = new Vector3(_teleportEnd.transform.position.x, _teleportEnd.transform.position.y, 0);
        }
    }
}
