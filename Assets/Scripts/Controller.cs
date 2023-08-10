using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour {

    public static Controller instance;
    void Awake() { instance = this; }
    
    [SerializeField] private bool alive = true;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float sensitivity = 1.0f;

    [SerializeField] private int humans = 1;
    [SerializeField] private int maxHumans = 100;
    [SerializeField] private TMP_Text humanText;

    void Update() {
        
        if (!alive) return;

        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = Vector3.left * speed + transform.right * horizontal * sensitivity;
        transform.position += direction * Time.deltaTime;
        
    }

    public void AddHumans(int amount) {

        if (humans == maxHumans) return;

        humans += amount;
        if (humans > maxHumans) humans = maxHumans;

        humanText.text = humans.ToString();

    }
    public void RemoveHumans(int amount) {

        if (humans < 1) return;

        humans -= amount;
        if (humans < 0) {

            humans = 0;
            humanText.text = "Died :c";
            alive = false;
            return;

        }

        humanText.text = humans.ToString();

    }

    public int Humans { get { return humans; } }

}