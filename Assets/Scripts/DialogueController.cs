using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
Dialog (6 levels)
Level 1:
Intro: “I found myself in a dark room, my torch the only source of light. Strange runes on the wall suggest a malevolent will behind this trap.”
After the first door: “My soul wrenched in two, I realized that whoever was behind this did not anticipate my instability. I knew I needed to escape.”

Level 2:
Intro: “I followed the stairs I found upward and discovered another room. More strange writing was etched into the ice under my feet.”

Level 3:
Intro: “I didn’t expect such resistance. But these robed figures can only mean one person.” “The Lord of the Engine of this World... Bringer of Prefabs... The Holy Quest-giver... The Final Evaluator...” “ROBERT SANTOS”

Level 4:
Intro: “I didn’t expect his machinations to be so Unityfied against me. The strange runes are beginning to make an elaborate pattern in my head. Loops within loops, strange words, I didn’t know what to make of it.”

Level 5:
Intro: "I began to read the patterns and understand them. My vision sharpens. I can see more. Input. Action. Obstacle. Goal. A loop at the center of everything. At the core."

Level 6:
Intro: “It all came down to this. The runes give him powers. And I realized my place in things. I am the agent of an infinitely complex being, controlling me. A being who could one day rival Santos. But not yet. For today, I am the flaw in the system, that being’s misshapen child, The Red Error...”
*/
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


