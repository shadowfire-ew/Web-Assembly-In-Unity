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

# wello-wasm 
 This is the rust project being used to make the wasm file for testing.
 If you have not already, use `rustup target add wasm32-unknown-unknown` to add the basic webassembly target.
 You can then build using `cargo build --target wasm32-unknown-unknown` to build the web assembly file.
 Thes resulting file can then be imported into the unity project.