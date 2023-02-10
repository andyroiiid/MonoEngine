#include "Shader2D.h"

Shader2D::Shader2D()
    : Shader(
          R"GLSL(
#version 450 core

layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec4 aColor;

layout (location = 0) out vec2 vTexCoord;
layout (location = 1) out vec4 vColor;

layout (location = 0) uniform vec2 uScreenSize;

void main() {
    const vec2 position = aPosition / uScreenSize * 2.0 - 1.0;
    gl_Position = vec4(position, 0.0, 1.0);
    vTexCoord = aTexCoord;
    vColor = aColor;
}
)GLSL",
          R"GLSL(
#version 450 core

layout (location = 0) in vec2 vTexCoord;
layout (location = 1) in vec4 vColor;

layout (location = 0) out vec4 fColor;

layout (binding = 0) uniform sampler2D uTexture;

void main() {
    fColor = texture(uTexture, vTexCoord) * vColor;
}
)GLSL"
      ) {
    m_screenSizeLocation = GetUniformLocation("uScreenSize");
}

void Shader2D::SetScreenSize(const glm::vec2 &screenSize) {
    SetUniform(m_screenSizeLocation, screenSize);
}