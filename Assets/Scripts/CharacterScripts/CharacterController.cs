using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    //Configurations
    public CombinedController combined;
    public KeyboardController keyboard;
    public MouseController mouse;
    
    //Outlets
    public GameObject keyboardInstance;
    public GameObject mouseInstance;
    public GameObject combinedInstance;
    private HealthController _keyboardHealth;
    private HealthController _mouseHealth;
    private HealthController _combinedHealth;

    private HealthController _myHealthController;
    //States
    public bool isCombined = true;

    //Outlets

    //Methods
    private void Start()
    {
        combinedInstance = combined.gameObject;
        keyboardInstance = keyboard.gameObject;
        mouseInstance = mouse.gameObject;

        _myHealthController = GetComponent<HealthController>();
        
        CombineCharacters();
        SpawnCharacter(combinedInstance, transform.position, Quaternion.identity); //This sets us up at the right location
        if(!isCombined) SplitCharacters();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) ToggleCharacterCombined();
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
    