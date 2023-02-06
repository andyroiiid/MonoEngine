#pragma once

#include <glad/glad.h>
#include <string>

#include "../Core/Movable.h"

class Shader {
public:
    MOVABLE(Shader)

    Shader() = default;

    Shader(const std::string &vertexSource, const std::string &fragmentSource);

    ~Shader();

    void Use();

private:
    Movable<GLuint> m_program;
};