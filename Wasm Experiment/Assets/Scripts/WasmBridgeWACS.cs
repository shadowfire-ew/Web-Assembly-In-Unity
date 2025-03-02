using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Wacs.Core;
using Wacs.Core.Runtime;
using Wacs.Core.Runtime.Types;
using Wacs.Core.WASIp1;

public class WasmBridgeWACS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        byte[] bytes = WasmBridgeUtility.GetFileBytes();
        if (null == bytes)
        {
            Debug.Log("Could not proceed, review log.");
            return;
        }
        WasmRuntime runtime = new();
        Debug.Log("runtime instantiated");
        var stream = new MemoryStream(bytes);
        var module = BinaryModuleParser.ParseWasm(stream);
        Debug.Log("module parsed");
        var modInst = runtime.InstantiateModule(module, new RuntimeOptions { SkipModuleValidation = true});
        Debug.Log("module instantiated");
        runtime.RegisterModule("wello", modInst);
        Debug.Log("module registered");
        if (runtime.TryGetExportedFunction(("wello","get_something"),out var mainAddr))
        {
            Debug.Log("get_something function found");
            var mainInvoker = runtime.CreateInvokerFunc<Value>(mainAddr);
            Debug.Log("invoker created for get_something");
            var resultTemp = mainInvoker();
            Debug.Log("invoker called");
            string result = resultTemp.ToString();
            Debug.Log("Result from invoking: " + result);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
