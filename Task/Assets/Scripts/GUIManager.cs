using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _levelText;
    public static event Action LevelUp;
    private int _currentLevel;

    public void EncreaseLevel() {


        if (LevelUp != null)
        {
            LevelUp.Invoke();
        }  
    }


    void Start()
    {
        _currentLevel = 0;

        LevelUp += delegate () { if (_currentLevel >= 100) return;  
            _currentLevel++; _levelText.text = "Level: " + _currentLevel; };


    }


}
