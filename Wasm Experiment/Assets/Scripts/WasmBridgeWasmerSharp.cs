using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using WasmerSharp;

public class WasmBridgeWasmerSharp : MonoBehaviour
{
    Memory mem;
    Import memImport;
    Instance inst;
    // Start is called before the first frame update
    void Start()
    {
        // this code is bare bones, as I have chosen Wasmtime and Extism over wasmer
        // but i am still including it here as an example for anyone else who might want to use wasmer over the other two
        byte[] bytes = WasmBridgeUtility.GetFileBytes();
        if (null == bytes )
        {
            Debug.Log("Could not proceed, review log.");
            return;
        }
        mem = Memory.Create(minPages: 256, maxPages: 256);
        memImport = new("env", "memory", mem);
        inst = new(bytes, memImport);
        object[] inputs = new object[1];
        inputs[0] = 0;
        var ret = inst.Call("get_something", inputs);
        if (null == ret)
        {
            Debug.Log("Error calling the method get_something, status:" + inst.LastError);
        }
        else
        {
            Debug.Log("The method returned: " + ret[0] + " is the first element of " + ret.Length);
        }
        object[] inputs2 = { 1, 2 };
        ret = inst.Call("add_ints", inputs2);
        if (null == ret)
        {
            Debug.Log("Error calling the method get_something, status:" + inst.LastError);
        }
        else
        {
            Debug.Log("The method returned: " + ret[0] + " is the first element of " + ret.Length);
        }
    }
}
