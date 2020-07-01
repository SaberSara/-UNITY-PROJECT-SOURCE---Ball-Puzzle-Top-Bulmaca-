using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VirtualJoystickController : MonoBehaviour,IPointerUpHandler,IPointerDownHandler,IDragHandler
{
    public Image bgImg;
    public Image joystickImg;

    private Vector3 inputVector;
    //accelerometer
    private Vector3 zeroAc;
    private Vector3 curAc;
    private float sensH = 10;
    private float sensV = 10;
    private float smooth = 0.5f;
    private float GetAxisH = 0;
    private float GetAxisV = 0;
    Vector3 tilt;
    public Text debTxt;
    public Vector3 accelerationTemp;
    public float maxSpeed;
    public float minSpeed;
    public AcceleroPlayerControls acceleroInstance;
    //accelerometer
    // Start is calle
    // Start is calle
    private Rigidbody rb;

    public void OnDrag(PointerEventData eventData)
    {

        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,
                                                                    eventData.position,
                                                                    eventData.pressEventCamera,
                                                                    out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector=(inputVector.magnitude>1.0f)?inputVector.normalized:inputVector;
            
            //Move joystick imagges
            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta     .x/3),
                                                                    inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
            acceleroInstance.moveCharacter(new Vector3(Mathf.Clamp(inputVector.x, -1, 1), Mathf.Clamp(inputVector.z, -1, 1), 0));
            debTxt.text = new Vector3(inputVector.x, inputVector.z, 0.0f).ToString();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        accelerationTemp = Vector3.zero;
        /////////bgImg = GetComponent<Image>();
        /////////joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public Vector3 moveInput()
    {
        return inputVector;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
