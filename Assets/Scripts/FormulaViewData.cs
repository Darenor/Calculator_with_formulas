using UnityEngine;

[CreateAssetMenu(
    fileName = "FormulaViewData",
    menuName = "Physics/Formula View Data"
    )]
public class FormulaViewData : ScriptableObject
{
    [TextArea(2, 5)]
    public string speedFormula;

    [TextArea(2, 5)]
    public string accelerationFormula;

    [TextArea(2, 5)]
    public string forceFormula;

    [TextArea(2, 5)]
    public string gravityForceFormula;

    [TextArea(2, 5)]
    public string potentialEnergyFormula;
}
