using System;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    public static event Action LevelUp;
    public static event Action GetRewardPressed;
    public static event Action RewardChoosed;
    private int _currentLevel;

    public void EncreaseLevel() {

        if (LevelUp != null)
        {
            LevelUp.Invoke();
        }  
    }

    public void PressGetReward() {

        if (GetRewardPressed != null) {

            GetRewardPressed.Invoke();        
        } 
    }

    public void ChooseReward()
    {
        if (RewardChoosed != null)
        {
            RewardChoosed.Invoke();
        }
    }


    void Start()
    {
        _currentLevel = 0;

        LevelUp += delegate () { if (_currentLevel >= 99) return;  
            _currentLevel++; _levelText.text = "Level: " + _currentLevel; };

    }

}
