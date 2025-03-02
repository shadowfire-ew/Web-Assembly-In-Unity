using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;

// coppied from: https://github.com/kelnishi/WACS-Unity/blob/b2f1b0a8e1428a33f154394c67c664f4714af04f/Samples~/WasmRunner/Editor/AssetImporters/WasmImporter.cs


[ScriptedImporter(1, "wasm")]
public class WasmImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        // Load the binary data from the .kelvin file
        byte[] data = File.ReadAllBytes(ctx.assetPath);

        // Create an instance of KelvinAsset and assign the data
        WasmAsset wasmAsset = ScriptableObject.CreateInstance<WasmAsset>();
        wasmAsset.data = data;

        // Add the asset to the import context
        ctx.AddObjectToAsset("Wasm Asset", wasmAsset);
        ctx.SetMainObject(wasmAsset);
    }
}