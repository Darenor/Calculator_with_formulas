using UnityEngine;

public class PhysicsApp : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private FormulaConstants constants;
    [SerializeField] private FormulaViewData viewData;

    [Header("Formula Blocks")]
    [SerializeField] private FormulaBlock speedBlock;
    [SerializeField] private FormulaBlock accelerationBlock;
    [SerializeField] private FormulaBlock forceBlock;
    [SerializeField] private FormulaBlock gravityForceBlock;
    [SerializeField] private FormulaBlock potentialEnergyBlock;

    private void Awake()
    {
        PhysicsCalculator.Initialize(constants);

        speedBlock.SetFormulaText(
            viewData.speedFormula
            );

        accelerationBlock.SetFormulaText(
            viewData.accelerationFormula
            );

        forceBlock.SetFormulaText(
            viewData.forceFormula
            );

        gravityForceBlock.SetFormulaText(
            viewData.gravityForceFormula
            );

        potentialEnergyBlock.SetFormulaText(
            viewData.potentialEnergyFormula
            );
    }
}
