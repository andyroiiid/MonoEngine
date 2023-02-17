#version 450 core

layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec4 aColor;

layout (location = 0) out vec2 vTexCoord;
layout (location = 1) out vec4 vColor;

layout (location = 0) uniform vec2 uScreenSize;
layout (location = 1) uniform vec2 uPosition;

vec2 ObjectToWorld(vec2 position)
{
    return uPosition + position;
}

vec2 WorldtoViewport(vec2 worldPosition)
{
    return worldPosition / uScreenSize * 2.0 - 1.0;
}

void main() {
    const vec2 worldPosition = ObjectToWorld(aPosition);
    const vec2 viewportPosition = WorldtoViewport(worldPosition);
    gl_Position = vec4(viewportPosition, 0.0, 1.0);
    vTexCoord = aTexCoord;
    vColor = aColor;
}