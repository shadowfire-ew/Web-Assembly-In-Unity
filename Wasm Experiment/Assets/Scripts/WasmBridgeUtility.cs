using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WasmBridgeUtility
{
    static byte[] cache = null;
    public static byte[] GetFileBytes()
    {
        // not super nescessary, as this is sandboxed
        if (cache == null)
        {
            TextAsset data = (TextAsset)Resources.Load("wello_wasm_bg");
            cache = data.bytes;
        }
        return cache;
    }
}
