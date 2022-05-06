using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlMenu : MonoBehaviour
{
    private float xPos = 35;
    public void MouseStop() //Остановка
    {
        xPos += 0;
    }
    public void MousePressed() //Ускоренная скорость
    {
        xPos += 0.05f;
    }
    public void MouseUnPressed() //Ускоренная скорость
    {
        xPos -= 0.05f;
    }
    public void MousePressedUp() //-Стандартная скорость
    {
        xPos += 0.5f;
    }
    public void MouseUnPressedUp() //Стандартная скорость
    {
        xPos -= 0.5f;
    }
    void Update()
    {
        transform.position = new Vector3(xPos, 1, 0);
    }
}
