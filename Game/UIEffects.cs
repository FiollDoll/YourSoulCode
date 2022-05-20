using System.Collections;
using UnityEngine;

public class UIEffects : MonoBehaviour
{
    [SerializeField] private GameObject[] textHpInfo = new GameObject[2];
    private int num;
    public void textShow(int numActive)
    {
        textHpInfo[numActive].gameObject.SetActive(true);
        num = numActive;
        StartCoroutine("NotShowText");
    }

    private IEnumerator NotShowText()
    {
        yield return new WaitForSeconds(2);
        textHpInfo[num].gameObject.SetActive(false);
    }
}
