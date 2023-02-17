#pragma once

#include <glad/glad.h>
#include <glm/vec2.hpp>
#include <glm/vec4.hpp>

struct Vertex2D {
    glm::vec2 Position;
    glm::vec2 TexCoord;
    glm::vec4 Color;

    Vertex2D(const glm::vec2 &position, const glm::vec2 &uv)
        : Position(position)
        , TexCoord(uv)
        , Color(1.0f, 1.0f, 1.0f, 1.0f) {}

    Vertex2D(const glm::vec2 &position, const glm::vec2 &uv, const glm::vec4 &color)
        : Position(position)
        , TexCoord(uv)
        , Color(color) {}

    static void SetupVertexArray(GLuint vao);
};