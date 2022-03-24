using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Configurations
    private GameObject _keyboardInstance;
    private GameObject _mouseInstance;
    private GameObject _combinedInstance;
    public CombinedController combined;
    public KeyboardController keyboard;
    public MouseController mouse;
    
    private HealthController _keyboardHealth;
    private HealthController _mouseHealth;
    private HealthController _combinedHealth;
    
    public float speed = 10;

    //States
    public bool isCombined = true;

    //Outlets

    //Methods
    private void Start()
    {
        _combinedInstance = combined.gameObject;
        _keyboardInstance = keyboard.gameObject;
        _mouseInstance = mouse.gameObject;
        
        CombineCharacters();
        SpawnCharacter(_combinedInstance, transform.position, Quaternion.identity); //This sets us up at the right location
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
        var position = _combinedInstance.transform.position;
        SpawnCharacter(keyboard.gameObject, position, Quaternion.identity);
        SpawnCharacter(mouse.gameObject, position, Quaternion.identity);
        
        //Destroy split characters
        _combinedInstance.SetActive(false);
    }

    private void CombineCharacters()
    {
        //Activate all components
        SpawnCharacter(combined.gameObject, _keyboardInstance.transform.position, Quaternion.identity);
        
        //Destroy split characters
        _keyboardInstance.SetActive(false);
        _mouseInstance.SetActive(false);
    }
}
    