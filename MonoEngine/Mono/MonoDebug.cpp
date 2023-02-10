#include "MonoDebug.h"

#include <spdlog/spdlog.h>

void Debug_Info(const char *message) {
    spdlog::info("Debug.Log: {}", message);
}

void Debug_Warn(const char *message) {
    spdlog::warn("Debug.Warn: {}", message);
}

void Debug_Error(const char *message) {
    spdlog::error("Debug.Error: {}", message);
}