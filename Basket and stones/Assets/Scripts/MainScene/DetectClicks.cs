using UnityEngine;

namespace MainScene
{
    public class DetectClicks : MonoBehaviour
    {
        public GameObject StudyBoard, StudyTrigger;

        public void OnMouseDown()
        {
            StudyBoard.SetActive(false);
            StudyTrigger.SetActive(false);
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("IsFirstRun"))
            {
                PlayerPrefs.SetInt("IsFirstRun", 0);
            }


            if (PlayerPrefs.GetInt("IsFirstRun") == 1)
            {
                StudyBoard.SetActive(false);
                StudyTrigger.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("IsFirstRun") == 0)
            {
                StudyBoard.SetActive(true);
                StudyTrigger.SetActive(true);
                PlayerPrefs.SetInt("IsFirstRun", 1);
            }
        }
    }
}