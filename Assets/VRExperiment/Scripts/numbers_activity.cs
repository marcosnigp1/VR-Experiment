using System; //We need this to sort values.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; //This will help in getting the UI values.

using Random = UnityEngine.Random; //This helps to fix conflicts with system.

public class numbers_activity : MonoBehaviour
{

    public TextMeshProUGUI main_output; //Main testing field

    //Texting output fields
    public TextMeshProUGUI output1;
    public TextMeshProUGUI output2; 
    public TextMeshProUGUI output3;
    public TextMeshProUGUI output4;
    public TextMeshProUGUI output5;

    //Creating list (array is not recommended).
    public List<string> numbers;

    public void GenerateNumbers(){

        //Clear list of numbers to be able to generate new ones.
        numbers.Clear();

        //Keep track of last number to avoid repetition in the random function.
        float last_number = 0; 

        for (int i = 0; i < 6; i++){
            float rng = Random.Range(0, 10);

            //If generated number is equal
            while (numbers.Contains(rng.ToString())){
                rng = Random.Range(0, 10);
            }

            //This converts it to numbers and not string. If you remove this it crashes.
            numbers.Add(rng.ToString());
            last_number = rng;
        }

        //I got this reference from: https://www.educative.io/answers/how-to-sort-a-list-in-c-sharp
        numbers.Sort();  // Sort the list in ascending order
        numbers.Reverse(); // Reverse the order of the elements
    }


    public void ShowValues(){



        main_output.text = "Hello world!";
        
        //Show values. Also, the float numbers need to be converted into string with ToString().
        output1.text = numbers[0];
        output2.text = numbers[1];
        output3.text = numbers[2];
        output4.text = numbers[3];
        output5.text = numbers[4];
    }
}
