using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComicsBook", menuName = "ComicsBook")] // выпадающее меню редактора "Create"
public class Pages : ScriptableObject
{
	[SerializeField]
	private PageData[] pages;
}
