using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeStaff : MonoBehaviour
{
    private GameObject staff;

    private MeshFilter staffMesh;

    private MeshRenderer staffRenderer;
    
    [SerializeField] private UsableItems usableItems;

    [SerializeField] private Mesh fireStaff;

    [SerializeField] private Mesh waterStaff;

    [SerializeField] private Mesh starterStaff;

    [SerializeField] private Material fireMaterial;

    [SerializeField] private Material startMaterial;

    [SerializeField] private Material waterMaterial;
    // Start is called before the first frame update
    void Awake()
    {
        staff = GameObject.Find("Druid_Staff");
        staffMesh = staff.GetComponent<MeshFilter>();
        staffRenderer = staff.GetComponent<MeshRenderer>();
        staffMesh.mesh = null;
        usableItems.waterStaffEquipped.AddListener(EquipWater);
        usableItems.startStaffEquipped.AddListener(EquipStarter);
        usableItems.fireStaffEquipped.AddListener(EquipFire);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        usableItems.fireStaffEquipped.RemoveListener(EquipFire);
        usableItems.waterStaffEquipped.RemoveListener(EquipWater);
        usableItems.startStaffEquipped.RemoveListener(EquipStarter);
    }

    private void EquipStarter()
    {
        staffMesh.mesh = starterStaff;
        staffRenderer.material = startMaterial;
    }

    private void EquipFire()
    {
        staffMesh.mesh = fireStaff;
        staffRenderer.material = fireMaterial;
    }

    private void EquipWater()
    {
        staffMesh.mesh = waterStaff;
        staffRenderer.material = waterMaterial;
    }
}
