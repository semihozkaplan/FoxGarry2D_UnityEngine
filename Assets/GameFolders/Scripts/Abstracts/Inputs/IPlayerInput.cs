using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Abstracts.Inputs
{

    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsJumpButton { get; }
    }


}

