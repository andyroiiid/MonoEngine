#pragma once

#include "Core/Movable.h"
#include "Mono/MonoBasics.h"
#include "Mono/MonoGame.h"
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
    MonoGame   m_game;
};