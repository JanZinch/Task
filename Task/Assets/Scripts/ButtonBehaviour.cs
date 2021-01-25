using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        this.gameObject.SetActive(false);

        GUIManager.LevelUp += delegate (){

            this.gameObject.SetActive(true);
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
