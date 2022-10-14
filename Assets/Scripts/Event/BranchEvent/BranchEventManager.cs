using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Event.BranchEvent{
    public class BranchEventManager: SingletonBaseClass<BranchEventManager>{
        public BranchEventRunner GetBranchEventRunner(string id){
            BranchEventRunner[] branchEventRunners = FindObjectsOfType<BranchEventRunner>();

            foreach(BranchEventRunner branchEventRunner in branchEventRunners){
                if(branchEventRunner.BranchEventData.ID == id){
                    return branchEventRunner;
                }
            }

            Debug.LogError($"Branch event runner with ID: {id} not found");
            return null;
        }
    }
}