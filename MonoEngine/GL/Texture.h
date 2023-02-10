#pragma once

#include <glad/glad.h>
#include <glm/vec2.hpp>

#include "../Core/Movable.h"

class Texture {
public:
    MOVABLE(Texture)

    enum class Wrap {
        Repeat,
        Clamp,
        MirrorRepeat
    };

    Texture() = default;

    Texture(const glm::ivec2 &size, const unsigned char *data, Wrap wrap, bool filter, bool mipmaps);

    ~Texture();

    [[nodiscard]] const glm::ivec2 &GetSize() const { return m_size; }

    void Bind(GLuint unit);

private:
    Movable<glm::ivec2> m_size;
    Movable<GLuint>     m_texture;
};