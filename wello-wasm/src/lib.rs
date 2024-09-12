use wasm_bindgen::prelude::*;


#[wasm_bindgen]
pub fn get_something() -> String {
    "Here you go".into()
}

#[wasm_bindgen]
pub fn add_ints(a:i32,b:i32) -> i32 {
    a+b
}

#[wasm_bindgen]
pub fn add_long_ints(a:i64,b:i64) -> i64 {
    a+b
}

#[wasm_bindgen]
pub fn add_floats(a:f32,b:f32) -> f32 {
    a+b
}

#[wasm_bindgen]
pub fn add_longs(a:f64,b:f64) -> f64 {
    a+b
}
/*
#[wasm_bindgen]
pub fn modify_array_floats(x: &mut [f32]){
    match x.get(0) {
        Some(_) => x[0] += 1.0,
        None => (),
    }
}
    */