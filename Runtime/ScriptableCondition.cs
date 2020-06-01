﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace devludico.ScriptableStates
{
    public abstract class ScriptableCondition : ScriptableObject
    {
        public abstract bool Verify(ScriptableStatesComponent smComponent);
    }
}