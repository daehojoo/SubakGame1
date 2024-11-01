using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallCtrl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform tr;
    public RectTransform range;
    public void Start()
    {
        tr = transform;
    }
    public void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        eventData.position = tr.position;
        //Debug.Log(eventData.position);
        //Vector2 localPointPos = range.InverseTransformPoint(eventData.position);
        //if (range.rect.Contains(localPointPos))
        //{
        //    tr.position = eventData.position;
        //}
        //else if (range.rect.Contains(new Vector2(range.rect.center.x, localPointPos.y)))
        //{
        //    tr.position = new Vector2(tr.position.x, eventData.position.y);
        //}
        //else if (range.rect.Contains(new Vector2(localPointPos.x, range.rect.center.y)))
        //{
        //    tr.position = new Vector2(eventData.position.x, tr.position.y);
        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
