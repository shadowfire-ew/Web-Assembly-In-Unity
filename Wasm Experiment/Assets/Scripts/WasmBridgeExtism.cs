using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extism.Sdk;

public class WasmBridgeExtism : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // just the simple example from Extism's docs
        var manifest = new Manifest(new UrlWasmSource("https://github.com/extism/plugins/releases/latest/download/count_vowels.wasm"));
        using var plugin = new Plugin(manifest, new HostFunction[] { }, withWasi: true);
        var output = plugin.Call("count_vowels", "Hello world");
        Debug.Log(output);
    }
}
