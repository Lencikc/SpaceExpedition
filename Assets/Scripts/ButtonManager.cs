using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("SpeedBoost Button")]
    private bool isSpeeded = false;
    private FuelSpawnLogic _FuelScript;
    private MoveRocket _PlayerScript;

    [Header("Settings Panel")]
    private bool _isSettingsPanelOpened;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _settingButton;
    [SerializeField] private GameObject _oxygenIcons;
    [SerializeField] private GameObject _fuelIcons;
    private void Start()
    {
        _settingPanel.SetActive(false);

        if (GameObject.Find("FuelSpawner").GetComponent<FuelSpawnLogic>() != null)
            _FuelScript = GameObject.Find("FuelSpawner").GetComponent<FuelSpawnLogic>();
        if (GameObject.Find("Player").GetComponent<MoveRocket>() != null)
            _PlayerScript = GameObject.Find("Player").GetComponent<MoveRocket>();
    }
    public void SpeedBoostBtn()
    {
        isSpeeded = !isSpeeded;
        if (isSpeeded)
        {
            _FuelScript.boost = 2;
            _PlayerScript.boost = 2;
        }
        else
        {
            _FuelScript.boost = 1;
            _PlayerScript.boost = 1;
        }
    }
    public void SceneLoaderBtn(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void SettingsPanelOpenCloseBtn()
    {
        if(!_isSettingsPanelOpened)
        {
            _settingPanel.SetActive(true);
            _settingButton.SetActive(false);
            _fuelIcons.SetActive(false);
            _oxygenIcons.SetActive(false);
            Time.timeScale = 0;
            _isSettingsPanelOpened = true;

        }
        else  if (_isSettingsPanelOpened)
        { 
            _settingPanel.SetActive(false);
            _settingButton.SetActive(true);
            _fuelIcons.SetActive(true);
            _oxygenIcons.SetActive(true);
            Time.timeScale = 1;
            _isSettingsPanelOpened = false;
        }   
    }
}
