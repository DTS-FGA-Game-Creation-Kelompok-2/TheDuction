using System.Collections;
using System.Collections.Generic;
using TheDuction.Animations;
using UnityEngine;

public class TalkAnim : BaseAnimation
{
    public override void PlayAnim(Animator anim)
    {
        anim.ResetTrigger("Idle");
        anim.ResetTrigger("Move");
        anim.SetTrigger("Talk");
    }
}
