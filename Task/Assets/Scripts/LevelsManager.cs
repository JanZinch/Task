using System;
using UnityEngine;
using TMPro;

public class LevelsManager : MonoBehaviour
{
    private TextMeshProUGUI _levelNumberLabel;
    [SerializeField] private TextMeshProUGUI _coinsCountLabel;

    private short _requiredCoins;
    private short _currentCoins;

    [SerializeField] private Mission _displayedMission;
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

    public string LevelNumber {

        get {

            return _levelNumberLabel.text;
        }

        set {

            _levelNumberLabel.text = "Level: " + value;
        }  
    }

    public string CoinsData {

        get
        {
            return _coinsCountLabel.text;
        }

        set
        {
            _coinsCountLabel.text = value;
        }
    }

    public void AddCoin() {

        if (_currentCoins == _requiredCoins) return; 

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

    void Start()
    {        
        _levelNumberLabel = GetComponent<TextMeshProUGUI>();
        DisplayedMission = _displayedMission;
    }


}
