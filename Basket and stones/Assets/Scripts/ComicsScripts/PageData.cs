﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ComicsPage", menuName = "PageOfComics")] // выпадающее меню редактора "Create"
public class PageData : ScriptableObject
{
	// Start is called before the first frame update
	[SerializeField]
	private Sprite _page;
}
