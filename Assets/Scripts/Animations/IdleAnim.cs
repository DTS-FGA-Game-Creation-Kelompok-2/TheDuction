using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Animations
{
    public class IdleAnim : BaseAnimation
    {
        public override void PlayAnim(Animator anim)
        {
            anim.ResetTrigger("Move");
            anim.ResetTrigger("Talk");
            anim.SetTrigger("Idle");
        }
    }
}

