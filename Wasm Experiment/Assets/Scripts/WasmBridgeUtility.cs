using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WasmBridgeUtility
{
    static WasmAsset cache = null;
    public static byte[] GetFileBytes()
    {
        // not super nescessary, as this is sandboxed
        if (cache == null)
        {
            cache = Resources.Load<WasmAsset>("wello_wasm");
        }
        return cache.data;
    }
}
