using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /// <summary>
    /// 拖拽对象
    /// </summary>
    public Transform _Target;//可拖拽区域

    /// <summary>
    /// 拖拽对象RectTransform
    /// </summary>
    public RectTransform _TargetRect;//整个窗口

    private bool isDrag;

    private Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = false;
        SetDragObjPostion(eventData);
        _TargetRect.transform.SetSiblingIndex(1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        SetDragObjPostion(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetDragObjPostion(eventData);
    }

    void SetDragObjPostion(PointerEventData eventData)
    {

        Vector3 mouseWorldPosition;

        //判断是否点到UI图片上的时候
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_TargetRect, eventData.position, eventData.pressEventCamera, out mouseWorldPosition))
        {
            if (isDrag)
            {
                _TargetRect.position = mouseWorldPosition + offset;
            }
            else
            {
                //计算偏移量
                offset = _TargetRect.position - mouseWorldPosition;
            }
        }

        CheckMaxPos();
    }
    void CheckMaxPos()
    {
        // 世界空间
        Vector2 minworld = transform.TransformPoint(_TargetRect.rect.min);
        Vector2 maxworld = transform.TransformPoint(_TargetRect.rect.max);
        Vector2 sizeworld = maxworld - minworld;

        // 保持最小的位置在屏幕边界-大小
        maxworld = new Vector2(Screen.width, Screen.height) - sizeworld;

        // 保持位置在(0,0)和maxworld之间

        float y = Mathf.Clamp(minworld.y, 0, maxworld.y);

        float x = Mathf.Clamp(minworld.x, 0, maxworld.x);

        // set new position to xy(=local) + offset(=world)设置新位置为xy(=本地)+偏移量(=世界)
        Vector2 offset = (Vector2)transform.position - minworld;
        transform.position = new Vector2(x, y) + offset;
    }
}