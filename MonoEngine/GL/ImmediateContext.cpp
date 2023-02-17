#include <glad/glad.h>

// Bindings

extern "C" {
__declspec(dllexport) void ImmediateContext_SetClearColor(const float r, const float g, const float b, const float a) {
    glClearColor(r, g, b, a);
}

__declspec(dllexport) void ImmediateContext_Clear() {
    glClear(GL_COLOR_BUFFER_BIT);
}
}