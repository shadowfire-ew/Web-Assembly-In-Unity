using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wasmtime;
using System.IO;
using System;

public class WasmBridgeWasmtime : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        byte[] bytes = WasmBridgeUtility.GetFileBytes();
        if (null== bytes )
        {
            Debug.Log("Could not proceed, review log.");
            return;
        }
        // These debug logs are to figure out when the code fails on device. I do not want to go through the hassle of connecting a debugger to my phone
        Debug.Log("A");
        using var engine = new Engine();
        Debug.Log("B");
        ReadOnlySpan<byte> buffer = new ReadOnlySpan<byte>(bytes, 0, bytes.Length);
        Debug.Log("C");
        using var module = Module.FromBytes(engine, "wello_wasm", buffer);
        Debug.Log("D");
        // used to link functions from c# into the instance
        using var linker = new Linker(engine);
        Debug.Log("E");
        using var store = new Store(engine);
        Debug.Log("F");
        var instance = linker.Instantiate(store, module);
        Debug.Log("G");
        var get_something = instance.GetFunction("get_something");
        Debug.Log("H");
        if (null == get_something)
        {
            Debug.Log("instance.GetFunction(\"get_something\") was incorrect");
        }
        else
        {
            // for some reason need to pass an integer for the no parameter function
            Debug.Log("I");
            var result = get_something.Invoke(0);
            if (null == result)
            {
                Debug.Log("function did not return any value");
            }
            else
            {
                Debug.Log("Result from function: "+result.ToString());
            }
        }
    }
}
