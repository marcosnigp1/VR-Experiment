using System; //We need this to sort values.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; //This will help in getting the UI values.

using Random = UnityEngine.Random; //This helps to fix conflicts with system.

public class numbers_activity : MonoBehaviour
{

    //Parent GameObject
    public GameObject parentObject;  //Done with help of: https://www.youtube.com/watch?v=JAkD9bwQVAE
    public GameObject[] allCanvas;

    //Output fields
    public TextMeshProUGUI main_output; //Main testing field

    //Creating list (array is not recommended).
    public List<float> numbers;
    public List<string> generated_numbers;
    public List<int> canva_to_display;

    //Start is called before the first frame update
    //Done with help of: https://www.youtube.com/watch?v=JAkD9bwQVAE
    void Start(){

        //Make all canvas untoggable.
        allCanvas = new GameObject[parentObject.transform.childCount];

        for (int i=0; i<allCanvas.Length; i++){
            allCanvas[i] = parentObject.transform.GetChild(i).GetChild(0).gameObject;
            allCanvas[i].SetActive(false); //Disable all the canvas.
        }
    }


    public void GenerateNumbers(){

        //Reset canvas state
        for (int i=0; i<allCanvas.Length; i++){
            allCanvas[i].SetActive(false); //Disable all the canvas.
        }


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
                    canva_to_display.Add(0);
                    break;
                
                case 2:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(1);
                    break;
                
                case 3:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(2);
                    break;
            
                case 4:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(3);
                    break;
                
                case 5:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(4);
                    break;

                case 6:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(5);
                    break;

                case 7:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(6);
                    break;

                case 8:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(7);
                    break;

                case 9:
                    generated_numbers.Add(rng.ToString());
                    canva_to_display.Add(8);
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

        for (int i=0; i<4; i++){
            //Enable all visible canvas.
            allCanvas[canva_to_display[i]].SetActive(true);

            //Obtain the label reference to change its text.
            TextMeshProUGUI label = allCanvas[canva_to_display[i]].GetComponentInChildren<TextMeshProUGUI>();
            label.text = numbers[i].ToString();
        }

        //Show values. Also, the float numbers need to be converted into string with ToString().
        //output1.text = numbers[0];
        //output2.text = numbers[1];
    }
}
