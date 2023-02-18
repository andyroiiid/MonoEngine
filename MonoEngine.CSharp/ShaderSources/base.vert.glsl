#version 450 core

layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec4 aColor;

layout (location = 0) out vec2 vTexCoord;
layout (location = 1) out vec4 vColor;

layout (location = 0) uniform vec2 uScreenSize;
layout (location = 1) uniform float uTransform[5];

vec2 Rotate(vec2 v, float r)
{
    const float c = cos(r);
    const float s = sin(r);
    return vec2(c * v.x - s * v.y, s * v.x + c * v.y);
}

vec2 ObjectToWorld(vec2 position)
{
    const vec2 uPosition = vec2(uTransform[0], uTransform[1]);
    const float uRotation = uTransform[2];
    const vec2 uScale = vec2(uTransform[3], uTransform[4]);
    return uPosition + Rotate(position * uScale, uRotation);
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