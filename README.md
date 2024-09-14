# Web-Assembly-In-Unity
 An exploration of embedding a web assembly runtime in Unity to enable running wasm.

# Wasm Experiment 
 This is the Unity project acting as a sandbox.
 The project is configured to build to android for internal testing purposes. The examples should work on windows and linux, provided they have the right runtimes.
 I will review the code base and get all the missing but available runtimes in there ASAP.

 The wasm experiment unity projecty includes the following plugins:
 - [Unity Ingame Debug Console](https://github.com/yasirkula/UnityIngameDebugConsole)
 - [wasmtime dotnet](https://github.com/bytecodealliance/wasmtime-dotnet)
 - [WasmerSharp](https://github.com/migueldeicaza/WasmerSharp)
 - [Extism Dotnet Sdk](https://github.com/extism/dotnet-sdk)
 - [Extism Chicory Sdk (experimental)](https://github.com/extism/chicory-sdk) (built at [commit 152cf2ead89a2e5d5d3c772bb926a478707faf56](https://github.com/extism/chicory-sdk/commit/152cf2ead89a2e5d5d3c772bb926a478707faf56))

# wello-wasm 
 This is the rust project being used to make the wasm file for testing.
 You can build it using `wasm-pack build` (if you have your rust configured to build wasm. see [this documentation](https://rustwasm.github.io/docs/book/game-of-life/setup.html) for set up instructions).
 When building updates to this code, copy `pkg/wello_wasm_bg.wasm` to the resources folder and change the file extension to `.txt` 