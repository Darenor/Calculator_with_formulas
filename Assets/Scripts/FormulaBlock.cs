using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormulaBlock : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text formulaText;
    [SerializeField] private TMP_InputField[] inputFields;
    [SerializeField] private Button calculateButton;
    [SerializeField] private TMP_Text resultText;

    [Header("Formula")]
    [SerializeField] private FormulaType formulaType;

    private void Start()
    {
        calculateButton.onClick.AddListener(Calculate);

        foreach (TMP_InputField input in inputFields)
        {
            input.onValueChanged.AddListener(OnInputChanged);
        }

        OnInputChanged("");
    }

    private void OnInputChanged(string value)
    {
        bool allFilled = true;

        foreach (TMP_InputField input in inputFields)
        {
            if (string.IsNullOrWhiteSpace(input.text))
            {
                allFilled = false;
                break;
            }
        }

        calculateButton.interactable = allFilled;
    }

    private bool TryGetValue(
        TMP_InputField field,
        out float value)
    {
        return float.TryParse(
            field.text,
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out value
        );
    }

    private void Calculate()
    {
        float result = 0f;

        switch (formulaType)
        {
            case FormulaType.Speed:
            {
                TryGetValue(inputFields[0], out float distance);
                TryGetValue(inputFields[1], out float time);

                if (time == 0)
                {
                    resultText.text = "Ошибка: время не может быть 0";
                    return;
                }

                result = PhysicsCalculator.CalculateSpeed(
                    distance,
                    time
                );

                break;
            }

            case FormulaType.Acceleration:
            {
                TryGetValue(inputFields[0], out float finalVelocity);
                TryGetValue(inputFields[1], out float initialVelocity);
                TryGetValue(inputFields[2], out float time);

                if (time == 0)
                {
                    resultText.text = "Ошибка: время не может быть 0";
                    return;
                }

                result = PhysicsCalculator.CalculateAcceleration(
                    finalVelocity,
                    initialVelocity,
                    time
                );

                break;
            }

            case FormulaType.Force:
            {
                TryGetValue(inputFields[0], out float mass);
                TryGetValue(inputFields[1], out float acceleration);

                result = PhysicsCalculator.CalculateForce(
                    mass,
                    acceleration
                );

                break;
            }

            case FormulaType.GravityForce:
            {
                TryGetValue(inputFields[0], out float mass);

                result = PhysicsCalculator.CalculateGravityForce(
                    mass
                );

                break;
            }

            case FormulaType.PotentialEnergy:
            {
                TryGetValue(inputFields[0], out float mass);
                TryGetValue(inputFields[1], out float height);

                result = PhysicsCalculator.CalculatePotentialEnergy(
                    mass,
                    height
                );

                break;
            }
        }

        resultText.text = result.ToString("0.###");
    }

    public void SetFormulaText(string text)
    {
        formulaText.text = text;
    }
}

public enum FormulaType
{
    Speed,
    Acceleration,
    Force,
    GravityForce,
    PotentialEnergy
}