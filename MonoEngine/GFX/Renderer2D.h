#pragma once

#include "../Core/Movable.h"
#include "Shader2D.h"

class Renderer2D {
public:
    NO_MOVE_OR_COPY(Renderer2D)

    Renderer2D();

    ~Renderer2D();

    void OnResize(int width, int height);

    void SetClearColor(float r, float g, float b, float a);

    void Clear();

private:
    float m_clearColor[4]{0.2f, 0.2f, 0.2f, 1.0};

    Shader2D m_shader;
};