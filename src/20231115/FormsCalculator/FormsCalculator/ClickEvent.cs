using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsCalculator
{
    internal class ClickEvent
    {

        private double _firstNumber;
        private double _secondNumber;
        private double _result;
        private string _lblResult;
        private string _lblCalc;
        private string _operation;

        public ClickEvent(ClickEventData eventData)
        {
            _firstNumber = eventData.firstNumber;
            _secondNumber = eventData.secondNumber;
            _result = eventData.result;
            _lblResult = eventData.lblResult;
            _lblCalc = eventData.lblCalc;
            _operation = eventData.operation;

        }

        public ClickEventData ClickEventData { get ; set; }

        public void Run()
        {

        }

    }
}
