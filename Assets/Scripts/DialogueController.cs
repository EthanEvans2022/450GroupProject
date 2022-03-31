using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class DialogueController : MonoBehaviour
    {
        // Outlets
        public static DialogueController dialogueControllerInstance;
        public GameObject dialogueMenu;
        public GameObject[] textParts;
        private int currentDialogueBox;
    
    
        // Methods
        void Awake()
        {
            dialogueControllerInstance = this;
            HideDialogueController();
            currentDialogueBox = 0;
            
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
            for (int i = 0; i < textParts.Length; i++)
			{	
				textParts[i].SetActive(false);
			}
			

			if (currentDialogueBox < textParts.Length)
			{
				textParts[currentDialogueBox].SetActive(true);	
				currentDialogueBox = currentDialogueBox + 1;
			}
			else
			{
				HideDialogueController();
				currentDialogueBox = 0;
			}

        }	
        
        
        
    }


