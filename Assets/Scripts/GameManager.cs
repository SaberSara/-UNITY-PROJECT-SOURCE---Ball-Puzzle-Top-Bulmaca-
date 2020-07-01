using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Puzzle BallG Game' s Game Manager
/// </summary>
public class GameManager : MonoBehaviour
{
    //----Attributs
    public int lives = 1;
    public int rubyScore = 0;
    public int rubyValuesV1;
    public bool isKeyBlueFound = false;
    public bool isKeyYellowFound = false;
    public bool isKeyGreenFound = false;
    public bool isBallBlue = false;
    public bool isBallYellow = false;
    public bool isBallGreen = false;
    public Text rubyScoreTxt ;
    //public int rubyValueV2;
    public bool enteredPortalLvl1=false;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesTxt;
    public GameObject gameOverGO;
    public GameObject UIGGO;
    public GameObject youWonGO;
    public GameObject levelsGO;
    public GameObject endPositionsPrefabsGO;
    public GameObject startPositionsPrefabGO;
    public float blendsSpeed;
    public Color startColor;
    public Color endColor;
    private float blendStartTime;
    public bool blendingRepeatable = false;
    public GameObject BlueDoorPrefabGO;
    public GameObject YellowDoorPrefabGO;
    public GameObject GreenDoorPrefabGO;
    public GameObject virtualJoysticksUIs;
    public Material blueMat;
    public GameObject levelManagerGO;
    public GameObject playerPrefabGO;
    public GameObject soundManagerGO;
    public GameObject playerPrefabTrailGO;
    public GameObject hollowParticlesGO;
    public GameObject deathParticlesGO;
    public static GameManager instance = null;
    public Renderer playerRenderer;
    public Renderer trailRenderer;
    public Renderer hollowRenderer;

    
    
    private GameObject clonePlayerPrefabGO;
    
    Joystick virtJoystick;
    SoundManager soundManagerInstance;
    bool isGameWon=false;

    public bool isGameStarted;
    public bool isJoystick;
    public bool isAccelerometer;

