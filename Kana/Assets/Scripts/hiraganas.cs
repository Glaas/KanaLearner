using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using NaughtyAttributes;


[UnityEngine.CreateAssetMenu(fileName = "Kana", menuName = "Kana", order = 0)]
public class hiraganas : UnityEngine.ScriptableObject
{
    [ShowAssetPreview]
    public Sprite symbol;
    public string answerExpected;
    public AudioSource pronunciation;

    /*[Button()]
    public void RenameAsset()
    {
        string assetPath =  AssetDatabase.GetAssetPath(this.GetInstanceID());
        AssetDatabase.RenameAsset(assetPath, symbol.name);
        answerExpected = symbol.name;
        AssetDatabase.SaveAssets();    }*/
}