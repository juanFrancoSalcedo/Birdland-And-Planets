using B_Extensions;
using System;
using UnityEngine;

public class ToggleSails : BaseToggleAttendant
{
    public bool SailsOpen { get; private set; }

    void Start()
    {
        toggleComponent.onValueChanged.AddListener(OpenSails);
        OpenSails(toggleComponent.isOn);
    }

    private void OpenSails(bool arg0)
    {
        SailsOpen = arg0;
        toggleComponent.image.color = (arg0)?Color.floralWhite : Color.firebrick;

    }
}
