using UnityEngine;

[CreateAssetMenu(
    fileName = "PhysicsConstants",
    menuName = "Physics/Constants"
)]

public class FormulaConstants : ScriptableObject
{
    [Header("Gravitational acceleration")]
    public float gravitationalAcceleration = 9.81f;
}