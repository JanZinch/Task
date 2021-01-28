using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class LevelsManager : MonoBehaviour
{   
    [SerializeField] private Mission _displayedMission;
    public static short DisplayedMissionNumber { get; set; } = 0;

    [SerializeField] private Sprite _lockedImage;
    [SerializeField] private Sprite _availImage;
    [SerializeField] private Sprite _complImage;
    private static Sprite[] images = new Sprite[3];
   
    public static event Action CompleteLevel;
    public static event Action ReplayLevel;

    private short _requiredCoins;
    private short _currentCoins;
    private TextMeshProUGUI _levelNumberLabel;
    [SerializeField] private TextMeshProUGUI _coinsCountLabel;
      
    public Mission DisplayedMission {

        get {

            return _displayedMission;        
        }

        set
        {
            _displayedMission = value;
            _levelNumberLabel.text = "Level: " + _displayedMission.NumberLabel.text;
            _requiredCoins = _displayedMission.RequiredCoins;
            _currentCoins = _displayedMission.CurrentCoins;
            _coinsCountLabel.text =  "x" + _currentCoins + "/" + _requiredCoins;
        }

    }

    public void AddCoin() {

        if (_currentCoins == _requiredCoins || DisplayedMission.State == Mission.Status.LOCKED) return; 

        _currentCoins++;
        _coinsCountLabel.text = "x" + _currentCoins + "/" + _requiredCoins;
        _displayedMission.AddCoin();
    }

    public void RemoveCoin() {

        if (0 == _currentCoins) return; 

        _currentCoins--;
        _coinsCountLabel.text = "x" + _currentCoins + "/" + _requiredCoins;
        _displayedMission.RemoveCoin();
    }

    public void CompleteMission() {

        DisplayedMissionNumber = _displayedMission.Number;

        if (CompleteLevel != null && _displayedMission.State == Mission.Status.AVAILABLE) { CompleteLevel.Invoke(); }
    }

    public void ReplayMission() {

        DisplayedMissionNumber = _displayedMission.Number;

        if (ReplayLevel != null) { ReplayLevel.Invoke(); }      
    }

    public static Sprite GetImage(Mission.Status state) {

        return images[(byte)state];       
    }

    private void Awake()
    {
        images[(byte)Mission.Status.LOCKED] = _lockedImage;
        images[(byte)Mission.Status.AVAILABLE] = _availImage;
        images[(byte)Mission.Status.COMPLETED] = _complImage;
    }

    void Start()
    {     
        _levelNumberLabel = GetComponent<TextMeshProUGUI>();
        DisplayedMission = _displayedMission;
    }


}

[Serializable]
public class ButtonEvent : UnityEvent<Button> { };
