using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class WasmBridgeChicory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
         var manifest =
                Manifest.ofWasms(
                        ManifestWasm.fromUrl(
                                "https://github.com/extism/plugins/releases/download/v1.1.0/greet.wasm")
                        .build()).build();
        var plugin = Plugin.ofManifest(manifest).build();
        var input = "Benjamin";
        var result = new String(plugin.call("greet", input.getBytes(StandardCharsets.UTF_8)), StandardCharsets.UTF_8);
         */
        // becomes
        using (AndroidJavaObject urlString = new AndroidJavaObject("java.lang.String", "https://github.com/extism/plugins/releases/latest/download/count_vowels.wasm"))
        using (AndroidJavaClass ManifestWasmClass = new AndroidJavaClass("org.extism.chicory.sdk.ManifestWasm"))
        using (AndroidJavaObject ManifestWasmBuilder = ManifestWasmClass.CallStatic<AndroidJavaObject>("fromUrl", urlString))
        using (AndroidJavaObject ManifestWasmObj = ManifestWasmBuilder.Call<AndroidJavaObject>("build"))
        using (AndroidJavaClass ManifestClass = new AndroidJavaClass("org.extism.chicory.sdk.Manifest"))
        using (AndroidJavaObject ManifestBuilder = ManifestClass.CallStatic<AndroidJavaObject>("ofWasms", ManifestWasmObj))
        using (AndroidJavaObject ManifestObj = ManifestBuilder.Call<AndroidJavaObject>("build"))
        using (AndroidJavaClass PluginClass = new AndroidJavaClass("org.extism.chircory.sdk.Plugin"))
        using (AndroidJavaObject PluginBuilder = PluginClass.CallStatic<AndroidJavaObject>("ofManifest", ManifestObj))
        using (AndroidJavaObject PluginObj = PluginBuilder.Call<AndroidJavaObject>("build"))
        using (AndroidJavaClass StandardCharsets = new AndroidJavaClass("java.nio.charset.StandardCharsets"))
        using (AndroidJavaObject UTF_8 = StandardCharsets.GetStatic<AndroidJavaObject>("UTF_8"))
        {
            AndroidJavaObject input = new AndroidJavaObject("java.lang.String", "Hello World");
            AndroidJavaObject pluginFunc = new AndroidJavaObject("java.lang.String", "greet");
            AndroidJavaObject resultBytes = PluginObj.Call<AndroidJavaObject>("call", pluginFunc, input.Call<AndroidJavaObject>("getBytes", UTF_8));
            AndroidJavaObject resultString = new AndroidJavaObject("java.lang.String", resultBytes, UTF_8);
            string localResults = resultString.ToString();
            Debug.Log(localResults);
        }
        // feels like i might have to make a chicory wrapper in java to simplify
    }
}
