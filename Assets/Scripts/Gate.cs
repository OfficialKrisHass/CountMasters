using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour {
    
    enum Symbol {

        None,
        Add, Subtract,
        Multiply, Divide

    }

    [SerializeField] private Symbol symbol;
    [SerializeField] private int number;

    [SerializeField] private TMP_Text txt;

    void Start() {
        
        txt.text = SymbolToString(symbol) + number.ToString();

    }

    void OnTriggerEnter(Collider other) {

        Debug.Log(other.name);
        
        if (other.tag != "Player") return;
        
        switch(symbol) {

            case Symbol.Add: Controller.instance.AddHumans(number); break;
            case Symbol.Multiply: {
                
                Controller.instance.AddHumans(Controller.instance.Humans * number - Controller.instance.Humans);
                break;

            }
            case Symbol.Subtract: Controller.instance.RemoveHumans(number); break;
            case Symbol.Divide: {

                Controller.instance.RemoveHumans(Controller.instance.Humans - Controller.instance.Humans / number);
                break;

            }

        }

    }

    private string SymbolToString(Symbol symbol) {

        switch (symbol) {

            case Symbol.Add: return "+";
            case Symbol.Subtract: return "-";
            case Symbol.Multiply: return "x";
            case Symbol.Divide: return "/"; 

        }

        return "OOPSIE UWU";

    }

}