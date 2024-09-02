using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject lights;
    public GameObject lighting;
    public GameObject tv;
    public GameObject corner;
    public GameObject well;
    public GameObject trigger;
    public Material Camera;
    public Material Blank;
    private bool blink = true;

    /*private void Awake()
    {
        while(blink)
        {
            Invoke("lightsoff", 3);
            Invoke("lightson", 6);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        blink = false;
        firstphase();
        Invoke("turnoffTV", 5);
        Invoke("secondphase", 7);
        Invoke("thirdphase", 10);
    }

    private void firstphase()
    {
        lights.SetActive(false);
        corner.SetActive(false);
        well.SetActive(false);
        tv.GetComponent<Renderer>().material = Camera;
        tv.GetComponent<AudioSource>().enabled = false ;
        trigger.SetActive(false);
    }

    private void turnoffTV()
    {
        tv.GetComponent<Renderer>().material = Blank;
        tv.GetComponent<AudioSource>().enabled = true;
    }

    private void secondphase()
    {
        well.SetActive(true);
        tv.GetComponent<Renderer>().material = Camera;
        tv.GetComponent<AudioSource>().enabled = false;
    }

    private void thirdphase()
    {
        lights.SetActive(true);
        corner.SetActive(true);
        well.SetActive(true);
        tv.GetComponent<Renderer>().material = Blank;
        tv.GetComponent<AudioSource>().enabled = true;
        trigger.SetActive(true);
        blink = true;
    }

    private void lightson()
    {
        lighting.SetActive(true);
    }

    private void lightsoff()
    {
        lighting.SetActive(false);
    }
    
}
