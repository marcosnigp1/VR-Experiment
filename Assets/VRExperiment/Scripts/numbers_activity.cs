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
    public AudioSource[] soundSources;

    //Output fields
    public TextMeshProUGUI main_output; //Main testing field
    public TextMeshProUGUI time_and_error_output;

    //Creating list (array is not recommended).
    public List<float> numbers;
    public List<string> generated_numbers;
    public List<int> canva_to_display;

    //Time related variables. Done with help of the following source: https://discussions.unity.com/t/how-do-i-calculate-accurately-time-passed-in-seconds-for-c/510112/15
    public float time_spent;
    public int error_count = 0;
    public int activity_limit = 0;

    //Check if values are printed.
    public bool values_printed = false;

    //Variables related to activity state.
    public bool activity_started;


    
    //Start is called before the first frame update
    //Done with help of: https://www.youtube.com/watch?v=JAkD9bwQVAE
    void Start(){

        //Make all canvas untoggable.
        allCanvas = new GameObject[parentObject.transform.childCount];

        //Specify that the activity has not started yet.
        activity_started = false;

        for (int i=0; i<allCanvas.Length; i++){
            allCanvas[i] = parentObject.transform.GetChild(i).GetChild(0).gameObject;
            allCanvas[i].SetActive(false); //Disable all the canvas.
        }

    }

    //Add one second to counter, with the help of InvokeRepeating().
    public void Count(){
        time_spent++;
    }


    public void GenerateNumbers(){

        //Avoid self calling it.
        if (time_spent == 0){
            InvokeRepeating("Count", 1, 1);
        }

        //The activity has started.
        activity_started = true;
        
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

        //main_output.text = "Click again to reset values.";
        main_output.text = "";

        for (int i=0; i<4; i++){
            //Enable all visible canvas.
            allCanvas[canva_to_display[i]].SetActive(true);

            //Obtain the label reference to change its text.
            TextMeshProUGUI label = allCanvas[canva_to_display[i]].GetComponentInChildren<TextMeshProUGUI>();
            label.text = numbers[i].ToString();
        }
    }


    public void EnableLabels(){
        for (int i=0; i<allCanvas.Length; i++){
            TextMeshProUGUI label = parentObject.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            label.enabled = true; //Disable all the canvas.
        }
    }


    public void CaptureValue(TextMeshProUGUI label){
        Debug.Log((float) Convert.ToDouble(label.text)); //https://stackoverflow.com/questions/11202673/converting-string-to-float-in-c-sharp
  
        float captured_value = (float) Convert.ToDouble(label.text);

        if (captured_value == numbers[0]){
            Debug.Log("Right number");
            soundSources[0].Play(0); //Index 0 is success, 1 is wrong choice. 2 is finish.
            numbers.RemoveAt(0);
            label.enabled = false;
        } else {
            error_count++;
            soundSources[1].Play(0); //Index 0 is success, 1 is wrong choice. 2 is finish.
            Debug.Log("Error number: " + error_count.ToString());
        } 
    }

    public void Update(){

        //Update how many seconds have passed.
        if (activity_started == true){
            time_and_error_output.text = "Round: " + activity_limit.ToString() + "/6";
        }

        //Debug.Log(numbers.Count);

        if (numbers.Count == 0 && activity_started == true && activity_limit!=6){
            //This goes first, if not the values are not properly shown.
            activity_limit++;
            Debug.Log(activity_limit);
            if (activity_limit < 6){
                GenerateNumbers();
                EnableLabels(); //Without this, some labels will not appear.
                ShowValues();
            }
        } else if (activity_limit == 6){

            
            time_and_error_output.text = "Activity is finished, you can take the headset off.";

            //Avoid printing the same file/output over and over again.
            if (values_printed == false){
                soundSources[2].Play(0) ; //Index 0 is success, 1 is wrong choice. 2 is finish.
                Debug.Log("Error count: " + error_count.ToString() + " Time Spent (in seconds): " + time_spent.ToString());
                values_printed = true;
            }
        }
    }
}