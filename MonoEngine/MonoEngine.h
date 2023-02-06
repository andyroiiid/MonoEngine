#pragma once

#include "Core/Movable.h"
#include "GFX/Mesh2D.h"
#include "GFX/Shader2D.h"
#include "Mono/GameClass.h"
#include "Mono/MonoBasics.h"
#include "Window/Window.h"

class MonoEngine final : public Window::App {
public:
    NO_MOVE_OR_COPY(MonoEngine)

    MonoEngine();

    ~MonoEngine() override;

    void Frame() override;

    void Resize(int width, int height) override;

private:
    MonoBasics m_mono;
    GameClass  m_gameClass;

    Shader2D m_shader;
    Mesh2D   m_quadMesh;
};