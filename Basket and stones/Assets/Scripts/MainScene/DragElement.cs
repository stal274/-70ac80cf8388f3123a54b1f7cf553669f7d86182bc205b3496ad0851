using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image mainImage;
    private Material mainMaterial;

    /// <summary>
    /// Материал, применяемый к элементам на сцене
    /// </summary>
    public Material MainMaterial
    {
        get { return mainMaterial; }
        set
        {
            if (value != null)
            {
                mainMaterial = value;
                if (mainImage != null)
                {
                    mainImage.color = MainMaterial.color;
                }
            }
        }
    }

    private Transform defaultParentTransform;

    public Transform DefaultParentTransform
    {
        get { return defaultParentTransform; }
        set
        {
            if (value != null)
            {
                defaultParentTransform = value;
            }
        }
    }

    private Transform dragParentTransform;

    public Transform DragParentTransform
    {
        get { return dragParentTransform; }
        set
        {
            if (value != null)
            {
                dragParentTransform = value;
            }
        }
    }

    private int siblingindex;

    public int Siblingindex
    {
        get { return siblingindex; }
        set
        {
            if (value > 0)
            {
                siblingindex = value;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(DragParentTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParentTransform);
        transform.SetSiblingIndex(Siblingindex);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = mainMaterial;
        }
    }
}