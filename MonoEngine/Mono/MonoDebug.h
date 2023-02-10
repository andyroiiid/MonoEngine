#pragma once

extern "C" {
__declspec(dllexport) void Debug_Info(const char *message);
__declspec(dllexport) void Debug_Warn(const char *message);
__declspec(dllexport) void Debug_Error(const char *message);
}