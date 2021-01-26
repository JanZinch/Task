using UnityEngine;

public class GetButton : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);

        GUIManager.GetRewardPressed += delegate ()
        {
            this.gameObject.SetActive(true);
        };

        GUIManager.RewardChoosed += delegate ()
        {
            this.gameObject.SetActive(false);
        };

    }


}
