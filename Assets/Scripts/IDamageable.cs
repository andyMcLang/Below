﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(int damage, Vector3 hitPoint, Vector3 hitNormal);
}
