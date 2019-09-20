using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudyPanel : MonoBehaviour
{
    [SerializeField] private GameObject studyPanel, mainMenuWindow;
    [SerializeField] private GameObject[] objectsToHide;
    private void Start()
    {
        mainMenuWindow = GameObject.Find("MainMenuWindow");
        
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("IsStudy") == 0)
        {
            StartCoroutine(ActivationOfPanel());
        }
    }
    private IEnumerator ActivationOfPanel()
    {

        yield return new WaitForSeconds(2f);
        studyPanel.SetActive(true);
        foreach (var i in objectsToHide)
        {
            i.SetActive(false);
        }
    }
    public void OnClick(GameObject @object)
    {
        switch (@object.name)
        {
            case "Yes":
                studyPanel.SetActive(false);
                foreach (var i in objectsToHide)
                {
                    i.SetActive(true);
                }
                break;
            case "No":
                SceneManager.LoadScene("StudyGameScene");
                break;

        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
