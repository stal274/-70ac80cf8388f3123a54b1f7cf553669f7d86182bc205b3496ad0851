using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float coolTimer = 99;
    public Text timer;
	// Use this for initialization
	void Start ()
	{
		
	}
	// Update is called once per frame
	void Update ()
	{
	    minusSecond();
	}

    void minusSecond()
    {
        coolTimer -= Time.deltaTime;
        timer.text = Mathf.RoundToInt(coolTimer).ToString();
    }
}