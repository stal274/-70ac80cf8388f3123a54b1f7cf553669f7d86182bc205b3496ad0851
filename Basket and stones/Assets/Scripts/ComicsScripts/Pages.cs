using UnityEngine;

[CreateAssetMenu(fileName = "ComicsBook", menuName = "ComicsBook")] // выпадающее меню редактора "Create"
public class Pages : ScriptableObject
{
    [SerializeField]
    private PageData[] pages;
    public int i = 0;
    public int countOfPages;
    public PageData PageGet()
    {
        return pages[i];
    }
    public PageData PageGetNext()
    {

        i++;
        return pages[i];
    }
}
