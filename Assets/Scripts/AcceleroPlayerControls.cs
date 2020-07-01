using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceleroPlayerControls : MonoBehaviour
{
    // Move object using accelerometer
    float speed=368 ;
    private Rigidbody rb;
    public bool isFlat = true;
    public float horizontalDump;
    public float verticalDump;
    public Text debTxt;
    public Vector3 accelerationTemp;
    public float maxSpeed;
    public float minSpeed;
    public GameObject gameManager;
    private GameManager gameManagerInstance;
    //accelerometer
    private Vector3 zeroAc;
    private Vector3 curAc;
    private float sensH = 10;
    private float sensV = 10;
    private float smooth = 0.5f;
    private float GetAxisH = 0;
    private float GetAxisV = 0;
    public Joystick virJoystick;
    SoundManager soundManagerInstance;
    Vector3 tilt ;
    float defaaaultDragging
        
     ;
    bool point;
    public GameObject virtualJoysticksUIs;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerInstance = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        defaaaultDragging = rb.drag;
        accelerationTemp = Vector3.zero;
        soundManagerInstance = FindObjectOfType<SoundManager>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(rb.velocity.x<=0.09f || rb.velocity.z<=0.09f || rb.velocity.z<=0.09f || !gameManagerInstance.isGameStarted)
        {
            //NO Good sounds or time to find souhnds :)
            //soundManagerInstance.stop("S_SFX_ROLLS");
        }
        
        if (gameManagerInstance.isAccelerometer && gameManagerInstance.isGameStarted)
        {
           
            //debTxt.text = "tittz=" + tilt.z + ", tiltty=" + tilt.y + "  ,tilt x=" + tilt.x;
            


            tilt = Input.acceleration;
            tilt = Quaternion.Euler(90.0f, 0.0f, 0.0f) * tilt;


            //else tilt=Vector3.zero;
            if (tilt.sqrMagnitude > 1)
            {
                tilt.Normalize();
            }
            if (isFlat)
            {
                tilt = Quaternion.Euler(90.0f, 0.0f, 0.0f) * tilt;

            }
            //tilt = tilt * 18.0f;
            Vector3 tiltSpeed = new Vector3(tilt.x, 0.0f, tilt.z);

            

           
            ///tilt *= Mathf.Pow(1f - horizontalDump, Time.deltaTime * 10f);
            ///rb.velocity = new Vector3(fHorizontalVeloX, 0.0f, fVerticalVeloZ );
            //Clamping

            ////rb.AddForce(new Vector3(tilt.x * 68f, 0, tilt.y * 68f) ,ForceMode.Acceleration);
            curAc = Vector3.Lerp(curAc, Input.acceleration - zeroAc, Time.deltaTime / smooth);
            GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
            GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
            // now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
            // If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
            // in the above equations. If some axis is going in the wrong direction, invert the
            // signal (use -curAc.x or -curAc.y)

            Vector3 movement = new Vector3(GetAxisH, 0.0f, GetAxisV);
            rb.AddForce(movement * 0.29f);
            //rb.AddForceAtPosition(new Vector3(fHorizontalVeloX, 0, fVerticalVeloZ), transform.position, ForceMode.Acceleration);

            /////rb.AddTorque(tilt.x, 0, tilt.z);
            Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
            //NO Good sounds or time to find souhnds :)
            //soundManagerInstance.continuePlayWithVolume("S_SFX_ROLLS", 0.9f);

        }
        else if (!gameManagerInstance.isJoystick && !gameManagerInstance.isAccelerometer && gameManagerInstance.isGameStarted)
        {
            //NO Good sounds or time to find souhnds :)
            //soundManagerInstance.continuePlayWithVolume("S_SFX_ROLLS", 0.9f);
            virtualJoysticksUIs.SetActive(true);
            debTxt.text = new Vector3(Mathf.Clamp(virJoystick.Horizontal, 0, 1), 0, Mathf.Clamp(virJoystick.Vertical, 0, 1)).ToString();
            virJoystick = FindObjectOfType<Joystick>();
        }
        
        ///else

        ///m
        ///
        if (point)
        {
            rb.drag = defaaaultDragging;
            moveCharacter(new Vector3(Mathf.Clamp(virJoystick.Direction.x, -1, 1), Mathf.Clamp(virJoystick.Direction.y, -1, 1), 0.00f));
        }
        ///Vector2 newDirection = Vector2.ClampMagnitude(virJoystick.Direction, 1.0f);
        
        else
        {
            ////rb.velocity = rb.velocity * 0.9f;
            ////rb.angularVelocity = rb.angularVelocity * 0.9f;

            curAc = Vector3.Lerp(curAc, rb.velocity * -0.15f, Time.deltaTime / smooth);
            rb.drag = 0.9999f;
        }


    }

    public void moveCharacterVoid()
    {
        point = true;
        ///Vector2 newDirection = Vector2.ClampMagnitude(virJoystick.Direction, 1.0f);
        //moveCharacter(new Vector3(Mathf.Clamp(virJoystick.Direction.x, -1, 1), Mathf.Clamp(virJoystick.Direction.y, -1, 1), 0.00f));
        rb.drag = defaaaultDragging;
    }
   
    public void moveCharacter(Vector3 direction)
    {
        rb.drag = defaaaultDragging;
        ////rb.AddForce(new Vector3(tilt.x * 68f, 0, tilt.y * 68f) ,ForceMode.Acceleration);
        curAc = Vector3.Lerp(curAc, direction - zeroAc, Time.deltaTime / smooth);
        GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
        GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
        // now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
        // If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
        // in the above equations. If some axis is going in the wrong direction, invert the
        // signal (use -curAc.x or -curAc.y)

        ///rb.velocity = Mathf.Clamp(force, -rb.mass / Time.fixedDeltaTime, rb.mass / Time.fixedDeltaTime);
        Vector3 movement = new Vector3(GetAxisH, 0.0f, GetAxisV);
        ////rb.AddForceAtPosition(movement * 0.57f,transform.localPosition, ForceMode.VelocityChange);
        rb.AddForce(movement * 6.57f, ForceMode.Acceleration);

        
    }


    public void decreassSpeed()
    {
        point = false;
        Debug.Log("UPPPPPDIPSSSSSSUSDHSDSSSSSDSDDDDDDFERS");
        
        
    }
}
