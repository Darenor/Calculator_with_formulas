using UnityEngine;

public static class PhysicsCalculator
{
    private static FormulaConstants constants;

    public static void Initialize(FormulaConstants formulaConstants)
    {
        constants = formulaConstants;
    }

    public static float CalculateSpeed(float distance, float time)
    {
        return distance / time;
    }

    public static float CalculateAcceleration(
        float finalVelocity,
        float initialVelocity,
        float time)
    {
        return (finalVelocity - initialVelocity) / time;
    }

    public static float CalculateForce(float mass, float acceleration)
    {
        return mass * acceleration;
    }

    public static float CalculateGravityForce(float mass)
    {
        return mass * constants.gravitationalAcceleration;
    }

    public static float CalculatePotentialEnergy(
        float mass,
        float height)
    {
        return mass *
            constants.gravitationalAcceleration *
            height;
    }
}
