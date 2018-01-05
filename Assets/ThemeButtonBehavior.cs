using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThemeButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
    public string theme = "";
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = "Theme : " + theme;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.text = "Theme : ";
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    
}
