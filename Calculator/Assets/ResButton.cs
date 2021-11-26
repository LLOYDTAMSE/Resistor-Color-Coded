using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResButton : MonoBehaviour
{
    public int value = 0;
    
    public enum ButtonType {bandOne, bandTwo, bandThree, multiplier, tolerance};

    public ButtonType buttonType;

    public Resistor resistor;

    void Start()
    {

        resistor = GameObject.Find("Resistor").GetComponent<Resistor>();

        value = transform.GetSiblingIndex();

        // TODO: Finish
        GetComponent<Button>().onClick.AddListener(
            delegate {

                if(buttonType == ButtonType.bandOne)
                {
                    resistor.images[0].color = GetComponent<Image>().color; //Set the first band's color to this button's color
                }

                //continue bandTwo bandThree mult Tol
            }
        );

    }

}
