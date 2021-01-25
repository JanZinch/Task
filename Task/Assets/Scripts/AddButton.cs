using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    void Start()
    {
        GUIManager.LevelUp += delegate () {

            this.GetComponent<Button>().interactable = false;
        };
    }
}
