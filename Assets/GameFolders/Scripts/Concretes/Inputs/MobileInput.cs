using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Abstracts.Inputs;

namespace ProjectGame2.Inputs
{

    public class MobileInput : IPlayerInput
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public bool IsJumpButton { get; }
    }


}

