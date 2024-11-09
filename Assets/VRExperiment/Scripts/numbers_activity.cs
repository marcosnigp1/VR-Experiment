using System; //We need this to sort values.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; //This will help in getting the UI values.

using Random = UnityEngine.Random; //This helps to fix conflicts with system.

public class numbers_activity : MonoBehaviour
{

    public TextMeshProUGUI main_output; //Main testing field

    //Output fields

    //Yes, I have to declare many since they are the output fields...
    public Canvas output1;
    public Canvas output2;
    public Canvas output3;
    public Canvas output4;
    public Canvas output5;
    public Canvas output6;
    public Canvas output7;
    public Canvas output8;
    public Canvas output9;


    //Get the label values from the canvas
    public TextMeshProUGUI text;

    // -------------------- //

 
    //Creating list (array is not recommended).
    public List<float> numbers;
    public List<string> generated_numbers;
    public List<Canvas> canva_to_display;

    public void GenerateNumbers(){

        //Make all canvas untoggable.
        output1.enabled = false;
        output2.enabled = false;
        output3.enabled = false;
        output4.enabled = false;
        output5.enabled = false;
        output6.enabled = false;
        output7.enabled = false;
        output8.enabled = false;
        output9.enabled = false;

        //Clear list of numbers to be able to generate new ones.
        numbers.Clear();
        generated_numbers.Clear();
        canva_to_display.Clear();


        //Prepare the labels and toggles inside the canvas selected to output the text
        int limit = 0;

        while (limit < 4){
            int rng = Random.Range(1, 10);
            
            while (generated_numbers.Contains(rng.ToString())){
                rng = Random.Range(1, 10);
            }

            switch(rng){
                case 1:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output1);
                    break;
                
                case 2:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output2);
                    break;
                
                case 3:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output3);
                    break;
            
                case 4:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output4);
                    break;
                
                case 5:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output5);
                    break;

                case 6:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output6);
                    break;

                case 7:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output7);
                    break;

                case 8:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output8);
                    break;

                case 9:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(output9);
                    break;

                default:
                    Debug.Log("Oh no");
                    break;
            }
            limit++;

        }



        //Keep in mind that we need to interate a total of 8 (i < 9) times in order to fulfill the list to display the label of each canvas. 
        for (int i = 0; i < 4; i++){
            float rng = Random.Range(-100.0f, 100.0f);
            rng = MathF.Round(rng, 1); //Helps to round the received value.

            //If generated number is equal
            while (numbers.Contains(rng)){
                rng = Random.Range(-100.0f, 100.0f);
                rng = MathF.Round(rng, 1);  //Helps to round the received value.
            }

            //This converts it to numbers and not string. If you remove this it crashes.
            numbers.Add(rng);
        }

        //I got this reference from: https://www.educative.io/answers/how-to-sort-a-list-in-c-sharp
        numbers.Sort();  // Sort the list in ascending order
        numbers.Reverse(); // Reverse the order of the elements
    }


    public void ShowValues(){

        main_output.text = "Hello world!";

        foreach (Canvas element in canva_to_display){
            //TextMeshProUGUI Text = element.Find("Label");
            //Text.text = "Hello world!";
        }

        //Show values. Also, the float numbers need to be converted into string with ToString().
        //output1.text = numbers[0];
        //output2.text = numbers[1];
    }
}
