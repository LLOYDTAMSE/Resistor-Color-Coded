using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // allow to use the textmesh pro in unity UI.

public class Calculator : MonoBehaviour
{

    public enum ResistorState {
        Four,
        Five // enum is special type of class where it contains constant values that included in the app. 
    }

    [Header("Resistor State")]
    public ResistorState resistorState;
    public TMP_Dropdown dropdown;

    [Header("Band Groups")] // Transform is used to have children properties.
    public Transform firstBandGroup;
    public Transform secondBandGroup;
    public Transform thirdBandGroup; 
    public Transform multiGroup;
    public Transform tolBandGroup; 
    public GameObject thirdBandObj;

    [Header("Values")] // int is used to represent the number data.
    public int firstVal;
    public int secVal;
    public int thirdVal;
    public float mult = 1; // float is number type where you can use decimals and whole number at the same time.
    public float tol = 0.01f; //default value

    public int resistance;

    // create 2 floats named minResistance and maxResistance
    public float minResistance;
    public float maxResistance;

    [Header("Textboxes")]  //  Code for the Text Display in App.
    public TMP_Text resistanceText;
    public TMP_Text minResText;
    public TMP_Text maxResText;

    [Header("TemporaryValues")] // Code to be used for the Undo
    public int firstValTemp;
    public int secValTemp;
    public int thirdValTemp;
    public float multTemp = 1; // float is number type where you can use decimals and whole number at the same time.
    public float tolTemp = 0.01f; //default value
     
    

    public enum ValueTypes  // to do the undo process
    {
        first, second, third, multiplier, tolerance
    };

    public ValueTypes lastTouched = ValueTypes.first;
    


    //create reference  for min resistance text and max resistance text


    // Start is called before the first frame update
    void Start()
    {
        UpdateResistance();
    }

    // Update is called once per frame
    void Update()
    {
        if(resistorState == ResistorState.Four)
        {
            //If four band, disable all 3rd bands
            foreach(Transform child in thirdBandGroup)
            {
                child.GetComponent<Button>().interactable = false;
            }

            //Disable thirdband gameobject by using SetActive(false)
            thirdBandObj.SetActive(false);


        } else
        {
            //If five band, enable all 3rd bands
            foreach(Transform child in thirdBandGroup)
            {
                child.GetComponent<Button>().interactable = true;
            }
            
            // Abling thirdband gameobject by using SetActive(true)
            thirdBandObj.SetActive(true);

        }
    }

    public void OnStateChange() // Code used in UI dropdown or in choosing Bands.
    {
        if(dropdown.value == 0)
        {
            resistorState = ResistorState.Four;
        } else
        if(dropdown.value == 1)
        {
            resistorState = ResistorState.Five;
        }

        UpdateResistance();
    }

    public void UpdateResistance()
    {
        //  Create an equation to solve the resistance. That matters with the number of bands.
        if(resistorState == ResistorState.Four)
        {
           resistance = firstVal*10 + secVal;
        }else 
        if(resistorState == ResistorState.Five)
        {
            resistance = firstVal*100 + secVal*10 + thirdVal;
        }

        //Declare a float variable for resistance by converting the resistance to float
        float floatResistance = (float) resistance;

        //Multiplying resistance to the multiplier
        floatResistance *= mult;

        // Declare values for min resistance and max resistance
        minResistance = floatResistance*(1-tol);
        maxResistance = floatResistance*(1+tol);

        
        //Displaying the resistance text

        if( (floatResistance > 0f && floatResistance < 1f) || (floatResistance > 999f)   ) // configure the code to used the mertric prefixes
        {
            resistanceText.text = ToSI(floatResistance) + " Ω ±" + (tol * 100).ToString() + "%";
            maxResText.text = ToSI(maxResistance) + " Ω";
        }
        else
        {
            resistanceText.text = floatResistance.ToString() + " Ω ±" + (tol * 100).ToString() + "%";
            maxResText.text = maxResistance.ToString() + " Ω";
        }

        if( (minResistance > 0f && minResistance < 1f) || (minResistance > 999f)   ) // configure the code to used the mertric prefixes
        {
            minResText.text = ToSI(minResistance) + " Ω";
        }
        else
        {
            minResText.text = minResistance.ToString() + " Ω";
        }


        // Display the min resistance and max resistance to textboxes


        
        Debug.Log("Resistance Updated, resistance is now " + resistanceText.text);
        Debug.Log("Resistance Updated, Minresistance is now " + minResText.text);
        Debug.Log("Resistance Updated, Maxresistance is now " + maxResText.text);

    }


    //Function to convert double/float to string with metric prefix
    //example 10000 to 10k

    public string ToSI(float d)
    {

            char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

            int degree = (int)Mathf.Floor(Mathf.Log10(Mathf.Abs(d)) / 3);
            float scaled = d * Mathf.Pow(1000, -degree);

            char? prefix = null;


            switch (Mathf.Sign(degree))
            {
                case 1: 
                    prefix = incPrefixes[degree - 1];
                    break;
                case -1:
                    Debug.Log(degree);
                    prefix = decPrefixes[-degree - 1];
                    break;
            }

            Debug.Log(scaled.ToString() + prefix);
            return scaled.ToString() + prefix;
        
    }

    public void UpdateAllValues(int first, int second, int third, float mul, float toler)
    {
        firstVal = first;
        secVal = second;
        thirdVal = third;
        mult = mul;
        tol = toler;

        UpdateResistance();
    }

      
    //Create a public undo button using temporary values as parameters for UpdateAllValues
   // public void Undo()
   // {
        //switch (lastTouched)
       // {
          //  case ValueTypes.first:
              //  UpdateAllValues( firstValTemp, secVal, thirdVal, mult, tol );
               // break;
           // case ValueTypes.second:
              //  UpdateAllValues( firstVal, secValTemp, thirdVal, mult, tol );
               // break;
            //case ValueTypes.third:
                //UpdateAllValues( firstVal, secVal, thirdValTemp, mult, tol );
               // break;
           // case ValueTypes.multiplier:
//                UpdateAllValues( firstVal, secVal, thirdVal, multTemp, tol );
       //         break;
           // case ValueTypes.tolerance:
          //      UpdateAllValues( firstVal, secVal, thirdVal, mult, tolTemp );
           //     break;
       // }
   // }

    public Resistor resistor;
    
    
    //Create a public Reset Function to be called by a button
    public void Reset()
    {
        UpdateAllValues(0,0,0,1,0.01f); //Reset all values to default

        for (int i = 0; i < resistor.images.Length; i++)
        {
            if(i != resistor.images.Length - 1)
            {
                resistor.images[i].color = Color.black; //Reset all colors to default
            } else
            {
                float newR = 164f/255f;
                float newG = 109f/255f; // Code to represent color brown in resistor image as it reset 
                float newB = 19f/255f;

                Debug.Log(newR + " " + newG + " " +  newB);
                // resistor.images[i].color = new Color(164,109,19);
                resistor.images[i].color = new Color(newR,newG,newB,1);
            }
        }

       if(resistorState == ResistorState.Four)
          {
              resistorState = ResistorState.Four; //Reset state to default
              dropdown.value = 0; //reset dropdown display to default

          } else
        if(resistorState == ResistorState.Five)
        {
            resistorState = ResistorState.Five;
            dropdown.value = 1; //reset dropdown display to default
        }

        

        

    }


}
