using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetInputFieldFocus : MonoBehaviour {

    public InputField nextInputField;

    private InputField inputField;

    private void Awake() {

        inputField = this.gameObject.GetComponent<InputField>();
    }

    private void Start() {

        inputField.Select();
        inputField.ActivateInputField();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            nextInputField.Select();
            nextInputField.ActivateInputField();    
        }
    }
}
