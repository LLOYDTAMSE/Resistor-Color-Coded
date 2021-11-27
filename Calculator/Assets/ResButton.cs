using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResButton : MonoBehaviour
{
    public int value = 0;
    
    public enum ButtonType {bandOne, bandTwo, bandThree, multiplier, tolerance}; // This code is used also to contain constant values.

    public ButtonType buttonType;

    public Resistor resistor;

    public Calculator calculator;


    void Start()
    {

        resistor = FindObjectOfType<Resistor>();
        calculator = FindObjectOfType<Calculator>();

        value = transform.GetSiblingIndex(); // used to manipulate the array on delegate function.

        
        GetComponent<Button>().onClick.AddListener(
            delegate 
            {


                switch (buttonType)
                {
                    case ButtonType.bandOne:
                        UpdateColor(0);
                        break;
                    
                    case ButtonType.bandTwo:
                        UpdateColor(1);
                        break;
                    
                    case ButtonType.bandThree:
                        UpdateColor(2);
                        break;
                    
                    case ButtonType.multiplier:
                        UpdateColor(3);
                        break;
                    
                    case ButtonType.tolerance:
                        UpdateColor(4);
                        break;

                };

                UpdateValue(value);
                calculator.UpdateResistance();

            });

        }

        
    void UpdateColor(int childId)
    {
        resistor.images[childId].color = GetComponent<Image>().color; //Set the first band's color to this button's color.
    }

    void UpdateValue(int childId)
    {
        switch (buttonType)
        {
            case ButtonType.bandOne:
                calculator.firstVal = childId;
                Debug.Log("changed first value to " + childId);
                break;
                
            case ButtonType.bandTwo:
                calculator.secVal = childId;
                Debug.Log("changed second value to " + childId);
                break;
                
            case ButtonType.bandThree:
                calculator.thirdVal = childId;
                Debug.Log("changed third value to " + childId);
                break;
                
            case ButtonType.multiplier:
                calculator.thirdVal = childId;
                Debug.Log("changed mult value to " + childId);
                break;
                
            case ButtonType.tolerance:
                calculator.thirdVal = childId;
                Debug.Log("changed tol value to " + childId);
                break;
        }
    }


}


