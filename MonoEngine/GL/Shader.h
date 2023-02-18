#pragma once

#include <glad/glad.h>

#include "../Core/Movable.h"

class Shader {
public:
    MOVABLE(Shader)

    Shader() = default;

    Shader(const char *vertexSource, const char *fragmentSource);

    ~Shader();

    void Use();

    [[nodiscard]] GLint GetUniformLocation(const char *name) const;

    void SetUniform(GLint location, float x);

    void SetUniform(GLint location, float x, float y);

    void SetUniform(GLint location, float x, float y, float z);

    void SetUniform(GLint location, float x, float y, float z, float w);

    void SetUniform(GLint location, const float *values, int count);

private:
    Movable<GLuint> m_program;
};