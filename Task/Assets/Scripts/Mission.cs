using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mission : MonoBehaviour
{

    [SerializeField] private LevelsManager _levelsManager;
    private Image _spriteRender;

    public short Number { get; set; }

    [SerializeField] private Status _state;
    [SerializeField] private short _requiredCoins;
    [SerializeField] private short _currentCoins;
    public Status State { get { return _state; } set { _state = value; } }   
    public short RequiredCoins { get { return _requiredCoins; } set { _requiredCoins = value; } }  
    public short CurrentCoins { get { return _currentCoins; } set { _currentCoins = value; } }
        
    [SerializeField] private TextMeshProUGUI _coinsCountLabel;
    [SerializeField] private TextMeshProUGUI _numberLabel;
    public TextMeshProUGUI NumberLabel { private set { _numberLabel = value; } get { return _numberLabel; } }

    public enum Status : byte
    {
        LOCKED, AVAILABLE, COMPLETED
    }

    public void SetLevel()
    {
        _levelsManager.DisplayedMission = this.GetComponent<Mission>();
    }

    public void AddCoin() {

        _currentCoins++;
        _coinsCountLabel.text = "x" + _currentCoins + "/" + _requiredCoins;
    }

    public void RemoveCoin()
    {
        _currentCoins--;
        _coinsCountLabel.text = "x" + _currentCoins + "/" + _requiredCoins;
    }

    void Start()
    {
        try {

            Number = short.Parse(_numberLabel.text);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        _spriteRender = GetComponent<Image>();
        _spriteRender.sprite = LevelsManager.GetImage(_state);
        _coinsCountLabel.text = "x" + _currentCoins + "/" + _requiredCoins;

        LevelsManager.CompleteLevel += delegate ()
        {
            try
            {
                if (Number == LevelsManager.DisplayedMissionNumber && _state == Status.AVAILABLE)
                {                 
                    _state = Status.COMPLETED;
                    _spriteRender.sprite = LevelsManager.GetImage(_state);
                }
                else if ((Number == LevelsManager.DisplayedMissionNumber + 1) && _state == Status.LOCKED)
                {                 
                    _state = Status.AVAILABLE;
                    _spriteRender.sprite = LevelsManager.GetImage(_state);                                    
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
          
        };

        LevelsManager.ReplayLevel += delegate ()
        {
            try
            {
                if (Number == LevelsManager.DisplayedMissionNumber && _state == Status.COMPLETED)
                {
                    _state = Status.AVAILABLE;
                    _spriteRender.sprite = LevelsManager.GetImage(_state);
                }                
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }

        };


    }

}
