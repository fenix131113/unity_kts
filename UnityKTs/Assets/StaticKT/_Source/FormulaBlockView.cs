using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StaticKT
{
    public class FormulaBlockView : MonoBehaviour
    {
        [SerializeField] private RectTransform fieldsParent;
        [SerializeField] private GameObject inputBlockPrefab;
        [SerializeField] private TMP_Text formulaLabel;
        [SerializeField] private TMP_Text resultLabel;
        [SerializeField] private Button calculateButton;

        private List<TMP_InputField> _valuesFields = new();
        private FormulaViewDataSO _formulaData;

        public void Init(FormulaViewDataSO formulaViewDataSO)
        {
            calculateButton.onClick.AddListener(Calculate);
            _formulaData = formulaViewDataSO;
            formulaLabel.text = _formulaData.Formula;
            Spawn();
        }

        private void Update()
        {
            calculateButton.interactable = _valuesFields.All(item => !string.IsNullOrEmpty(item.text));
        }

        private void Spawn()
        {
            foreach (var t in _formulaData.Values)
            {
                var spawned = Instantiate(inputBlockPrefab, fieldsParent);
                spawned.transform.GetChild(0).GetComponent<TMP_Text>().text = t;
                _valuesFields.Add(spawned.transform.GetChild(1).GetComponent<TMP_InputField>());
            }
        }

        private void Calculate()
        {
            var result = _formulaData.FormulaType switch
            {
                FormulaType.FALL_HEIGHT => Calculator.CalculateFallHeight(double.Parse(_valuesFields[0].text)),
                
                FormulaType.VERTICAL_HEIGHT => Calculator.CalculateVerticalHeight(double.Parse(_valuesFields[0].text),
                    double.Parse(_valuesFields[1].text)),
                
                FormulaType.UNIVERSAL_GRAVITATION => Calculator.CalculateUniversalGravitation(
                    double.Parse(_valuesFields[0].text), double.Parse(_valuesFields[1].text),
                    double.Parse(_valuesFields[2].text)),
                
                FormulaType.HEIGHT_ON_MOVE_UP => Calculator.CalculateHeightOnMoveUp(double.Parse(_valuesFields[0].text),
                    double.Parse(_valuesFields[1].text)),
                
                FormulaType.HEIGHT_ON_MOVE_DOWN => Calculator.CalculateHeightOnMoveDown(double.Parse(_valuesFields[0].text),
                    double.Parse(_valuesFields[1].text)),
                
                _ => throw new ArgumentOutOfRangeException()
            };

            resultLabel.text = result.ToString(CultureInfo.InvariantCulture);
        }
    }
}