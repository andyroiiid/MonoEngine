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