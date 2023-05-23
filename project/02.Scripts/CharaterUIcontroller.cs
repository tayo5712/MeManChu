using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

namespace StarterAssets
{
    public class CharaterUIcontroller : MonoBehaviour
    {
        private StarterAssetsInputs _input;

        void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            MapMenu();
        }

        private void MapMenu()
        {
            if (_input.MapOpen)
            {
                Debug.Log(_input.MapOpen);
                _input.MapOpen = false;
            }
        }
    }
}