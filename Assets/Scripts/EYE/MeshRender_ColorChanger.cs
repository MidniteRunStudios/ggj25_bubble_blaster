using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRender_ColorChanger : MonoBehaviour
{
    //this  script will allow you to drop in any material we regularly use(colors(solid, metallic, emissive, transparent))    
    //this setup places a priority on emissive -> metallic -> solid -> transparent -> any
    //the selections are random OR set by int ID

    MeshRenderer _renderer;
    public enum ColorTypes { All, Emissive, Metallic, Solid, Transparent };
    public ColorTypes colorType;

    [SerializeField] List<Material> _emissiveOptions;
    [SerializeField] List<Material> _metallicOptions;
    [SerializeField] List<Material> _solidOptions;
    [SerializeField] List<Material> _transparentOptions;

    [SerializeField] List<Material> _colorOptions;

    [SerializeField] int optionID;


    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();

        if( _renderer == null)
            _renderer = GetComponentInChildren<MeshRenderer>();

        SelectRandomColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            //SelectRandomColor();
            SelectColorViaID(optionID);
    }

    public void SelectRandomColor()
    {
        switch (colorType)
        {
            case ColorTypes.Emissive:
                optionID = Random.Range(0, _emissiveOptions.Count);
                _renderer.material = _emissiveOptions[optionID];

                break;

            case ColorTypes.Metallic:
                optionID = Random.Range(0, _metallicOptions.Count);
                _renderer.material = _metallicOptions[optionID];

                break;
                
            case ColorTypes.Solid:
                optionID = Random.Range(0, _solidOptions.Count);
                _renderer.material = _solidOptions[optionID];
                break;
                            
            case ColorTypes.Transparent:
                optionID = Random.Range(0, _transparentOptions.Count);
                _renderer.material = _transparentOptions[optionID];

                break;
                
            default:
                optionID = Random.Range(0, _colorOptions.Count);
                _renderer.material = _colorOptions[optionID];

                break;
        }
    }

    public void SelectColorViaID(int inID)
    {
        optionID = inID;
        
        switch (colorType)
        {
            case ColorTypes.Emissive:
                _renderer.material = _emissiveOptions[optionID];
                break;

            case ColorTypes.Metallic:
                _renderer.material = _metallicOptions[optionID];
                break;

            case ColorTypes.Solid:
                _renderer.material = _solidOptions[optionID];
                break;

            case ColorTypes.Transparent:
                _renderer.material = _transparentOptions[optionID];
                break;

            default:                
                _renderer.material = _colorOptions[optionID];
                break;
        }        
    }
}
