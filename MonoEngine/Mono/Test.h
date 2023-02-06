#pragma once

extern "C" {
__declspec(dllexport) void Test_Interop();

__declspec(dllexport) float Test_GetValue();

__declspec(dllexport) float Test_Add(float a, float b);

__declspec(dllexport) void Test_Clear(float r, float g, float b, float a);
}