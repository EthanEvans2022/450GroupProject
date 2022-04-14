using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public static CharacterController instance;

    //Configurations
    public CombinedController combined;
    public KeyboardController keyboard;
    public MouseController mouse;

    //Outlets
    public GameObject keyboardInstance;
    public GameObject mouseInstance;
    public GameObject combinedInstance;

    //States
    public bool isCombined = true;
    public bool isPaused;

    //Outlets

    //Methods
    private void Awake()
    {
        instance = this;
        print("SET INSTANCE");
        combinedInstance = combined.gameObject;
        keyboardInstance = keyboard.gameObject;
        mouseInstance = mouse.gameObject;
    }

    private void Start()
    {
        instance = this;
        print("SET INSTANCE");
        combinedInstance = combined.gameObject;
        keyboardInstance = keyboard.gameObject;
        mouseInstance = mouse.gameObject;

        CombineCharacters();
        SpawnCharacter(
            combinedInstance,
            transform.position,
            Quaternion.identity
        ); //This sets us up at the right location
        if (!isCombined) SplitCharacters();

        GetComponent<HealthController>().AfterDamageEvent += (d, t, v, h) =>
        {
            if (h.currentHealth <= 0)
                SceneManager.LoadScene(0);
        };
    }

    private void Update()
    {
        if (isPaused) return;


        if (Input.GetKeyDown(KeyCode.C)) ToggleCharacterCombined();
        HandleMenuControls();
    }

    private void HandleMenuControls()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //MenuControllerVersion2.instance.ShowDialogue();
            DialogueController.instance.NextText();

        // Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape)) MenuControllerVersion2.instance.Show();
    }

    //Toggle Combined or Split
    public void ToggleCharacterCombined()
    {
        if (isCombined)
            SplitCharacters();
        else
            CombineCharacters();
        isCombined = !isCombined;
    }

    //Handles the splitting of characters
    private void SpawnCharacter(GameObject obj, Vector3 position, Quaternion rotation)
    {
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
    }

    private void SplitCharacters()
    {
        //Activate all components
        var position = combinedInstance.transform.position;
        SpawnCharacter(keyboard.gameObject, position, Quaternion.identity);
        SpawnCharacter(mouse.gameObject, position, Quaternion.identity);

        //Destroy split characters
        combinedInstance.SetActive(false);
    }

    private void CombineCharacters()
    {
        //Activate all components
        SpawnCharacter(combined.gameObject, keyboardInstance.transform.position, Quaternion.identity);

        //Destroy split characters
        keyboardInstance.SetActive(false);
        mouseInstance.SetActive(false);
    }
}