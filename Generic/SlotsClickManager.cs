using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsClickManager : Slots
     , IPointerClickHandler // 2
     , IDragHandler
     , IPointerEnterHandler
     , IPointerExitHandler
     , IPointerUpHandler
     , IDropHandler
    , IEndDragHandler
{
    static Items holdingItem, holdingItem2;
    static bool switching,onDropCalled, switchItems;
    void Awake()
    {
       
    }

    void Update()
    {
     
    }


    public void OnPointerClick(PointerEventData eventData) // 3
    {
          print("I was clicked");
       // holdingItem = TakeItem();
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        holdingItem = this.GetItem();


        switching = !FreeSlot();

       // print(holdingItem + " is being dragged! Switching? " + switching);

       

        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.GetChild(0).position = Camera.main.ScreenToWorldPoint(screenPoint);

       // transform.GetChild(0).position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
  
    }
    public void OnPointerUp(PointerEventData eventData)
    {
      //  print("Click Released");
    }
    public void OnDrop(PointerEventData eventData)
    {
        //print("On Drop 1 " + this.name + ", Item: " + this.GetItem() + " holding item: " + holdingItem + ", holding item2: " + holdingItem2 + ", switching: " + switching + ", on drop called: " + onDropCalled + ", switchItems: " + switchItems);
       // print("On Drop: " + this.name);
        // transform.GetChild(0).localPosition = Vector3.zero;
        onDropCalled = true;
        if (switching)
        {
           // print("switching but does it have a free slot? " + this.FreeSlot());

            if (!this.FreeSlot())
            {
                switchItems = true;
                holdingItem2 = TakeItem();
               // print("Holding previous item in the item slot");
            }

            this.setItem(holdingItem);
        }
        
       // print("On Drop 2 " + this.name + ", Item: " + this.GetItem() + " holding item: " + holdingItem + ", holding item2: " + holdingItem2 + ", switching: " + switching + ", on drop called: " + onDropCalled + ", switchItems: " + switchItems);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //print("On end Drop 1 " + this.name + ", Item: " + this.GetItem() + " holding item: " + holdingItem + ", holding item2: " + holdingItem2 + ", switching: " + switching + ", on drop called: " + onDropCalled + ", switchItems: " + switchItems);

       // print("On End Drop: " + this.name);
        //  print("Switching? " + switching);
        if (switching&& onDropCalled)
        {
            item = holdingItem2;
            //  print("Switching: " + holdingItem + " with " + this.GetItem());
            this.TakeItem();
            
            if(switchItems)
                this.setItem(holdingItem2);
           // setItem(holdingItem);
        }
        else
        {
            this.setItem(holdingItem);
        }
       // print("On end Drop 2 " + this.name + ", Item: " + this.GetItem() + " holding item: " + holdingItem + ", holding item2: " + holdingItem2 + ", switching: " + switching + ", on drop called: " + onDropCalled + ", switchItems: " + switchItems);

        transform.GetChild(0).localPosition = Vector3.zero;
        switching = false;
        onDropCalled = false;
        switchItems = false;
        
        holdingItem = null;
        holdingItem2 = null;
       // print("On end Drop 3 " + this.name + ", Item: " + this.GetItem() + " holding item: " + holdingItem + ", holding item2: " + holdingItem2 + ", switching: " + switching + ", on drop called: " + onDropCalled + ", switchItems: " + switchItems);
        // holdingItem = null;
        // print("End Drag " + this.name + ", Item: " + this.GetItem());
    }
}
