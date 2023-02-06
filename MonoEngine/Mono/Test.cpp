#include "Test.h"

#include <cstdio>
#include <glad/glad.h>

void Test_Interop() {
    printf("Interop test!\n");
}

float Test_GetValue() {
    return 3.14f;
}

float Test_Add(const float a, const float b) {
    return a + b;
}

void Test_Clear(const float r, const float g, const float b, const float a) {
    const float clearColor[4]{r, g, b, a};
    glClearBufferfv(GL_COLOR, 0, clearColor);
}