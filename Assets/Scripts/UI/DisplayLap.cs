using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class DisplayLap : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _lapText;

        private int _actualLap = 1;
        // Start is called before the first frame update
        void Start()
        {
            _lapText.text = $"Lap : {_actualLap.ToString()}";
        }

        public void UpdateLap()
        {
            _actualLap++;
            _lapText.text = $"Lap : {_actualLap.ToString()}";
        }
    }
}
