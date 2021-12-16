using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class RAManager : MonoBehaviour, IVirtualButtonEventHandler
{
    public static RAManager Instance;

    public VirtualButtonBehaviour[] virtualButtons;
    public GameObject car;
    public GameObject colors_ui;
    public GameObject text_ui;
    public VideoPlayer video;

    public GameObject[] spoilers;
    public GameObject[] wheels; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        GameObject.DontDestroyOnLoad(this.gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        ShowCar();
        foreach (var virtualButton in virtualButtons)
            virtualButton.RegisterEventHandler(this);
    }

    public void OnButtonPressed (VirtualButtonBehaviour vb)
    {
        Debug.Log("On VButton press: " + vb.name);

        switch(vb.name)
        {
            case "VirtualButton3D":
                ShowCar();
                break;
            case "VirtualButtonInfo":
                ShowInfo();
                break;
            case "VirtualButtonVideo":
                ShowVideo();
                break;
            default:
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("On VButton release: " + vb.name);
    }

    public void ObjectClicked(GameObject objectClicked)
    {
        Debug.Log(objectClicked.name);

        switch (objectClicked.name)
        {
            case "Spoiler_A":
                SetCarSpoilerVisible(spoilers[0]);
                break;
            case "Spoiler_B":
                SetCarSpoilerVisible(spoilers[1]);
                break;
            case "Wheel_A":
                SetCarWheelVisible(wheels[0]);
                break;
            case "Wheel_B":
                SetCarWheelVisible(wheels[1]);
                break;
            case "Wheel_C":
                SetCarWheelVisible(wheels[2]);
                break;
            case "Wheel_D":
                SetCarWheelVisible(wheels[3]);
                break;
            default:
                break;
        }
    }

    private void SetCarSpoilerVisible (GameObject gameObject)
    {
        foreach(var spoiler in spoilers)
            spoiler.SetActive(false);

        gameObject.SetActive(true);
    }


    private void SetCarWheelVisible(GameObject gameObject)
    {
        foreach (var wheel in wheels)
            wheel.SetActive(false);

        gameObject.SetActive(true);
    }

    private void ShowCar() 
    {
        car.SetActive(true);
        colors_ui.SetActive(true);
        text_ui.SetActive(false);
        video.gameObject.SetActive(false);
        video.Stop();
    }
    private void ShowInfo() 
    {
        car.SetActive(false);
        colors_ui.SetActive(false);
        text_ui.SetActive(true);
        video.gameObject.SetActive(false);
        video.Stop();

    }
    private void ShowVideo() 
    {
        car.SetActive(false);
        colors_ui.SetActive(false);
        text_ui.SetActive(false);
        video.gameObject.SetActive(true);
        video.Play();
    }

}
