using System.Collections;
using UnityEngine;

public class UITextMenu : MonoBehaviour
{

    private Vector2 randomPos;
    [SerializeField] private GameObject text;
    public void Update()
    {
        randomPos = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
        Instantiate(text, randomPos, Quaternion.identity);
        StartCoroutine("NotShowText");
    }

    private IEnumerator NotShowText()
    {
        yield return new WaitForSeconds(0.09f);
        Destroy(GameObject.Find("text(Clone)"));
    }
}
