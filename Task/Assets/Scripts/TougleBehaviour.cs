using UnityEngine;
using UnityEngine.UI;

public class TougleBehaviour : MonoBehaviour
{
    [SerializeField] private SlotNumber _slotNumber = SlotNumber.ONE;
    [SerializeField] private RewardsCounter[] _rewardsImages = null;
    private Toggle _toggle;
    private Text _label;
    private int? _reward = null;
    private bool isEven = false;

    private void Start()
    {        
        this.gameObject.SetActive(false);

        _toggle = GetComponent<Toggle>();
        _label = this.gameObject.GetComponentInChildren<Text>();

        GUIManager.GetRewardPressed += delegate ()
        {        
            _reward = RewardsGenerator.Generate(_slotNumber, isEven);

            isEven = (isEven) ? false: true;

            

            if (_reward != null) {

                _label.text = _reward.ToString();
            }

            this.gameObject.SetActive(true);
        };

        GUIManager.RewardChoosed += delegate ()
        {
            int addend = (_slotNumber == SlotNumber.ONE)? 1 : 6;

            if (_toggle.isOn) {

                for (int i = 0; i < _rewardsImages.Length; i++) {

                    if (_reward == i + addend) {

                        _rewardsImages[i].AddReward();                   
                    }                              
                }                                                       
            }

            this.gameObject.SetActive(false);
        };
    }

}

enum SlotNumber { 

    ONE = 1, TWO = 2
}

