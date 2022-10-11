using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Animations
{
    public class MoveAnim : BaseAnimation
    {
        public override void PlayAnim(Animator anim)
        {
            anim.ResetTrigger("Idle");
            anim.ResetTrigger("Talk");
            anim.SetTrigger("Move");
        }
    }
}

