#include "Renderer2D.h"

static Renderer2D *g_renderer2D = nullptr;

Renderer2D::Renderer2D() {
    assert(g_renderer2D == nullptr);
    g_renderer2D = this;

    m_lines     = Mesh2D(GL_LINES);
    m_triangles = Mesh2D(GL_TRIANGLES);

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

void Renderer2D::DrawLine(float x0, float y0, float x1, float y1) {
    const Vertex2D vertices[]{
        {{x0, y0}, {0.0f, 0.0f}},
        {{x1, y1}, {1.0f, 1.0f}},
    };
    m_lines.UpdateData(vertices);
    m_lines.BindAndDraw();
}

void Renderer2D::FillRect(float x0, float y0, float x1, float y1) {
    const Vertex2D vertices[]{
        {{x0, y0}, {0.0f, 0.0f}},
        {{x1, y0}, {1.0f, 0.0f}},
        {{x0, y1}, {0.0f, 1.0f}},
        {{x0, y1}, {0.0f, 1.0f}},
        {{x1, y0}, {1.0f, 0.0f}},
        {{x1, y1}, {1.0f, 1.0f}},
    };
    m_triangles.UpdateData(vertices);
    m_triangles.BindAndDraw();
}

// Bindings

extern "C" {
__declspec(dllexport) void Renderer2D_SetClearColor(const float r, const float g, const float b, const float a) {
    g_renderer2D->SetClearColor(r, g, b, a);
}

__declspec(dllexport) void Renderer2D_Clear() {
    g_renderer2D->Clear();
}

__declspec(dllexport) void Renderer2D_DrawLine(const float x0, const float y0, const float x1, const float y1) {
    g_renderer2D->DrawLine(x0, y0, x1, y1);
}

__declspec(dllexport) void Renderer2D_FillRect(const float x0, const float y0, const float x1, const float y1) {
    g_renderer2D->FillRect(x0, y0, x1, y1);
}
}