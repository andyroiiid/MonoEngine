#pragma once

#include "../GL/Shader.h"

class Shader2D : public Shader {
public:
    NO_MOVE_OR_COPY(Shader2D)

    Shader2D();

    ~Shader2D() = default;
};