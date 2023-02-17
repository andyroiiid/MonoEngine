#include "VertexBuffer2D.h"

// Bindings

extern "C" {
__declspec(dllexport) void VertexBuffer2D_Destroy(const VertexBuffer2D *vertexBuffer2D) {
    delete vertexBuffer2D;
}

__declspec(dllexport) VertexBuffer2D *VertexBuffer2D_Create() {
    return new VertexBuffer2D;
}

__declspec(dllexport) VertexBuffer2D *VertexBuffer2D_CreateWithData(const Vertex2D *vertices, const int count) {
    return new VertexBuffer2D(count, vertices);
}

__declspec(dllexport) void VertexBuffer2D_UpdateData(VertexBuffer2D *vertexBuffer2D, const Vertex2D *vertices, const int count) {
    vertexBuffer2D->UpdateData(count, vertices);
}

__declspec(dllexport) void VertexBuffer2D_BindAndDraw(const VertexBuffer2D *vertexBuffer2D, const int mode) {
    vertexBuffer2D->BindAndDraw(mode);
}
}