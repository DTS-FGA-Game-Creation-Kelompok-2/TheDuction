using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Event.BranchEvent{
    [Serializable]
    public class BranchEventData{
        [SerializeField] private string _name;
        [SerializeField] private List<BranchPart> _branchParts;

        public List<BranchPart> BranchParts => _branchParts;
    }
}