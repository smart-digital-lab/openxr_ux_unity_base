/**********************************************************************************************************************************************************
 * BoolIMUX
 * --------
 *
 * 2021-09-03
 *
 * A connector that takes 2 inputs that depict a true action and a false action, and send these through as a single boolean.
 * The quietly parameters tells the recieving module whether to send out events when this happens or not.
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface _BoolIMUX
{
    void InputOn();
    void InputOff();
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("XR/UX/Connectors/BoolIMUX")]
public class BoolIMUX : MonoBehaviour, _BoolIMUX
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public UnityXRDataEvent onChange;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Input values of on or off
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void InputOn ()
    {
        if (onChange != null) onChange.Invoke(new XRData(true));
    }
    public void InputOff ()
    {
        if (onChange != null) onChange.Invoke(new XRData(false));
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}