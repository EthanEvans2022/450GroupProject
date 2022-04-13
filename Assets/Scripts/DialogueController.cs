using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    public class DialogueController : MonoBehaviour
    {
        // Outlets
        public static DialogueController instance;
        public GameObject dialogueMenu;
        //public GameObject[] textParts;
        public TMP_Text dialogueText;
        
        // Configurations
        public int currentDialogue;
        // Configurations
/*
        private string[] textParts =
        {
	        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
	        "Semper viverra nam libero justo. Arcu odio ut sem nulla pharetra diam sit amet.",
	        "Varius morbi enim nunc faucibus a pellentesque sit amet. Id donec ultrices tincidunt arcu. Imperdiet sed euismod nisi porta lorem mollis."
        };
*/
		public string[] textParts =
        {
	        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
	        "Semper viverra nam libero justo. Arcu odio ut sem nulla pharetra diam sit amet.",
	        "Varius morbi enim nunc faucibus a pellentesque sit amet. Id donec ultrices tincidunt arcu. Imperdiet sed euismod nisi porta lorem mollis."
        };
    
    
        // Methods
        void Awake()
        {
            instance = this;
            HideDialogueController();
            currentDialogue = 0;
            
        }

        public void ShowDialogueController()
        {
            this.gameObject.SetActive(true);
        }

        public void HideDialogueController()
        {
            this.gameObject.SetActive(false);
        }

        public void NextText()
        {
			ShowDialogueController();
			
			if (currentDialogue < textParts.Length)
			{
				dialogueText.text = textParts[currentDialogue];
				currentDialogue = currentDialogue + 1;
			}
			else
			{
				/*
				dialogueBox.enabled = false;
				dialogueText.enabled = false;
				*/
				HideDialogueController();
			}

        }	
        
		
        
        
    }


