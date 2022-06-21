using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class eventTime : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Rigidbody2D _rb;
    public bool timerEvent; // Включен или нет
    [SerializeField] private float _timer;
    private game _script; 
    [Header("Other")]
    [SerializeField] private GameObject cards; //Обьекты с картами событий
    private void Start()
    {
        timerEvent = true;
        _script = GetComponent<game>();
        StartCoroutine("ModeChange");
    }
    private void Event(int eventNum)
    {
        //Ивент
    }
    void Update()
    {
        if (_script.mode == 1) //Если mode = 1, то режим с ивентами
        {
            if (_timer >= 60)
            {
                StartCoroutine("StartEvent");
            }
            if (timerEvent == true)
            {
                _timer += Time.deltaTime;
            }            
        }
    }

    private IEnumerator StartEvent()
    {
        _rb.isKinematic = true;
        int randomNum = Random.Range(0, 2);
        Event(randomNum);
        yield return new WaitForSeconds(3);
        _rb.isKinematic = false;
    } 
    private IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(3);
        if (_script.mode != 1)
        {
            Destroy(cards);
        }
    } 
}
