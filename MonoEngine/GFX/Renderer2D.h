#pragma once

#include "../Core/Movable.h"
#include "Mesh2D.h"
#include "Shader2D.h"

class Renderer2D {
public:
    NO_MOVE_OR_COPY(Renderer2D)

    Renderer2D();

    ~Renderer2D();

    void SetClearColor(float r, float g, float b, float a);

    void Clear();

    void DrawLine(float x0, float y0, float x1, float y1);

    void FillRect(float x0, float y0, float x1, float y1);

private:
    float m_clearColor[4]{0.2f, 0.2f, 0.2f, 1.0};

    Shader2D m_shader;

    Mesh2D m_lines;
    Mesh2D m_triangles;
};
