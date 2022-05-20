using UnityEngine;
using UnityEngine.UI;

public class preffSet : MonoBehaviour
{
    [SerializeField] private Button _buttonOn;
    [SerializeField] private Button _buttonOff;
    [SerializeField] private bool _activeButton;
    [SerializeField] private int _totalPref;
    [SerializeField] private int _prefs;

    public void On()
    {
        _totalPref = 1;
    }

    public void Off()
    {
        _totalPref = 0;
    }

    private void Start()
    {
        _totalPref = PlayerPrefs.GetInt("totalPref");
    }
    private void Function(bool on, bool off)
    {
        _buttonOn.interactable = on;
        _buttonOff.interactable = off;
        PlayerPrefs.SetInt("totalPref", _totalPref);
    }
    private void Update()
    {
        if (_totalPref == 0)
        {
            Function(true, false);
        }
        else if (_totalPref == 1)
        {
            Function(false, true);
        }
        if (_prefs == 0)
        {
            PlayerPrefs.SetInt("postProcessing", _totalPref);
        }
    }
}
