using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo : MonoBehaviour
{
    public int speed;
    public int hp;
    public int jumpp;

    public void CharacterTotal(int character)
    {
        if (character == 0)
        {
            speed = 7;
            hp = 3;
            jumpp = 1350;
        }
    }
}
