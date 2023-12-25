using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberDisplay : MonoBehaviour
{
    public int boost_num = 0;
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        UpdateNumberDisplay();
    }

    void UpdateNumberDisplay()
    {
        textComponent.text = "Number: " + boost_num;
    }

    void Update()
    {
        // Check for input in the Update method
        if (Input.GetKey("i"))
        {
            boost_num = boost_num + 1;
            UpdateNumberDisplay();
        }
    }

    // You can call this method from other scripts to update the displayed number.
    public void SetNumber(int newNumber)
    {
        boost_num = newNumber;
        UpdateNumberDisplay();
    }
}
