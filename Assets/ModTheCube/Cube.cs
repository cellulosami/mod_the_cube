using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float orbitSpeed;
    public float orbitWidth;
    public float orbitHeight;
    private float orbitTime;
    
    void Start()
    {
        //setup orbit variables
        // orbitSpeed = 1;
        // orbitWidth = 1;
        // orbitHeight = 1;


        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        orbitTime += Time.deltaTime * orbitSpeed;

        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        //orbit cube
        float x = Mathf.Cos(orbitTime) * orbitWidth;
        float y = Mathf.Sin(orbitTime) * orbitHeight;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
