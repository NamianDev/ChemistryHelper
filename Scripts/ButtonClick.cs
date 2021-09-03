using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler
{
	public ElementScript es;
    


	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.name == "Left")
		{
			es.CurrentID -= 1;
			es.ReadElement(es.CurrentID, es.txtAsset);
		}
		else if (this.name == "Right")
		{
			es.CurrentID += 1;
			es.ReadElement(es.CurrentID, es.txtAsset);
		}
	}
}
