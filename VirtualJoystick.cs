using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler,IPointerUpHandler {

	private Image bgImage;
	private Image joystickImage;
	public Vector3 inputVector;

	void Start()
	{
		bgImage = GetComponent<Image>();
		joystickImage = transform.GetChild(0).GetComponent<Image>();
	}

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform,eventData.position,eventData.pressEventCamera,out pos)){
			pos.x = (pos.x/bgImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y/bgImage.rectTransform.sizeDelta.y);	
			//float x =(bgImage.rectTransform.pivot.x==1) ? pos.x *2+1 :  pos.x*2-1;
			//float y =(bgImage.rectTransform.pivot.y==1) ? pos.y *2+1 :  pos.y*2-1;
			inputVector = new Vector3(pos.x*2+1,0,pos.y*2-1);
			inputVector = (inputVector.magnitude>1.0f)?inputVector.normalized:inputVector;
			joystickImage.rectTransform.anchoredPosition =
			 new Vector3(inputVector.x*(bgImage.rectTransform.sizeDelta.x/3),inputVector.z*(bgImage.rectTransform.sizeDelta.y/3));
			Debug.Log(inputVector);
		}

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
		inputVector = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

	public float MoveHorizontal(){
		if(inputVector.x!=0) return inputVector.x;
		else	return Input.GetAxis("Horizontal1");
	}
	public float MoveVertical(){
		if(inputVector.z!=0) return inputVector.z;
		else	return Input.GetAxis("Vertical1");
	}
}
