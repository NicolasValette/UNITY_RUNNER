using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class DisplayGates : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _gateNumberTxt;

        private int _gateNumber;
        // Start is called before the first frame update
        void Start()
        {
            _gateNumber = 0;
            _gateNumberTxt.text = _gateNumber.ToString();
        }

        public void CrossGate()
        {
            _gateNumber ++;
            _gateNumberTxt.text = _gateNumber.ToString();
        }
    }
}
