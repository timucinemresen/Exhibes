using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotoTaker : MonoBehaviour
{
    private Texture2D PhotoTaken;
    public RawImage rawImage;
    public GameObject controller;
    public ExhibesController controllerScript;
    public bool IsTaken = false;
    private WebCamTexture webcamTexture = new WebCamTexture();

    private void Start()
    {
        controller = GameObject.Find("MainCanvas");
        controllerScript = controller.GetComponent<ExhibesController>();

        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        webcamTexture.Play();


    }



}
