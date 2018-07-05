using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Inspector.
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private SettingsPopup _settingsPopup;

    void Start()
    {
        _settingsPopup.Close();
    }

    private void Update()
    {
        _scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        _settingsPopup.Open();
    }
}
