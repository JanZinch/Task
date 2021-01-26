using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    private Button _button;

    void Start()
    {
        _button = this.GetComponent<Button>();

        GUIManager.LevelUp += delegate () {

            _button.interactable = false;
        };

        GUIManager.RewardChoosed += delegate ()
        {
            _button.interactable = true;
        };
    }
}
