using System.Collections;
using System.Collections.Generic;
using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Interaction{
    public class InteractableManager: SingletonBaseClass<InteractableManager>{
        [SerializeField] private Text _interactableNameText;
        [SerializeField] private GameObject _interactionInstruction;
        [SerializeField] private GameObject _interactionName;
        [SerializeField] private List<Interactable> _interactables;

        /// <summary>
        /// Get Interactable by its data 
        /// </summary>
        /// <param name="data">Interactable Data</param>
        /// <returns>Returns interactable object if found or null if not found</returns>
        public Interactable GetInteractable(InteractableData data){
            foreach(Interactable interactable in _interactables){
                if(interactable.Data == data){
                    return interactable;
                }
            }

            Debug.LogError($"Interactable with ID: {data.InteractableID} not found");
            return null;
        }

        public void HandleInteractionName(string interactableName){
            _interactableNameText.text = interactableName;
            StopAllCoroutines();
            StartCoroutine(PlayInteractionView());
        }
 
        private IEnumerator PlayInteractionView() {
            _interactionName.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            _interactionName.SetActive(false);
        }

        public void InstructionFadeIn(){
            _interactionInstruction.SetActive(true);
        }

        public void InstructionFadeOut(){
            _interactionInstruction.SetActive(false);
            _interactionName.SetActive(false);
        }
    }
}