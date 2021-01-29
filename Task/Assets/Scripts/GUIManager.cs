using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    public static event Action LevelUp;
    public static event Action GetRewardPressed;
    public static event Action RewardChoosed;
    private int _currentLevel; 
    
    public void PressAddLevelButton() {

        if (LevelUp != null)
        {
            LevelUp.Invoke();
        }  
    }

    public void PressGetRewardButton() {

        if (GetRewardPressed != null) {

            GetRewardPressed.Invoke();        
        } 
    }

    public void PressGetButton()
    {
        if (RewardChoosed != null)
        {
            RewardChoosed.Invoke();
        }
    }

    public void InitAddLevelButton(Button button) {

        LevelUp += delegate () {

            button.interactable = false;
        };

        RewardChoosed += delegate ()
        {
            button.interactable = true;
        };
    }

    public void InitGetRewardButton(Button button)
    {
        button.gameObject.SetActive(false);

        LevelUp += delegate () {

            button.gameObject.SetActive(true);
        };

        GetRewardPressed += delegate ()
        {
            button.gameObject.SetActive(false);
        };

        RewardChoosed += delegate ()
        {
            button.gameObject.SetActive(false);
        };
    }

    public void InitGetButton(Button button) {

        button.gameObject.SetActive(false);

        GetRewardPressed += delegate ()
        {
            button.gameObject.SetActive(true);
        };

        RewardChoosed += delegate ()
        {
            button.gameObject.SetActive(false);
        };
    }

    void Start()
    {
        _currentLevel = 0;

        LevelUp += delegate () { 
            
            if (_currentLevel >= 99) return;  
            _currentLevel++; 
            _levelText.text = "Level: " + _currentLevel; 
        };

    }

}
