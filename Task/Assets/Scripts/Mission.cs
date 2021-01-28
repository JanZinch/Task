using System;
using UnityEngine;
using TMPro;

public class Mission : MonoBehaviour
{
    private short _number;
    [SerializeField] private short _requiredCoins;
    [SerializeField] private short _currentCoins;

    public short RequiredCoins {

        get {

            return _requiredCoins;
        }

        set {

            _requiredCoins = value;        
        }    
    }

    public short CurrentCoins
    {
        get
        {
            return _currentCoins;
        }

        set
        {
            _currentCoins = value;
        }
    }

    [SerializeField] private LevelsManager _levelsManager;
    [SerializeField] private TextMeshProUGUI _numberLabel;
    [SerializeField] private TextMeshProUGUI _coinsCountLabel;

    public TextMeshProUGUI NumberLabel {

        private set {

            _numberLabel = value;
        }

        get {

            return _numberLabel; 
        }    
    }

    public TextMeshProUGUI CoinsLabel {

        private set {

            _coinsCountLabel = value;        
        }

        get {

            return _coinsCountLabel; 
        }
    
    }

    

    //private bool _completed;

    public void SetLevel()
    {
        //_levelsManager.LevelNumber = _numberLabel.text;
        //_levelsManager.CoinsData = _coinsLabel.text;

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

            _number = short.Parse(_numberLabel.text);

            //Debug.Log("CN: " + _number);
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }

        _coinsCountLabel.text = "x" + _currentCoins + "/" + _requiredCoins;  
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
