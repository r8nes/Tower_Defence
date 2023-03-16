using System.Collections;
using UnityEngine;

namespace Defender.System
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

