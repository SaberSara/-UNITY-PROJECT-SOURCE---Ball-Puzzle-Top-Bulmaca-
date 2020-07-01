using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Rigidbody rb;

    public Transform circle;
    public Transform outerCircle;
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

    //accelerometer
    // Start is called b
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        accelerationTemp = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.GetComponent<Image>().rectTransform.anchoredPosition = pointA * -1;
            outerCircle.GetComponent<Image>().rectTransform.anchoredPosition = pointA * 1;
            circle.GetComponent<Image>().enabled = true;
            outerCircle.GetComponent<Image>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);

            circle.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
        }
        else
        {
            circle.GetComponent<Image>().enabled = false;
            outerCircle.GetComponent<Image>().enabled = false;
        }

    }
    void moveCharacter(Vector3 direction)
    {
        ////rb.AddForce(new Vector3(tilt.x * 68f, 0, tilt.y * 68f) ,ForceMode.Acceleration);
        curAc = Vector3.Lerp(curAc, direction - zeroAc, Time.deltaTime / smooth);
        GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
        GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
        // now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
        // If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
        // in the above equations. If some axis is going in the wrong direction, invert the
        // signal (use -curAc.x or -curAc.y)

        Vector3 movement = new Vector3(GetAxisH, 0.0f, GetAxisV);
        rb.AddForce(movement * 0.9f,ForceMode.VelocityChange);
        //player.Translate(direction * speed * Time.deltaTime);
    }
}