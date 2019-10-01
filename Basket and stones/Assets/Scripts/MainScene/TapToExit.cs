using GameScene;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainScene
{
    public class TapToExit : MonoBehaviour, IPhoneButtons
    {
        [FormerlySerializedAs("Windows")] [SerializeField]
        private GameObject[] windows;

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
            if (windows[0].activeSelf)
            {
                Application.Quit();
            }
            else if (windows[1].activeSelf)

            {
                windows[0].SetActive(true);
                windows[1].SetActive(false);
            }

            else if (windows[2].activeSelf)

            {
                windows[1].SetActive(true);
                windows[2].SetActive(false);
            }

            new WaitForSeconds(0.05f);
        }
    }
}