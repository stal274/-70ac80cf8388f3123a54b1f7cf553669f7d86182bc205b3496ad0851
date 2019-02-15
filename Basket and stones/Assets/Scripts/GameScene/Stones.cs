using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{

    public GameObject stone;
    private List<GameObject> stoneList;
	// Use this for initialization
	
    public void addStone(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(stone, new Vector3(transform.position.x, transform.position.y),
                new Quaternion(0, 0, 0, 0));
        }
    }
    
    
    
}
