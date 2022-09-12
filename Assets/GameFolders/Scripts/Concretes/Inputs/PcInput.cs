using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Abstracts.Inputs;

namespace ProjectGame2.Inputs
{

    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpButton => Input.GetButtonDown("Jump");

    }


}

