using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    private GameObject[] carList;
    private int currentCar = 0;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
        carList = new GameObject[transform.childCount];

        for(int i=0; i<transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
            
        }

        foreach(GameObject gameObj in carList)
        {
            gameObj.SetActive(false);
        }
        if (carList[0])
        {
            carList[0].SetActive(true);
            anim = carList[0].GetComponent<Animator>();
            anim.SetTrigger("spin");
        }
    }

    public void toggleCars(string direction)
    {
        carList[currentCar].SetActive(false);

        if(direction == "Right")
        {
            currentCar++;
            if(currentCar > carList.Length - 1)
            {
                currentCar = 0;
            }
        }
        else if(direction == "Left")
        {
            currentCar--;
            if (currentCar < 0)
            {
                currentCar = carList.Length - 1;
            }
            
        }
        //Set the current car to be active car list
        carList[currentCar].SetActive(true);
        anim = carList[currentCar].GetComponent<Animator>();
        anim.SetTrigger("spin");
        gameController.currentCarSelected = carList[currentCar].name;
       

    }
     
}