    //----Methods
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
        Setup();
    }

    //Functions Initializes comp 
    public void InitializeComponenents()
    {
        soundManagerInstance = FindObjectOfType<SoundManager>();
    }
    //Setup Functions
    public void Setup()
    {
        
        UIGGO.SetActive(false);
        virtualJoysticksUIs.SetActive(false);
        isGameStarted = false;
        isAccelerometer = false;
        isJoystick = true;
        //clonePlayerPrefabGO= Instantiate(playerPrefabGO, startPositionsPrefabGO.transform.position, Quaternion.identity) as GameObject;
        playerPrefabGO.SetActive(false);
        //A little bug in it and im too lazy to see what it is , i m keeping position and instance and moving the player to start position insteads of instantiate,
        //beter forr res aloso
        playerPrefabGO.transform.SetPositionAndRotation(startPositionsPrefabGO.transform.position, Quaternion.identity);
        hollowParticlesGO.GetComponent<ParticleSystem>().Play();
        playerPrefabGO.SetActive(true);
         playerRenderer = playerPrefabGO.GetComponent<Renderer>();
        trailRenderer = playerPrefabTrailGO.GetComponent<Renderer>();
        hollowRenderer = hollowParticlesGO.GetComponent<Renderer>();

    }

    //Function startGame
    public void gameStarted()
    {
        
        isGameStarted = true;
        ///gameOverGO.SetActive(false);
        UIGGO.SetActive(true);
        
        updateUI();
    }

    //EFunctctction enabling the mouvments either accelerometer orr joysticks
    public void enableAccelerometer(bool isAcceleroEnabled)
    {
        if(isAcceleroEnabled)
        {
            isAccelerometer = true;
            isJoystick = false;

        }
        else { 
            isAccelerometer = false;
            isJoystick = true;

        }

    }
    //Function updateUI
    public void updateUI()
    {
        rubyScoreTxt.text = "Points: " + rubyScore.ToString();
    }

    public void activateJoystick()
    {
        if(isJoystick && isGameStarted)
        {
            virtualJoysticksUIs.SetActive(true);
            virtJoystick = FindObjectOfType<Joystick>();
            FindObjectOfType<AcceleroPlayerControls>().virJoystick = virtJoystick;


        }
    }
    //CheckGameOver Functions
    public void CheckGameOver()
    {
        if (enteredPortalLvl1)
        {
           //////////////////// youWonGO.SetActive(true);
            
            Time.timeScale = 0.25f;
            playerPrefabGO.SetActive(false);
            isGameStarted = false;
            isGameWon = true;
            Invoke("sceneLoad", resetDelay);

            
        }
        if (lives < 1)
        {
            /// gameOverGO.SetActive(true);
            Instantiate(deathParticlesGO, playerPrefabGO.transform.position, Quaternion.identity);
            Time.timeScale = 0.25f;
            playerPrefabGO.SetActive(false);
            /////Invoke("AnimateDeath", resetDelay);

            Invoke("Reset", resetDelay);


        }


    }


    //Function to load scenes
    public void sceneLoad()
    {
        float actualSceneBuild=SceneManager.GetActiveScene().buildIndex;
        if (actualSceneBuild>=0 && actualSceneBuild<SceneManager.sceneCountInBuildSettings-1)//We dont call a scene nt her in cuilui
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        //Or if we look for another Design techniques for the Game rules and UX experience we could at every end of maze invoke the Map or levels lit

    }
    //Function Change Color of the ball
    public void changeColors()
    {
        if(isBallBlue)
        {

            blendStartTime = Time.time;
            startColor = playerRenderer.material.GetColor("_Color");
            endColor = Color.yellow;
            /// or.blue);
            playerRenderer.material.SetColor("_Color", Color.blue);
            trailRenderer.material.SetColor("_Color", Color.blue);
            hollowRenderer.material.SetColor("_TintColor", Color.blue);
            //Change Ball Color
            ///soundManagerInstance.play("S_SFX_PAINTS");
            ///Trials
            ///Trails
            //Pop the Key
        }
        if (isBallYellow)
        {
            //Changed blending (touu much color_)
            /*blendStartTime = Time.time;
            startColor = playerRenderer.material.color;
            endColor = Color.yellow;
            */
            
            //Change Ball Color
            playerRenderer.material.SetColor("_Color", Color.yellow);
            trailRenderer.material.SetColor("_Color", Color.yellow);
            hollowRenderer.material.SetColor("_TintColor", Color.yellow);
            ///soundManagerInstance.play("S_SFX_PAINTS");
            ///Trails
            //Pop the Key
        }
        if (isBallGreen)
        {
            //Changed blending (touu much color_)blendStartTime = Time.time;
            playerRenderer.material.SetColor("_Color", Color.green);
            trailRenderer.material.SetColor("_Color", Color.green);
            hollowRenderer.material.SetColor("_TintColor", Color.green);
            ///soundManagerInstance.play("S_SFX_PAINTS");
        }
        
    }
    public void AnimateDeath()
    {

        //Play sounds
        
        CancelInvoke(); //we cancell our actual oldprevi invokess
        playerPrefabGO.SetActive(false);
        Invoke("Reset", resetDelay);
    }
    //Function to opens fences
    public void openFences()
    {
        if(isKeyYellowFound)
        {
            Debug.Log("Founs Yellow");
            //Open Doors
            YellowDoorPrefabGO.SetActive(false);//After we can play some animations
            //Deactivate effects
            //Play sounds
        }
        if(isKeyBlueFound)
        {
            Debug.Log("Founs Bleueuee");
            //Open Doors
            BlueDoorPrefabGO.SetActive(false);//After we can play some animations
            //Deactivate effects
            //Play sounds
        }
        if (isKeyGreenFound)
        {
            Debug.Log("Founs Gren");
            //Open Doors
            GreenDoorPrefabGO.SetActive(false);//After we can play some animations
            //Deactivate effects
            //Play sounds

        }
    }
    //Function checkLevel
    public void CheckLevel()
    {
       
    }

    //DestroyBlockss Functions
    public void Collects()
    {
        rubyScore+=rubyValuesV1;
        //Suounds
        //Animation?
        // UpdateUI();
        updateUI();
        CheckGameOver();
    }
    

    //Resets Functions
    [System.Obsolete]
    private void Reset()
    {
        Time.timeScale = 1f;
        Setup();
        SceneManager.LoadScene(0);
        //obsolete =)Application.LoadLevel(Application.loadedLevel);
    }
    //SetupPaddles Functions
    private void SetupLevel()
    {
        ///clonePaddleGO = Instantiate(paddleGO, transform.position, Quaternion.identity) as GameObject;
    }

    private void Update()
    {
        //Remove it simple colorrs 
        /*if (!blendingRepeatable)
        {
            float t = (Time.time - blendStartTime ) * blendsSpeed;
            trailRenderer.material.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            float t = (Mathf.Sin(Time.time - blendStartTime) * blendsSpeed);
            trailRenderer.material.color = Color.Lerp(startColor, endColor, t);
        }//*/
    }

}