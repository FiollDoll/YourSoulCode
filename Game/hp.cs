using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{

    [SerializeField] private int _hp;
    [SerializeField] private GameObject[] hpSprite = new GameObject[10];
    private Player _script;
    
    void Start()
    {
        _script = GetComponent<Player>();
    }
    void Update()
    {
        _hp = _script.mainStats[1];
		for (int i = 0; i < hpSprite.Length; i++)
		{
            if (i < _hp)
            {
				hpSprite[i].gameObject.SetActive(true);
            }
			else
			{
				hpSprite[i].gameObject.SetActive(false);
			}
        }
    }
}
