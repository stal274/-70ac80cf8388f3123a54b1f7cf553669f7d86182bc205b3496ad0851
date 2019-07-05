using UnityEngine;


namespace Comics
{
    public class DetectClicks : MonoBehaviour
    {
        private Vector2 startPosition, endPosition;
        private float step = 0.02f;
        private float progress;
        private bool Click;
        private GameObject back0, back1;

        private int i;
        private GameObject ResumeSlide;

        private void Start()
        {
            ResumeSlide = GameObject.Find("Button");
            i = 0;
            back0 = GameObject.Find("Back_0");
            back1 = GameObject.Find("Back_1");
            startPosition = gameObject.transform.position;
            endPosition = new Vector2(startPosition.x - Screen.width / 4, 0);
            ResumeSlide.SetActive(false);
            Invoke("ButtonActive", 5);
        }

        public void OnMouseDown()
        {
            if (ResumeSlide.activeSelf)
            {
                Click = true;
                i++;
                ResumeSlide.SetActive(false);
                Invoke("ButtonActive", 5);
            }
        }

        private void ButtonActive()
        {
            ResumeSlide.SetActive(true);
        }

        private void FixedUpdate()
        {
            if (Click && back0.activeSelf)
            {
                back0.transform.position = Vector2.Lerp(startPosition, endPosition, progress);
                progress += step;
                if (i == 1 && back0.transform.position.x != endPosition.x)
                {
                    GameObject.Find("Sprite_0").GetComponent<UnityEngine.Animation>()
                        .Play("Comics_back");
                    GameObject.Find("Sprite_1").GetComponent<UnityEngine.Animation>()
                        .Play("Comics_back");
                    GameObject.Find("Sprite_2").GetComponent<UnityEngine.Animation>()
                        .Play("Comics_back");
                }

                else if (back0.transform.position.x == endPosition.x && i == 1)
                {
                    GameObject.Find("Slide_0").SetActive(false);

                    ResumeSlide.SetActive(true);
                }
                else if (back0.transform.position.x == endPosition.x && i == 3)
                {
                    back0.GetComponent<UnityEngine.Animation>().Play();
                    i++;
                }
            }
            /*else if (Click)
            {
            }*/

            {
            }
        }
    }
}