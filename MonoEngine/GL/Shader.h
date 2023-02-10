#pragma once

#include <glad/glad.h>
#include <glm/mat4x4.hpp>
#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/vec4.hpp>
#include <string>

#include "../Core/Movable.h"

class Shader {
public:
    MOVABLE(Shader)

    Shader() = default;

    Shader(const std::string &vertexSource, const std::string &fragmentSource);

    ~Shader();

    void Use();

    [[nodiscard]] GLint GetUniformLocation(const std::string &name) const;

    void SetUniform(GLint location, float value);

    void SetUniform(GLint location, const glm::vec2 &value);

    void SetUniform(GLint location, const glm::vec3 &value);

    void SetUniform(GLint location, const glm::vec4 &value);

    void SetUniform(GLint location, const glm::mat4 &value);

private:
    Movable<GLuint> m_program;
};