using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class comicsscript : MonoBehaviour
{
    private Image _image;
    [SerializeField]
    private Pages comix;

    // Start is called before the first frame update
    private void Start()
    {
        comix.i = 0;
        _image = GetComponent<Image>();
        _image.sprite = comix.PageGet().ImageGet();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _image.sprite = comix.PageGetNext().ImageGet();
        }
        else if (Input.touchCount > 0)
        {
            _image.sprite = comix.PageGetNext().ImageGet();
        }

        if (comix.i == comix.countOfPages - 1)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
