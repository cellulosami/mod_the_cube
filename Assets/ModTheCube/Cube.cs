using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    //orbit variables 
    public float orbitSpeed;
    public float orbitWidth;
    public float orbitHeight;
    private float orbitTime;
    
    //scale variables
    public float scaleSpeed;
    public float scaleMagnitude;
    private float scaleTime;

    //color variables
    private string currentColor = "red";
    private float blue = 1.0f;
    private float green = 0.0f;
    private float red = 0.0f;
    public float colorSpeed;


    void Start()
    {
        orbitSpeed = Random.Range(0, 10);
        scaleSpeed = Random.Range(0, 5);
        colorSpeed = Random.Range(0, 20) * 0.1f;
    }
    
    void Update()
    {
        scaleTime += Time.deltaTime * scaleSpeed;
        orbitTime += Time.deltaTime * orbitSpeed;

        transform.Rotate(-50.0f * Time.deltaTime, -50.0f * Time.deltaTime, 0.0f);

        //orbit cube
        float x = Mathf.Cos(orbitTime) * orbitWidth;
        float y = Mathf.Sin(orbitTime) * orbitHeight;
        transform.position = new Vector3(x, y, transform.position.z);

        //scale cube
        float currentScale = (Mathf.Sin(scaleTime)) + 1;
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);

        //color cube
        if (currentColor == "red" && blue <= 0.0f) {
            currentColor = "green";
        } else if (currentColor == "green" && red <= 0.0f) {
            currentColor = "blue";
        } else if (currentColor =="blue" && green <= 0.0f) {
            currentColor = "red";
        }
        
        if (currentColor == "red") {
            if (red <= 1.0f) {
                red += 0.01f * colorSpeed;
            } else {
                blue -= 0.01f * colorSpeed;
            }
        } else if (currentColor == "green") {
            if (green <= 1.0f) {
                green += 0.01f * colorSpeed;
            } else {
                red -= 0.01f * colorSpeed;
            }
        } else if (currentColor == "blue") {
            if (blue <= 1.0f) {
                blue += 0.01f * colorSpeed;
            } else {
                green -= 0.01f * colorSpeed;
            }
        }

        Renderer.material.color = new Color(red, green, blue, 1);
    }
}
