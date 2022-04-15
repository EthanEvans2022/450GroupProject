
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerController : MonoBehaviour
{

	//Config
	public string[] storedText;
    // Start is called before the first frame update
    void Start()
    {
        print("DialogueTriggerController started\n");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
			print("Triggering Dialog");
		DialogueController.instance.textParts = storedText;
		DialogueController.instance.currentDialogue = 0;
        DialogueController.instance.NextText();
        Destroy(gameObject);
    }
}
