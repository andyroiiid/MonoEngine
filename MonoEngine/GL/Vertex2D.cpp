#include "Vertex2D.h"

#include "../GL/VertexBuffer.h"

void Vertex2D::SetupVertexArray(const GLuint vao) {
    SetupVertexArrayFloatsAttrib(vao, 0, 0, 2, offsetof(Vertex2D, Position));
    SetupVertexArrayFloatsAttrib(vao, 1, 0, 2, offsetof(Vertex2D, TexCoord));
    SetupVertexArrayFloatsAttrib(vao, 2, 0, 4, offsetof(Vertex2D, Color));
}