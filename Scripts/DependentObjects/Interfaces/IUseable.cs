using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public interface IUseable
{
    void Use(ActionController user);

    float GetCooldown(ActionController user);
}
