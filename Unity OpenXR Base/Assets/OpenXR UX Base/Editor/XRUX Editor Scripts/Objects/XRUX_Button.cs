/**********************************************************************************************************************************************************
 * XRUX_Button
 * -----------
 *
 * 2021-11-15
 *
 * Editor Layer Settings for XRUX_Button
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/
 
using UnityEngine;
using System.Collections;
using UnityEditor;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// XRUX_Button
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[CustomEditor(typeof(XRUX_Button))]
public class XRUX_Button_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        XRUX_Button myTarget = (XRUX_Button)target;

        XRUX_Editor_Settings.DrawMainHeading("A Movable Button", "A button is a raised object that has something written or drawn on its surface, that can be interacted with using the XR controllers or mouse, and controlled by other XRUX Modules.  It can move, change color and create events when touched and activated.");

        XRUX_Editor_Settings.DrawInputsHeading();
        EditorGUILayout.LabelField("Title", "string | int | float | bool | Vector3 | XRData", XRUX_Editor_Settings.fieldStyle);
        EditorGUILayout.LabelField("Input", "XRData", XRUX_Editor_Settings.fieldStyle);
        EditorGUILayout.LabelField("Boolean XRData value to change the button state as if it was being pressed.", XRUX_Editor_Settings.helpTextStyle);

        XRUX_Editor_Settings.DrawParametersHeading();
        EditorGUILayout.LabelField("The object that will change colour when pressed.", XRUX_Editor_Settings.categoryStyle);
        myTarget.objectToColor = (Renderer) EditorGUILayout.ObjectField("Object to color", myTarget.objectToColor, typeof(Renderer), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("The object that will move when pressed.", XRUX_Editor_Settings.categoryStyle);
        myTarget.objectToMove = (GameObject) EditorGUILayout.ObjectField("Object to move", myTarget.objectToMove, typeof(GameObject), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Materials for the interaction stages.", XRUX_Editor_Settings.categoryStyle);
        myTarget.normalMaterial = (Material) EditorGUILayout.ObjectField("Normal Material", myTarget.normalMaterial, typeof(Material), true);
        myTarget.activatedMaterial = (Material) EditorGUILayout.ObjectField("Activated Material", myTarget.activatedMaterial, typeof(Material), true);
        myTarget.touchedMaterial = (Material) EditorGUILayout.ObjectField("Touched Material", myTarget.touchedMaterial, typeof(Material), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Movement axis (or none), and distance", XRUX_Editor_Settings.categoryStyle);
        Debug.Log(myTarget.movementAxis);
        myTarget.movementAxis = (XRUX_Button.XRGenericButtonAxis) EditorGUILayout.EnumPopup("Movement Axis", myTarget.movementAxis);
        myTarget.movementAmount = EditorGUILayout.FloatField("Movement Amount", myTarget.movementAmount);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Toggle or Momentary Movement Style", XRUX_Editor_Settings.categoryStyle);
        myTarget.movementStyle = (XRUX_Button.XRGenericButtonMovement) EditorGUILayout.EnumPopup("Movement Style", myTarget.movementStyle);
        EditorGUILayout.LabelField("Toggle buttons turn on or off once for each press, whereas Momentary buttons click on and off with just one press.", XRUX_Editor_Settings.helpTextStyle);
        EditorGUILayout.Space();
        XRUX_Editor_Settings.DrawOutputsHeading();
        var prop = serializedObject.FindProperty("onChange"); EditorGUILayout.PropertyField(prop, true);    
        var prop2 = serializedObject.FindProperty("onClick"); EditorGUILayout.PropertyField(prop2, true);    
        var prop3 = serializedObject.FindProperty("onUnclick"); EditorGUILayout.PropertyField(prop3, true);    
        var prop4 = serializedObject.FindProperty("onTouch"); EditorGUILayout.PropertyField(prop4, true);   
        var prop5 = serializedObject.FindProperty("onUntouch"); EditorGUILayout.PropertyField(prop5, true);   
        EditorGUILayout.Space();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
    }
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
