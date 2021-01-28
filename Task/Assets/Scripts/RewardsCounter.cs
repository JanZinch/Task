using UnityEngine;
using TMPro;

public class RewardsCounter : MonoBehaviour
{
    private int _rewardsCount = 0;
    [SerializeField] private TextMeshProUGUI _label; 

    public void AddReward() {

        _rewardsCount++;
        _label.text = "x" + _rewardsCount;
    }

}
