using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Interaction{
    public class InteractableManager: SingletonBaseClass<InteractableManager>{
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
    }
}