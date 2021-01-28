using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private ButtonEvent OnStart;

    void Start() 
    {
        OnStart.Invoke(GetComponent<Button>());    
    }
}
