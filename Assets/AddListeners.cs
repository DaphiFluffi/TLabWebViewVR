
using UnityEngine;
using UnityEngine.UI;


//[ExecuteInEditMode]
public class AddListeners : MonoBehaviour
{
    // Start is called before the first frame update
   /* void Start()
    {
        Button[] allChars = this.GetComponentsInChildren<Button>();
        foreach (Button b in allChars)
        {
            AddListener(b.name, b);
           
        }
      
    }
    void AddListener(Button button, string param)
    {
        Debug.Log("add listener " + button.name + " param " + param);
        button.onClick.RemoveAllListeners();

        // Add a listener with a parameter
        button.onClick.AddListener(() => log(param)); //LetterSelectSingleton.Instance.KeyPressed(param));  ;
    

    }

    public void ExplodeMe()
    {
        Debug.Log("I just blew up!");
    }

    public void log(string param)
    {
        Debug.Log("log " + param);
    }*/
}
