using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pref : MonoBehaviour
{
    [SerializeField] private Transform _JoystickTransform;
    [SerializeField] private Transform _Jump;
    [SerializeField] private int _JoyTransform;

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
        // Положение джостика
        if (_JoyTransform == 0)
        {
            _JoystickTransform.localPosition = new Vector2(-1119, -478);
            _Jump.localPosition = new Vector2(1181, -478);
        }
        if (_JoyTransform == 1)
        {
            _JoystickTransform.localPosition = new Vector2(1181, -478);
            _Jump.localPosition = new Vector2(-1119, -478);
        }
        // Графика
        if (_postProcessing == 1)
        {
            _postProcessingObject.gameObject.SetActive(false);
        }
    }
}
