using GameScene;
using UnityEngine;

namespace MainScene
{
    public class TapToExit : MonoBehaviour, IPhoneButtons
    {
        [SerializeField] private GameObject[] Windows;

        private void Update()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            HardwareButtons(KeyCode.Escape);
        }

        public void HardwareButtons(KeyCode escapeButton)
        {
            if (!Input.GetKeyDown(escapeButton))
            {
                return;
            }
            /*for (var i = 0; i < Windows.Length; i++)
{
   if (!Windows[i].activeSelf || i <= 0) continue;
   Windows[i - 1].SetActive(true);
   Windows[i].SetActive(false);
   break;
}*/
            if (Windows[0].activeSelf)
            {
                Application.Quit();
            }
            else if (Windows[1].activeSelf)

            {
                Windows[0].SetActive(true);
                Windows[1].SetActive(false);
            }

            else if (Windows[2].activeSelf)

            {
                Windows[1].SetActive(true);
                Windows[2].SetActive(false);
            }
          
            new WaitForSeconds(0.05f);


        }
    }
}