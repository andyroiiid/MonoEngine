#pragma once

#include <glad/glad.h>
#include <vector>

#include "../Core/Movable.h"

/* Here I want to ensure different types of meshes don't get mixed up.
 * That's why this whole class is a template.
 */

template<typename Vertex>
class Mesh {
public:
    MOVABLE(Mesh)

    Mesh() = default;

    // static
    Mesh(const size_t count, const Vertex *data, const GLenum mode) {
        m_count = static_cast<GLsizei>(count);
        m_mode  = mode;

        glCreateBuffers(1, &m_vbo);
        glNamedBufferStorage(m_vbo, count * sizeof(Vertex), data, 0);

        glCreateVertexArrays(1, &m_vao);
        glVertexArrayVertexBuffer(m_vao, 0, m_vbo, 0, sizeof(Vertex));

        Vertex::SetupVertexArray(m_vao);
    }

    template<size_t Size>
    Mesh(const Vertex (&data)[Size], const GLenum mode)
        : Mesh(Size, data, mode) {}

    Mesh(const std::vector<Vertex> &vertices, const GLenum mode)
        : Mesh(vertices.size(), vertices.data(), mode) {}

    // dynamic recreate
    explicit Mesh(const GLenum mode) {
        m_mode = mode;

        glCreateBuffers(1, &m_vbo);

        glCreateVertexArrays(1, &m_vao);
        glVertexArrayVertexBuffer(m_vao, 0, m_vbo, 0, sizeof(Vertex));

        Vertex::SetupVertexArray(m_vao);
    }

    ~Mesh() {
        if (m_vbo) glDeleteBuffers(1, &m_vbo);
        if (m_vao) glDeleteVertexArrays(1, &m_vao);
    }

    void UpdateData(const size_t count, const Vertex *data) {
        m_count = static_cast<GLsizei>(count);
        glNamedBufferData(m_vbo, count * sizeof(Vertex), data, GL_DYNAMIC_DRAW);
    }

    template<size_t Size>
    void UpdateData(const Vertex (&data)[Size]) {
        UpdateData(Size, data);
    }

    void UpdateData(const std::vector<Vertex> &vertices) { UpdateData(vertices.size(), vertices.data()); }

    void BindAndDraw() const {
        glBindVertexArray(m_vao);
        glDrawArrays(m_mode, 0, m_count);
    }

protected:
    Movable<GLuint>  m_vbo;
    Movable<GLuint>  m_vao;
    Movable<GLsizei> m_count;
    Movable<GLenum>  m_mode;
};

static void SetupVertexArrayAttrib(
    const GLuint    vao,
    const GLuint    attribIndex,
    const GLuint    bindingIndex,
    const GLint     size,
    const GLenum    type,
    const GLboolean normalized,
    const GLuint    relativeOffset
) {
    glEnableVertexArrayAttrib(vao, attribIndex);
    glVertexArrayAttribBinding(vao, attribIndex, bindingIndex);
    glVertexArrayAttribFormat(vao, attribIndex, size, type, normalized, relativeOffset);
}

static void SetupVertexArrayFloatsAttrib(
    const GLuint vao,
    const GLuint attribIndex,
    const GLuint bindingIndex,
    const GLint  size,
    const GLuint relativeOffset
) {
    SetupVertexArrayAttrib(vao, attribIndex, bindingIndex, size, GL_FLOAT, GL_FALSE, relativeOffset);
}