using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Event.BranchEvent{
    [Serializable]
    public class BranchEventData{
        [SerializeField] private string _id;
        [SerializeField] private List<BranchPart> _branchParts;

        public string ID => _id;
        public List<BranchPart> BranchParts => _branchParts;
    }
}