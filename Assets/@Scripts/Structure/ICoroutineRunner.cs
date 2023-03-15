using System.Collections;
using UnityEngine;

namespace Defender.Structure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

