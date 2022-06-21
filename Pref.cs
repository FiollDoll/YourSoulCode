using UnityEngine;
using UnityEngine.UI;

public class Pref : MonoBehaviour
{
    [SerializeField] private Transform _JoystickTransform;
    [SerializeField] private Transform _Jump;
    [SerializeField] private int _JoyTransform;
    [SerializeField] private int totalButton;
    [SerializeField] private GameObject[] buttons = new GameObject[1];
    [SerializeField] private int _postProcessing;
    [SerializeField] private GameObject _postProcessingObject;
    private void Start()
    {
        _JoyTransform = PlayerPrefs.GetInt("JoyTransform");
        _postProcessing = PlayerPrefs.GetInt("postProcessing");
    }

    // Update is called once per frame
    private void Update()
    {
        if (totalButton == 0)
        {
            buttons[0].gameObject.SetActive(true);
            buttons[1].gameObject.SetActive(false);

        }
        else if (totalButton == 1)
        {
            buttons[1].gameObject.SetActive(true);
            buttons[0].gameObject.SetActive(false);

        }
        // Графика
        if (_postProcessing == 1)
        {
            _postProcessingObject.gameObject.SetActive(false);
        }
    }
}
