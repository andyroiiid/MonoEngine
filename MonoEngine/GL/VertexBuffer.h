#pragma once

#include <glad/glad.h>
#include <vector>

#include "../Core/Movable.h"

template<typename Vertex>
class VertexBuffer {
public:
    MOVABLE(VertexBuffer)

    VertexBuffer() {
        glCreateBuffers(1, &m_vbo);

        glCreateVertexArrays(1, &m_vao);
        glVertexArrayVertexBuffer(m_vao, 0, m_vbo, 0, sizeof(Vertex));

        Vertex::SetupVertexArray(m_vao);
    }

    ~VertexBuffer() {
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

    void BindAndDraw(const GLenum mode) const {
        glBindVertexArray(m_vao);
        glDrawArrays(mode, 0, m_count);
    }

protected:
    Movable<GLuint>  m_vbo;
    Movable<GLuint>  m_vao;
    Movable<GLsizei> m_count;
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