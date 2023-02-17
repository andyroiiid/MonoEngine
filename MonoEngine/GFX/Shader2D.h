#pragma once

#include <glm/vec2.hpp>

#include "../GL/Shader.h"

class Shader2D : public Shader {
public:
    NO_MOVE_OR_COPY(Shader2D)

    Shader2D();

    ~Shader2D() = default;

    void SetScreenSize(const glm::vec2 &screenSize);

private:
    GLint m_screenSizeLocation = -1;
};