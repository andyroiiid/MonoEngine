#include "Renderer2D.h"

#include <cassert>
#include <glad/glad.h>

static Renderer2D *g_renderer2D = nullptr;

Renderer2D::Renderer2D() {
    assert(g_renderer2D == nullptr);
    g_renderer2D = this;

    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
}

Renderer2D::~Renderer2D() {
    g_renderer2D = nullptr;
}

void Renderer2D::SetClearColor(const float r, const float g, const float b, const float a) {
    m_clearColor[0] = r;
    m_clearColor[1] = g;
    m_clearColor[2] = b;
    m_clearColor[3] = a;
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Renderer2D::Clear() {
    glClearBufferfv(GL_COLOR, 0, m_clearColor);
}

// Bindings

extern "C" {
__declspec(dllexport) void Renderer2D_SetClearColor(const float r, const float g, const float b, const float a) {
    g_renderer2D->SetClearColor(r, g, b, a);
}

__declspec(dllexport) void Renderer2D_Clear() {
    g_renderer2D->Clear();
}
}