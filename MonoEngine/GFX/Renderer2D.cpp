﻿#include "Renderer2D.h"

static Renderer2D *g_renderer2D = nullptr;

Renderer2D::Renderer2D() {
    assert(g_renderer2D == nullptr);
    g_renderer2D = this;

    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

    m_shader.Use();
}

Renderer2D::~Renderer2D() {
    g_renderer2D = nullptr;
}

void Renderer2D::OnResize(int width, int height) {
    m_shader.SetScreenSize({width, height});
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

void Renderer2D::DrawVertices(const size_t numVertices, const Vertex2D *vertices, const GLenum mode) {
    m_vertexBuffer.UpdateData(numVertices, vertices);
    m_vertexBuffer.BindAndDraw(mode);
}

// Bindings

extern "C" {
__declspec(dllexport) void Renderer2D_SetClearColor(const float r, const float g, const float b, const float a) {
    g_renderer2D->SetClearColor(r, g, b, a);
}

__declspec(dllexport) void Renderer2D_Clear() {
    g_renderer2D->Clear();
}

__declspec(dllexport) void Renderer2D_DrawVertices(const Vertex2D *vertices, const int numVertices, const int mode) {
    g_renderer2D->DrawVertices(numVertices, vertices, mode);
}
}