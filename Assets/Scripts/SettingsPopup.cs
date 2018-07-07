using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    // Inspector.
    [SerializeField] private Slider _gravitySlider;

    private void Start()
    {
        _gravitySlider.value = PlayerPrefs.GetFloat("gravity");
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("gravity", speed);
    }
}
