use std::ffi::{c_char, CString};

/*

TODO: figure out a good system for sending strings back and forth

#[no_mangle]
pub extern fn get_something() -> *const c_char {
    CString::from(c"Here you go").as_ptr()
}

pub unsafe extern fn clean_something(ptr:*mut c_char) {
    let _ = CString::from_raw(ptr);
}
*/
#[no_mangle]
pub extern fn get_something() -> u32 {
    'h'.into()
}

#[no_mangle]
pub extern fn add_ints(a:i32,b:i32) -> i32 {
    a+b
}

#[no_mangle]
pub extern fn add_long_ints(a:i64,b:i64) -> i64 {
    a+b
}

#[no_mangle]
pub extern fn add_floats(a:f32,b:f32) -> f32 {
    a+b
}

#[no_mangle]
pub extern fn add_longs(a:f64,b:f64) -> f64 {
    a+b
}

#[no_mangle]
pub extern fn iter_int(a:i32) -> i32 {
    a+1
}

#[no_mangle]
pub extern fn avg_int(a:i32,b:i32) -> i32 {
    let c = a+b;
    c/2
}

#[no_mangle]
pub extern fn get_int() -> i32 {
    8675309
}