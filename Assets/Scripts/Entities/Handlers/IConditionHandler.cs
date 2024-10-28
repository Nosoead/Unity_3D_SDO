using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConditionHandler
{
    void SetInitialValue(float initialValue);

    void ApplyPassiveEffect(float passiveValue);
}
