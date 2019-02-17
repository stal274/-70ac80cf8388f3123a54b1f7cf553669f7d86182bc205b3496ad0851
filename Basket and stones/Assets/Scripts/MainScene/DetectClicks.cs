using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClicks : MonoBehaviour {
    public GameObject StudyBoard, StudyTrigger;
    public void OnMouseDown()
    {
        StudyBoard.SetActive(false);
        StudyTrigger.SetActive(false);
    }
}
