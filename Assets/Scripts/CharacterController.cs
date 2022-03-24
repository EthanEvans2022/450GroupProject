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
       _combinedInstance = SpawnCharacter(combined.gameObject, transform.position, Quaternion.identity);
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
    private GameObject SpawnCharacter(GameObject obj, Vector3 position, Quaternion rotation)
    {
        var c = Instantiate(obj, position, rotation);
        
        return c; 
    }
    
    private void SplitCharacters()
    {
        //Activate all components
        var position = _combinedInstance.transform.position;
        _keyboardInstance = SpawnCharacter(keyboard.gameObject, position, Quaternion.identity);
        _mouseInstance = SpawnCharacter(mouse.gameObject, position, Quaternion.identity);
        
        //Destroy split characters
        Destroy(_combinedInstance);
    }

    private void CombineCharacters()
    {
        //Activate all components
        _combinedInstance = Instantiate(combined.gameObject, _keyboardInstance.transform.position, Quaternion.identity);
        
        //Destroy split characters
        Destroy(_keyboardInstance);
        Destroy(_mouseInstance);
    }
}
    